``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3693/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.402
  [Host]     : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2


```
|         Method |       Mean |   Error |  StdDev | Ratio | RatioSD |
|--------------- |-----------:|--------:|--------:|------:|--------:|
|   BitShiftHash |   393.6 μs | 3.79 μs | 3.54 μs |  1.00 |    0.00 |
| ValueTupleHash | 1,562.8 μs | 3.39 μs | 3.00 μs |  3.97 |    0.04 |
