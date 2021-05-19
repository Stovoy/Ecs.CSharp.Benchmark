﻿using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;
using Leopotam.EcsLite;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        private LeopotamEcsLiteBaseContext _leopotamEcsLite;

        [Benchmark]
        public void LeopotamEcsLite()
        {
            EcsPool<LeopotamEcsLiteBaseContext.Component1> c1 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component1>();
            EcsPool<LeopotamEcsLiteBaseContext.Component2> c2 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component2>();

            for (int i = 0; i < EntityCount; ++i)
            {
                int entity = _leopotamEcsLite.World.NewEntity();
                c1.Add(entity);
                c2.Add(entity);
            }
        }
    }
}
