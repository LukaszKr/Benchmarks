``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                   Method |     Mean |   Error |  StdDev | Ratio | RatioSD |
|------------------------- |---------:|--------:|--------:|------:|--------:|
|            InlinedMethod | 132.4 μs | 0.36 μs | 0.30 μs |  0.66 |    0.00 |
|             StructMethod | 201.2 μs | 0.31 μs | 0.29 μs |  1.00 |    0.00 |
|                   Method | 201.6 μs | 0.77 μs | 0.72 μs |  1.00 |    0.00 |
| StructViaInterfaceMethod | 204.7 μs | 0.74 μs | 0.69 μs |  1.02 |    0.01 |
|           AbstractMethod | 403.6 μs | 1.21 μs | 0.94 μs |  2.00 |    0.01 |
|            VirtualMethod | 403.8 μs | 1.13 μs | 1.00 μs |  2.00 |    0.01 |
|   VirtualOverridenMethod | 404.8 μs | 1.52 μs | 1.42 μs |  2.01 |    0.01 |
|          InterfaceMethod | 405.0 μs | 2.61 μs | 2.31 μs |  2.01 |    0.02 |
