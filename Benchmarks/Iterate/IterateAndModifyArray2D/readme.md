``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                  Method |     Mean |   Error |  StdDev | Ratio | RatioSD |
|------------------------ |---------:|--------:|--------:|------:|--------:|
| JaggedGetLengthCacheRow | 175.4 ms | 1.46 ms | 1.37 ms |  0.93 |    0.01 |
| JaggedCacheLengthAndRow | 176.5 ms | 1.23 ms | 1.09 ms |  0.93 |    0.01 |
|    FlatArrayCacheLength | 183.7 ms | 0.65 ms | 0.61 ms |  0.97 |    0.01 |
|               FlatArray | 189.5 ms | 1.03 ms | 0.97 ms |  1.00 |    0.00 |
|         JaggedGetLength | 189.6 ms | 0.78 ms | 0.73 ms |  1.00 |    0.01 |
|   FlatArrayLinearAccess | 196.3 ms | 0.88 ms | 0.83 ms |  1.04 |    0.01 |
|   FlatArrayRandomAccess | 201.7 ms | 1.04 ms | 0.97 ms |  1.06 |    0.01 |
|       JaggedCacheLength | 209.5 ms | 0.81 ms | 0.72 ms |  1.11 |    0.01 |
|     MultiDimCacheLength | 286.9 ms | 1.45 ms | 1.28 ms |  1.51 |    0.01 |
|       MultiDimGetLength | 404.6 ms | 4.94 ms | 4.12 ms |  2.13 |    0.03 |
