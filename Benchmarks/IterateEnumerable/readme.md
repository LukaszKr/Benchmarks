``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                     Method |     Mean |    Error |   StdDev | Ratio | RatioSD |
|--------------------------- |---------:|---------:|---------:|------:|--------:|
|               ArrayForeach | 22.95 ms | 0.453 ms | 0.522 ms |  0.84 |    0.02 |
|             ListCacheCount | 24.61 ms | 0.480 ms | 0.493 ms |  0.90 |    0.02 |
|               ListGetCount | 24.72 ms | 0.488 ms | 0.562 ms |  0.90 |    0.03 |
| ArrayGetLengthCacheElement | 25.66 ms | 0.508 ms | 0.585 ms |  0.94 |    0.03 |
|           ArrayCacheLength | 27.07 ms | 0.540 ms | 0.774 ms |  0.98 |    0.03 |
|             ArrayGetLength | 27.32 ms | 0.539 ms | 0.554 ms |  1.00 |    0.00 |
|                ListForeach | 27.72 ms | 0.546 ms | 0.511 ms |  1.02 |    0.03 |
|         ArrayForeachMethod | 70.11 ms | 0.362 ms | 0.339 ms |  2.57 |    0.06 |
|          ListForeachMethod | 73.82 ms | 0.908 ms | 0.849 ms |  2.71 |    0.06 |
