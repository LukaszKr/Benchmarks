``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.2846/22H2/2022Update)
12th Gen Intel Core i7-12700KF, 1 CPU, 20 logical and 12 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.15 (6.0.1523.11507), X64 RyuJIT AVX2


```
|                Method |     Mean |     Error |    StdDev |
|---------------------- |---------:|----------:|----------:|
| AutoPropertyIncrement | 2.294 ms | 0.0047 ms | 0.0044 ms |
|     PropertyIncrement | 2.296 ms | 0.0064 ms | 0.0060 ms |
|        FieldIncrement | 2.301 ms | 0.0093 ms | 0.0087 ms |
