``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|          Method |     Mean |    Error |   StdDev | Ratio |
|---------------- |---------:|---------:|---------:|------:|
|  ByOneIncrement | 23.40 ms | 0.041 ms | 0.039 ms |  1.00 |
|   PostIncrement | 23.43 ms | 0.050 ms | 0.045 ms |  1.00 |
|    PreIncrement | 23.44 ms | 0.039 ms | 0.033 ms |  1.00 |
| AssignIncrement | 23.45 ms | 0.061 ms | 0.057 ms |  1.00 |
