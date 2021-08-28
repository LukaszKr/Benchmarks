using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class IterateAndModifyArrayTest
	{
		[Test, Performance]
		public void IterateAndModifyArray([Values(5000)] int arraySize)
		{
			int[,] multiDimArray = new int[arraySize, arraySize];

			int[][] jaggedArray = new int[arraySize][];
			for(int x = 0; x < arraySize; ++x)
			{
				jaggedArray[x] = new int[arraySize];
			}

			Tester.Measure(() => MultiDimGetLength(multiDimArray), nameof(MultiDimGetLength));
			Tester.Measure(() => MultiDimCacheLength(multiDimArray), nameof(MultiDimCacheLength));
			Tester.Measure(() => JaggedGetLength(jaggedArray), nameof(JaggedGetLength));
			Tester.Measure(() => JaggedCacheLength(jaggedArray), nameof(JaggedCacheLength));
			Tester.Measure(() => JaggedCacheLengthAndRow(jaggedArray), nameof(JaggedCacheLengthAndRow));
		}

		private void MultiDimGetLength(int[,] array)
		{
			for(int x = 0; x < array.GetLength(0); ++x)
			{
				for(int y = 0; y < array.GetLength(1); ++y)
				{
					++array[x, y];
				}
			}
		}

		private void MultiDimCacheLength(int[,] array)
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

		private void JaggedGetLength(int[][] jagged)
		{
			for(int x = 0; x < jagged.Length; ++x)
			{
				for(int y = 0; y < jagged[x].Length; ++y)
				{
					++jagged[x][y];
				}
			}
		}

		private void JaggedCacheLength(int[][] jagged)
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

		private void JaggedCacheLengthAndRow(int[][] jagged)
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
