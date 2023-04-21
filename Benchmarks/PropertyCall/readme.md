``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                Method |     Mean |     Error |    StdDev | Ratio |
|---------------------- |---------:|----------:|----------:|------:|
|     PropertyIncrement | 2.287 ms | 0.0040 ms | 0.0036 ms |  1.00 |
| AutoPropertyIncrement | 2.288 ms | 0.0061 ms | 0.0054 ms |  1.00 |
|        FieldIncrement | 2.288 ms | 0.0048 ms | 0.0045 ms |  1.00 |
