using BenchmarkDotNet.Attributes;

namespace Benchmarks.Primitive
{
	public class ValueIncrement
	{
		[Params(10000000)]
		public int IterationCount;

		public ValueIncrement()
		{

		}

		[Benchmark]
		public int AssignIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < IterationCount; iteration = iteration + 1)
			{
				value = value + 1;
			}

			return value;
		}

		[Benchmark]
		public int ByOneIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < IterationCount; iteration += 1)
			{
				value += 1;
			}

			return value;
		}

		[Benchmark]
		public int PostIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < IterationCount; iteration++)
			{
				value++;
			}

			return value;
		}

		[Benchmark]
		public int PreIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < IterationCount; ++iteration)
			{
				++value;
			}

			return value;
		}
	}
}
