using System;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class IterateAndModifyArrayTest
	{
		[Test, Performance]
		public void IterateAndModifyArray([Values(64)] int arraySize, [Values(2000)] int iterationCount)
		{
			int[,] multiDimArray = new int[arraySize, arraySize];

			int[][] jaggedArray = new int[arraySize][];
			for(int x = 0; x < arraySize; ++x)
			{
				jaggedArray[x] = new int[arraySize];
			}

			Tester.Measure(() => MultiDimGetLength(multiDimArray, iterationCount), nameof(MultiDimGetLength));
			Tester.Measure(() => MultiDimCacheLength(multiDimArray, iterationCount), nameof(MultiDimCacheLength));
			Tester.Measure(() => JaggedGetLength(jaggedArray, iterationCount), nameof(JaggedGetLength));
			Tester.Measure(() => JaggedCacheLength(jaggedArray, iterationCount), nameof(JaggedCacheLength));
			Tester.Measure(() => JaggedCacheLengthAndRow(jaggedArray, iterationCount), nameof(JaggedCacheLengthAndRow));
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


		private void MultiDimCacheLength(int[,] array, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				int width = array.GetLength(0);
				int height = array.GetLength(1);

				for(int x = 0; x < width; ++x)
				{
					for(int y = 0; y < height; ++y)
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

		private void JaggedCacheLength(int[][] jagged, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				int width = jagged.Length;
				int heigth = jagged[0].Length;

				for(int x = 0; x < width; ++x)
				{
					for(int y = 0; y < heigth; ++y)
					{
						++jagged[x][y];
					}
				}
			}
		}

		private void JaggedCacheLengthAndRow(int[][] jagged, int iterationCount)
		{
			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				int width = jagged.Length;
				int height = jagged[0].Length;

				for(int x = 0; x < width; ++x)
				{
					int[] column = jagged[x];
					for(int y = 0; y < height; ++y)
					{
						++column[y];
					}
				}
			}
		}
	}
}
