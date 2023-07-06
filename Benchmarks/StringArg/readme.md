``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3086/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                    Method |        Mean |     Error |    StdDev | Ratio |
|-------------------------- |------------:|----------:|----------:|------:|
|                 NoMessage |    615.8 ns |   0.98 ns |   0.76 ns |  0.03 |
|              StringFormat |    685.5 ns |   2.14 ns |   2.00 ns |  0.03 |
|        StringFormatParams |  4,215.4 ns |  54.61 ns |  48.41 ns |  0.20 |
|         FormattableString |  7,792.3 ns | 113.62 ns |  94.88 ns |  0.36 |
|            StringArgument | 21,499.1 ns | 105.33 ns |  98.53 ns |  1.00 |
| InterpolatedStringHandler | 34,263.7 ns | 194.62 ns | 182.05 ns |  1.59 |
