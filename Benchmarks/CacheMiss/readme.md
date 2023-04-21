``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19045
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT


```
|                     Method |       Mean |    Error |   StdDev | Ratio | RatioSD |
|--------------------------- |-----------:|---------:|---------:|------:|--------:|
|        ArrayStructHandlers |   123.7 μs |  0.52 μs |  0.49 μs |  1.00 |    0.00 |
|         ArrayClassHandlers | 1,027.4 μs | 14.44 μs | 12.80 μs |  8.31 |    0.10 |
|          ListClassHandlers | 1,076.6 μs | 21.50 μs | 23.01 μs |  8.70 |    0.22 |
|   ListTrashedClassHandlers | 1,220.6 μs | 18.42 μs | 16.33 μs |  9.87 |    0.11 |
|            ArrayContainers | 1,865.6 μs | 30.67 μs | 27.19 μs | 15.08 |    0.22 |
|             ListContainers | 1,916.3 μs | 20.20 μs | 18.90 μs | 15.50 |    0.18 |
|      ListTrashedContainers | 2,506.0 μs | 49.04 μs | 65.47 μs | 20.16 |    0.52 |
|       ArrayLargeContainers | 3,249.3 μs | 51.34 μs | 45.51 μs | 26.27 |    0.40 |
|        ListLargeContainers | 3,338.4 μs | 47.82 μs | 42.39 μs | 26.99 |    0.36 |
| ListLargeTrashedContainers | 3,687.0 μs | 56.75 μs | 47.39 μs | 29.82 |    0.29 |
