``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                  Method |      Mean |    Error |   StdDev | Ratio | RatioSD |
|------------------------ |----------:|---------:|---------:|------:|--------:|
|    FlatArrayCacheLength |  44.02 ms | 0.738 ms | 0.690 ms |  0.97 |    0.02 |
|               FlatArray |  45.58 ms | 0.313 ms | 0.292 ms |  1.00 |    0.00 |
|   FlatArrayRandomAccess |  47.55 ms | 0.276 ms | 0.258 ms |  1.04 |    0.01 |
| JaggedCacheLengthAndRow |  48.07 ms | 0.548 ms | 0.513 ms |  1.05 |    0.01 |
| JaggedGetLengthCacheRow |  48.50 ms | 0.610 ms | 0.541 ms |  1.06 |    0.01 |
|   FlatArrayLinearAccess |  51.92 ms | 0.294 ms | 0.275 ms |  1.14 |    0.01 |
|         JaggedGetLength |  55.98 ms | 1.095 ms | 1.261 ms |  1.23 |    0.03 |
|       JaggedCacheLength |  65.58 ms | 1.278 ms | 2.064 ms |  1.44 |    0.05 |
|     MultiDimCacheLength | 105.99 ms | 0.560 ms | 0.524 ms |  2.33 |    0.02 |
|       MultiDimGetLength | 132.40 ms | 0.296 ms | 0.277 ms |  2.91 |    0.02 |
