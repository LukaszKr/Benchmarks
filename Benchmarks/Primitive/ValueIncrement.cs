using BenchmarkDotNet.Attributes;

namespace Benchmarks.Primitive
{
	public class ValueIncrement
	{
		private int m_IterationCount = 10000000;

		public ValueIncrement()
		{

		}

		[Benchmark]
		public void AssignIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < m_IterationCount; iteration = iteration + 1)
			{
				value = value + 1;
			}
		}

		[Benchmark]
		public void ByOneIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < m_IterationCount; iteration += 1)
			{
				value += 1;
			}
		}

		[Benchmark]
		public void PostIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < m_IterationCount; iteration++)
			{
				value++;
			}
		}

		[Benchmark]
		public void PreIncrement()
		{
			int value = 0;

			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				++value;
			}
		}
	}
}
