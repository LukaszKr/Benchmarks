using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Primitive
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	public class ValueIncrement
	{
		private const int ITERATIONS = 100000000;

		public ValueIncrement()
		{

		}

		[Benchmark]
		public int AssignIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < ITERATIONS; iteration = iteration + 1)
			{
				value = value + 1;
			}

			return value;
		}

		[Benchmark]
		public int ByOneIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < ITERATIONS; iteration += 1)
			{
				value += 1;
			}

			return value;
		}

		[Benchmark]
		public int PostIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < ITERATIONS; iteration++)
			{
				value++;
			}

			return value;
		}

		[Benchmark(Baseline = true)]
		public int PreIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < ITERATIONS; ++iteration)
			{
				++value;
			}

			return value;
		}
	}
}
