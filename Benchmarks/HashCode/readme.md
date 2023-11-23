``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3693/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.402
  [Host]     : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2


```
|         Method |        Mean |    Error |   StdDev | Ratio |
|--------------- |------------:|---------:|---------:|------:|
|   BitShiftHash |    390.6 μs |  0.30 μs |  0.25 μs |  0.03 |
| ValueTupleHash |  1,607.9 μs |  2.21 μs |  1.96 μs |  0.14 |
|    DefaultHash | 11,797.0 μs | 41.63 μs | 36.90 μs |  1.00 |
