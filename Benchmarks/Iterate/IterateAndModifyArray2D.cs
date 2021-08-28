using BenchmarkDotNet.Attributes;

namespace Benchmarks.Iterate
{
	public class IterateAndModifyArray2D
	{
		private readonly int[,] m_MultiDimArray;
		private readonly int[][] m_JaggedArray;
		private readonly int[] m_FlatArray;

		private int m_ArraySize;

		public IterateAndModifyArray2D()
		{
			m_ArraySize = 100;

			m_MultiDimArray = new int[m_ArraySize, m_ArraySize];
			m_FlatArray = new int[m_ArraySize*m_ArraySize];

			m_JaggedArray = new int[m_ArraySize][];
			for(int x = 0; x < m_ArraySize; ++x)
			{
				m_JaggedArray[x] = new int[m_ArraySize];
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
		public void JaggedGetLengthCacheRow()
		{
			for(int x = 0; x < m_JaggedArray.Length; ++x)
			{
				int[] row = m_JaggedArray[x];
				for(int y = 0; y < row.Length; ++y)
				{
					++row[y];
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

		[Benchmark]
		public void FlatArrayRandomAccess()
		{
			for(int x = 0; x < m_ArraySize; ++x)
			{
				for(int y = 0; y < m_ArraySize; ++y)
				{
					int index = x * m_ArraySize + y;
					++m_FlatArray[index];
				}
			}
		}

		[Benchmark]
		public void FlatArrayLinearAccess()
		{
			int index = 0;
			for(int x = 0; x < m_ArraySize; ++x)
			{
				for(int y = 0; y < m_ArraySize; ++y)
				{
					++m_FlatArray[index++];
				}
			}
		}
	}
}
