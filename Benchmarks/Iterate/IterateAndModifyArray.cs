using BenchmarkDotNet.Attributes;

namespace Benchmarks.Iterate
{
	public class IterateAndModifyArray
	{
		private readonly int[,] m_MultiDimArray;
		private readonly int[][] m_JaggedArray;

		public IterateAndModifyArray()
		{
			int arraySize = 100;

			m_MultiDimArray = new int[arraySize, arraySize];

			m_JaggedArray = new int[arraySize][];
			for(int x = 0; x < arraySize; ++x)
			{
				m_JaggedArray[x] = new int[arraySize];
			}
		}

		[Benchmark]
		public void MultiDimGetLength()
		{
			for(int x = 0; x < m_MultiDimArray.GetLength(0); ++x)
			{
				for(int y = 0; y < m_MultiDimArray.GetLength(1); ++y)
				{
					++m_MultiDimArray[x, y];
				}
			}
		}

		[Benchmark]
		public void MultiDimCacheLength()
		{
			int width = m_MultiDimArray.GetLength(0);
			int height = m_MultiDimArray.GetLength(1);

			for(int x = 0; x < width; ++x)
			{
				for(int y = 0; y < height; ++y)
				{
					++m_MultiDimArray[x, y];
				}
			}
		}

		[Benchmark]
		public void JaggedGetLength()
		{
			for(int x = 0; x < m_JaggedArray.Length; ++x)
			{
				for(int y = 0; y < m_JaggedArray[x].Length; ++y)
				{
					++m_JaggedArray[x][y];
				}
			}
		}

		[Benchmark]
		public void JaggedCacheLength()
		{
			int width = m_JaggedArray.Length;
			int heigth = m_JaggedArray[0].Length;

			for(int x = 0; x < width; ++x)
			{
				for(int y = 0; y < heigth; ++y)
				{
					++m_JaggedArray[x][y];
				}
			}
		}

		[Benchmark]
		public void JaggedCacheLengthAndRow()
		{
			int width = m_JaggedArray.Length;
			int height = m_JaggedArray[0].Length;

			for(int x = 0; x < width; ++x)
			{
				int[] column = m_JaggedArray[x];
				for(int y = 0; y < height; ++y)
				{
					++column[y];
				}
			}
		}
	}
}
