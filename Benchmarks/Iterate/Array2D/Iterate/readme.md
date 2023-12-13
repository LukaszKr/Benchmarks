``` ini
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3693/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.402
  [Host]     : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2


```

| Method                  |     Mean |   Error |  StdDev | Ratio | RatioSD |
| ----------------------- | -------: | ------: | ------: | ----: | ------: |
| JaggedCacheLengthAndRow | 181.9 ms | 1.18 ms | 0.99 ms |  0.91 |    0.01 |
| JaggedGetLengthCacheRow | 182.4 ms | 2.42 ms | 2.02 ms |  0.91 |    0.02 |
| FlatArrayCacheLength    | 192.7 ms | 0.57 ms | 0.48 ms |  0.97 |    0.01 |
| FlatArray               | 199.4 ms | 2.93 ms | 2.60 ms |  1.00 |    0.00 |
| JaggedGetLength         | 201.1 ms | 1.38 ms | 1.29 ms |  1.01 |    0.02 |
| FlatArrayLinearAccess   | 203.3 ms | 0.45 ms | 0.35 ms |  1.02 |    0.01 |
| JaggedCacheLength       | 218.9 ms | 0.96 ms | 0.81 ms |  1.10 |    0.02 |
| MultiDimCacheLength     | 303.1 ms | 1.01 ms | 0.84 ms |  1.52 |    0.02 |
| MultiDimGetLength       | 411.0 ms | 2.94 ms | 2.75 ms |  2.06 |    0.03 |

