``` ini
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3693/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.402
  [Host]     : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2


```

| Method                |     Mean |    Error |   StdDev | Ratio | RatioSD |
| --------------------- | -------: | -------: | -------: | ----: | ------: |
| FlatArrayRandomAccess | 516.6 ms |  5.18 ms |  4.33 ms |  0.59 |    0.01 |
| MultiDimRandomAccess  | 873.6 ms | 13.83 ms | 12.93 ms |  1.00 |    0.00 |
| JaggedRandomAccess    | 980.2 ms | 21.96 ms | 64.76 ms |  1.19 |    0.04 |

