using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class MultiDimArrayIterationTests
	{
		[Test, Performance]
		public void JaggedVsMultiDimIteration([Values(64)] int arraySize, [Values(500)] int iterationCount)
		{
			int[,] multiDim = new int[arraySize, arraySize];
			
			int[][] jagged = new int[arraySize][];
			for(int x = 0; x < arraySize; ++x)
			{
				jagged[x] = new int[arraySize];
			}

			Measure.Method(() => MultiDimGetLength(multiDim, iterationCount))
				.SampleGroup(nameof(MultiDimGetLength)).Run();
			Measure.Method(() => MultiDimWithSize(multiDim, arraySize, iterationCount))
				.SampleGroup(nameof(MultiDimWithSize)).Run();
			Measure.Method(() => JaggedGetLength(jagged, iterationCount))
				.SampleGroup(nameof(JaggedGetLength)).Run();
			Measure.Method(() => JaggedWithSize(jagged, arraySize, iterationCount))
				.SampleGroup(nameof(JaggedWithSize)).Run();
			Measure.Method(() => JaggedCachedWithSize(jagged, arraySize, iterationCount))
				.SampleGroup(nameof(JaggedCachedWithSize)).Run();
		}

		private void MultiDimGetLength(int[,] array, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				for(int x = 0; x < array.GetLength(0); ++x)
				{
					for(int y = 0; y < array.GetLength(1); ++y)
					{
						++array[x, y];
					}
				}
			}
		}


		private void MultiDimWithSize(int[,] array, int size, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				for(int x = 0; x < size; ++x)
				{
					for(int y = 0; y < size; ++y)
					{
						++array[x, y];
					}
				}
			}
		}

		private void JaggedGetLength(int[][] jagged, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				for(int x = 0; x < jagged.Length; ++x)
				{
					for(int y = 0; y < jagged[x].Length; ++y)
					{
						++jagged[x][y];
					}
				}
			}
		}

		private void JaggedWithSize(int[][] jagged, int size, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				for(int x = 0; x < size; ++x)
				{
					for(int y = 0; y < size; ++y)
					{
						++jagged[x][y];
					}
				}
			}
		}

		private void JaggedCachedWithSize(int[][] jagged, int size, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				for(int x = 0; x < size; ++x)
				{
					int[] column = jagged[x];
					for(int y = 0; y < size; ++y)
					{
						++column[y];
					}
				}
			}
		}
	}
}
