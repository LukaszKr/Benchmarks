``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|            Method |        Mean |    Error |   StdDev | Ratio |
|------------------ |------------:|---------:|---------:|------:|
|      StringFormat |    310.0 ns |  0.75 ns |  0.70 ns |  0.01 |
| FormattableString |  7,684.6 ns | 46.25 ns | 41.00 ns |  0.37 |
|    StringArgument | 20,839.9 ns | 97.27 ns | 86.23 ns |  1.00 |
