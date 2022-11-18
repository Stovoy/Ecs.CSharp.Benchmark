# ECS c# Benchmark
This repo contains benchmarks of some c# ECS frameworks. Feel free to add your own or correct usage of existing ones! Please make you framework available as a nuget package to ease referencing and updating versions.

Tested frameworks:
- [DefaultEcs](https://github.com/Doraku/DefaultEcs)
- [Entitas](https://github.com/sschmid/Entitas-CSharp)
- [Leopotam.Ecs](https://github.com/Leopotam/ecs) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [Leopotam.EcsLite](https://github.com/Leopotam/ecslite) using what I believe is a nuget package not made by the actual author and compiled in debug...
- [MonoGame.Extended](https://github.com/craftworkgames/MonoGame.Extended)
- [Svelto.ECS](https://github.com/sebas77/Svelto.ECS)
- [Arch](https://github.com/genaray/Arch)
- [RelEcs](https://github.com/Byteron/RelEcs)

## Results

### CreateEntityWithOneComponent

| Method           |      Mean | CacheMisses/Op |   Allocated |
|------------------|----------:|---------------:|------------:|
| Arch             |  5.630 ms |        161,178 |  9740.08 KB |
| DefaultEcs       |  7.003 ms |        225,215 | 11319.74 KB |
| Entitas          | 70.305 ms |      4,028,143 | 56677.68 KB |
| LeopotamEcsLite  |  7.310 ms |         81,920 |  8170.29 KB |
| LeopotamEcs      | 20.371 ms |        651,592 | 13684.05 KB |
| MonoGameExtended | 11.587 ms |        384,887 | 16408.29 KB |
| RelEcs           | 45.629 ms |      1,124,557 | 29705.38 KB |
| SveltoECS        | 32.630 ms |        317,030 |     9.26 KB |

### CreateEntityWithTwoComponent

| Method           |      Mean | CacheMisses/Op |   Allocated |
|------------------|----------:|---------------:|------------:|
| Arch             |  5.629 ms |        149,709 |  9910.11 KB |
| DefaultEcs       | 10.879 ms |        272,657 | 15425.38 KB |
| Entitas          | 72.942 ms |      4,129,491 | 59021.43 KB |
| LeopotamEcsLite  | 11.312 ms |        100,232 |  10219.2 KB |
| LeopotamEcs      | 19.186 ms |        688,497 | 14709.38 KB |
| MonoGameExtended | 30.911 ms |        903,004 | 23372.73 KB |
| RelEcs           | 87.106 ms |      1,990,408 | 50750.16 KB |
| SveltoECS        | 50.049 ms |        557,595 |     2.16 KB |

### CreateEntityWithThreeComponents

| Method           |       Mean | CacheMisses/Op |   Allocated |
|------------------|-----------:|---------------:|------------:|
| SveltoECS        |  66.933 ms |        860,719 |    10.68 KB |
| DefaultEcs       |  13.046 ms |        380,401 | 19523.16 KB |
| Arch             |   5.848 ms |        158,944 | 10404.64 KB |
| Entitas          |  76.256 ms |      4,230,417 | 61365.18 KB |
| LeopotamEcsLite  |  15.602 ms |        121,916 | 12268.15 KB |
| LeopotamEcs      |  18.325 ms |        632,832 | 15734.73 KB |
| MonoGameExtended |  44.629 ms |      1,874,944 | 30152.63 KB |
| RelEcs           | 115.247 ms |      3,015,308 | 75704.92 KB |

### SystemWithOneComponent

| Method                                 |        Mean | CacheMisses/Op | Allocated |
|----------------------------------------|------------:|---------------:|----------:|
| Arch                                   |    47.29 μs |              5 |         - |
| DefaultEcs_ComponentSystem_MonoThread  |    48.81 μs |              3 |         - |
| DefaultEcs_ComponentSystem_MultiThread |    49.11 μs |              3 |         - |
| DefaultEcs_EntitySetSystem_MonoThread  |    97.52 μs |             16 |         - |
| DefaultEcs_EntitySetSystem_MultiThread |    56.92 μs |             48 |         - |
| Entitas_MonoThread                     | 7,731.18 μs |        656,836 |     109 B |
| Entitas_MultiThread                    | 1,731.07 μs |        659,308 |    1155 B |
| LeopotamEcsLite                        | 1,216.38 μs |            403 |       3 B |
| LeopotamEcs                            |    88.80 μs |              8 |         - |
| MonoGameExtended                       |   724.49 μs |         10,379 |     161 B |
| RelEcs                                 |   441.76 μs |         19,148 |     121 B |
| SveltoECS                              |   122.66 μs |             11 |         - |

### SystemWithTwoComponents

| Method                 |        Mean | CacheMisses/Op | Allocated |
|------------------------|------------:|---------------:|----------:|
| Arch                   |    59.28 μs |              9 |         - |
| DefaultEcs_MonoThread  |   142.02 μs |             30 |         - |
| DefaultEcs_MultiThread |    53.95 μs |             55 |         - |
| Entitas_MonoThread     | 5,410.08 μs |        773,501 |     112 B |
| Entitas_MultiThread    | 1,727.58 μs |        769,941 |    1156 B |
| LeopotamEcsLite        | 2,356.25 μs |            968 |       7 B |
| LeopotamEcs            |   159.14 μs |             19 |         - |
| MonoGameExtended       | 1,055.43 μs |         89,283 |     163 B |
| RelEcs                 | 1,433.91 μs |        103,761 |     491 B |
| SveltoECS              |   227.20 μs |             21 |         - |

### SystemWithThreeComponents

| Method                 |        Mean | CacheMisses/Op | Allocated |
|------------------------|------------:|---------------:|----------:|
| Arch                   |    78.14 μs |             33 |         - |
| DefaultEcs_MonoThread  |   233.59 μs |             41 |         - |
| DefaultEcs_MultiThread |    59.88 μs |             86 |         - |
| Entitas_MonoThread     | 4,776.95 μs |        801,780 |     109 B |
| Entitas_MultiThread    | 1,800.59 μs |        798,973 |    1155 B |
| LeopotamEcsLite        | 3,552.39 μs |          2,191 |       5 B |
| LeopotamEcs            |   288.91 μs |             49 |       1 B |
| MonoGameExtended       | 1,028.00 μs |         99,811 |     163 B |
| RelEcs                 |   712.04 μs |         67,633 |     217 B |
| SveltoECS              |   319.39 μs |             33 |       1 B |

### SystemWithTwoComponentsMultipleComposition

| Method                 |        Mean | CacheMisses/Op | Allocated |
|------------------------|------------:|---------------:|----------:|
| Arch                   |    59.32 μs |              8 |         - |
| DefaultEcs_MonoThread  |   142.21 μs |             27 |         - |
| DefaultEcs_MultiThread |    54.28 μs |             59 |         - |
| Entitas_MonoThread     | 5,057.96 μs |        733,211 |     109 B |
| Entitas_MultiThread    | 1,682.34 μs |        734,546 |    1155 B |
| LeopotamEcsLite        | 2,346.29 μs |          1,065 |       5 B |
| LeopotamEcs            |   154.63 μs |             19 |         - |
| MonoGameExtended       |   879.68 μs |         50,361 |     161 B |
| RelEcs                 |   500.92 μs |         24,000 |     169 B |
| SveltoECS              |   227.01 μs |             18 |         - |


## [CreateEntityWithOneComponent](results/Ecs.CSharp.Benchmark.CreateEntityWithOneComponent-report-github.md)
Create entities with one component.

## [CreateEntityWithTwoComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithTwoComponents-report-github.md)
Create entities with two components.

## [CreateEntityWithThreeComponents](results/Ecs.CSharp.Benchmark.CreateEntityWithThreeComponents-report-github.md)
Create entities with three components.

## [SystemWithOneComponent](results/Ecs.CSharp.Benchmark.SystemWithOneComponent-report-github.md)
Modify entities with one component. The padding aims to simulate real situation when processed entities and their components are not sequential.

## [SystemWithTwoComponents](results/Ecs.CSharp.Benchmark.SystemWithTwoComponents-report-github.md)
Modify entities with two components. The padding aims to simulate real situation when processed entities and their components are not sequential.

## [SystemWithThreeComponents](results/Ecs.CSharp.Benchmark.SystemWithThreeComponents-report-github.md)
Modify entities with three components. The padding aims to simulate real situation when processed entities and their components are not sequential.

## [SystemWithTwoComponentsMultipleComposition](results/Ecs.CSharp.Benchmark.SystemWithTwoComponentsMultipleComposition-report-github.md)
Modify entities with two components while different entity compositions match the the components query.
