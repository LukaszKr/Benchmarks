``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                     Method |       Mean |    Error |   StdDev | Ratio | RatioSD |
|--------------------------- |-----------:|---------:|---------:|------:|--------:|
|        ArrayStructHandlers |   123.3 μs |  0.69 μs |  0.65 μs |  1.00 |    0.00 |
|         ArrayClassHandlers |   975.8 μs | 11.10 μs | 10.39 μs |  7.92 |    0.08 |
|          ListClassHandlers | 1,017.6 μs | 17.07 μs | 14.26 μs |  8.26 |    0.12 |
|   ListTrashedClassHandlers | 1,134.2 μs |  7.30 μs |  6.10 μs |  9.20 |    0.08 |
|            ArrayContainers | 1,590.2 μs | 23.28 μs | 20.64 μs | 12.90 |    0.15 |
|             ListContainers | 1,763.3 μs | 26.13 μs | 23.17 μs | 14.31 |    0.16 |
|      ListTrashedContainers | 2,187.4 μs | 22.80 μs | 19.04 μs | 17.75 |    0.16 |
|       ArrayLargeContainers | 2,876.5 μs | 39.41 μs | 34.94 μs | 23.34 |    0.31 |
|        ListLargeContainers | 3,052.5 μs | 60.98 μs | 59.89 μs | 24.74 |    0.53 |
| ListLargeTrashedContainers | 3,248.3 μs | 57.75 μs | 77.09 μs | 26.54 |    0.72 |
