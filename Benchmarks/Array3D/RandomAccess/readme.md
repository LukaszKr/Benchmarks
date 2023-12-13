``` ini
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3693/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.402
  [Host]     : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2


```

| Method                |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |
| --------------------- | --------: | -------: | -------: | --------: | ----: | ------: |
| FlatArrayRandomAccess |  93.66 ms | 1.868 ms | 4.021 ms |  95.18 ms |  0.43 |    0.02 |
| MultiDimRandomAccess  | 213.48 ms | 1.773 ms | 1.384 ms | 213.46 ms |  1.00 |    0.00 |
| JaggedRandomAccess    | 219.62 ms | 0.678 ms | 0.601 ms | 219.64 ms |  1.03 |    0.01 |

