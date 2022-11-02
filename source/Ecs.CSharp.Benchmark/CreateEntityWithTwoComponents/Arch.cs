﻿using System;
using Arch.Core;
using BenchmarkDotNet.Attributes;
using Ecs.CSharp.Benchmark.Context;

namespace Ecs.CSharp.Benchmark
{
    public partial class CreateEntityWithTwoComponents
    {
        private static readonly Type[] _archetype = { typeof(ArchBaseContext.Component1), typeof(ArchBaseContext.Component2) };

        private ArchBaseContext _arch;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.Reserve(_archetype, EntityCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Create(_archetype);
            }
        }
    }
}
