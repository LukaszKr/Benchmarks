``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3930/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=8.0.100
  [Host]     : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2


```
|                   Method |     Mean |   Error |  StdDev | Ratio |
|------------------------- |---------:|--------:|--------:|------:|
| AccessWithInterfaceIndex | 518.0 μs | 0.80 μs | 0.75 μs |  0.99 |
|          AccessWithIndex | 519.5 μs | 1.50 μs | 1.40 μs |  1.00 |
|             DirectAccess | 521.1 μs | 1.07 μs | 0.89 μs |  1.00 |
