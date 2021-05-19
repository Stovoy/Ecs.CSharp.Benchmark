﻿using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    [MemoryDiagnoser]
    public partial class SystemWithTwoComponents
    {
        private partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                [Update]
                private static void Update(ref Component1 c1, in Component2 c2)
                {
                    c1.Value += c2.Value;
                }
            }

            public IParallelRunner Runner { get; }

            public ISystem<int> MonoThreadEntitySetSystem { get; }

            public ISystem<int> MultiThreadEntitySetSystem { get; }

            public DefaultEcsContext(int entityCount)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 { Value = 1 });
                }
            }

            public override void Dispose()
            {
                base.Dispose();

                Runner.Dispose();
            }
        }

        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _defaultEcs = new(EntityCount);
            _entitas = new(EntityCount);
            _leopotamEcs = new(EntityCount);
            _leopotamEcsLite = new(EntityCount);
            _monoGameExtended = new(EntityCount);
            _sveltoECS = new(EntityCount);
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _defaultEcs.Dispose();
            _entitas.Dispose();
            _leopotamEcs.Dispose();
            _leopotamEcsLite.Dispose();
            _monoGameExtended.Dispose();
            _sveltoECS.Dispose();
        }

        private DefaultEcsContext _defaultEcs;

        [Benchmark(Baseline = true)]
        public void DefaultEcs_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        [Benchmark]
        public void DefaultEcs_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}
