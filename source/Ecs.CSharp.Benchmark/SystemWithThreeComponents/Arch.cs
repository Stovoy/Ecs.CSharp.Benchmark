﻿using System;
using System.Runtime.CompilerServices;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Ecs.CSharp.Benchmark.Context.Arch_Components;

namespace Ecs.CSharp.Benchmark
{
    public partial class SystemWithThreeComponents
    {
        private struct ForEach3 : IForEach<Component1, Component2, Component3>
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Update(ref Component1 t0, ref Component2 t1, ref Component3 t2)
            {
                t0.Value += t1.Value + t2.Value;
            }
        }

        private sealed class ArchContext : ArchBaseContext
        {
            public ArchContext(int entityCount, int _)
                : base(_filter, entityCount)
            { }
        }

        private static readonly Type[] _filter = { typeof(Component1), typeof(Component2), typeof(Component3) };
        private static readonly QueryDescription _queryDescription = new() { All = _filter };

        [Context]
        private readonly ArchContext _arch;

        private ForEach3 _forEach3;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.HPQuery<ForEach3, Component1, Component2, Component3>(_queryDescription, ref _forEach3);
        }
    }
}