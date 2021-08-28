using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class ValueIncrementTest
	{
		[Test, Performance]
		public void ValueIncrement([Values(100000000)] int iterationCount)
		{
			Tester.Measure(() => AssignIncrement(iterationCount), nameof(AssignIncrement));
			Tester.Measure(() => ByOneIncrement(iterationCount), nameof(ByOneIncrement));
			Tester.Measure(() => PostIncrement(iterationCount), nameof(PostIncrement));
			Tester.Measure(() => PreIncrement(iterationCount), nameof(PreIncrement));
		}

		private void AssignIncrement(int iterationCount)
		{
			int value = 0;

			for(int iteration = 0; iteration < iterationCount; iteration = iteration + 1)
			{
				value = value + 1;
			}
		}

		private void ByOneIncrement(int iterationCount)
		{
			int value = 0;

			for(int iteration = 0; iteration < iterationCount; iteration += 1)
			{
				value += 1;
			}
		}

		private void PostIncrement(int iterationCount)
		{
			int value = 0;

			for(int iteration = 0; iteration < iterationCount; iteration++)
			{
				value++;
			}
		}

		private void PreIncrement(int iterationCount)
		{
			int value = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				++value;
			}
		}
	}
}
