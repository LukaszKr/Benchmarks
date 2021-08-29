using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Iterate
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	public class IterateAndModifyArray2D
	{
		private readonly int[,] m_MultiDimArray;
		private readonly int[][] m_JaggedArray;
		private readonly int[] m_FlatArray;

		private int m_ArraySize = 2000;
		private int m_IterationCount = 100;

		public IterateAndModifyArray2D()
		{
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
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				for(int x = 0; x < m_MultiDimArray.GetLength(0); ++x)
				{
					for(int y = 0; y < m_MultiDimArray.GetLength(1); ++y)
					{
						++m_MultiDimArray[x, y];
					}
				}
			}
		}

		[Benchmark]
		public void MultiDimCacheLength()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
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
		}

		[Benchmark]
		public void JaggedGetLength()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				for(int x = 0; x < m_JaggedArray.Length; ++x)
				{
					for(int y = 0; y < m_JaggedArray[x].Length; ++y)
					{
						++m_JaggedArray[x][y];
					}
				}
			}
		}

		//result suggest that this can be better than flat array at some size. Maybe it caches better on CPU?
		//Although it perform worse on random access with method above
		[Benchmark]
		public void JaggedGetLengthCacheRow()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
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
		}

		[Benchmark]
		public void JaggedCacheLength()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
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
		}

		[Benchmark]
		public void JaggedCacheLengthAndRow()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
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

		[Benchmark]
		public void FlatArrayRandomAccess()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
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
		}

		[Benchmark]
		public void FlatArrayLinearAccess()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				int index = 0;
				for(int x = 0; x < m_ArraySize; ++x)
				{
					for(int y = 0; y < m_ArraySize; ++y)
					{
						++m_FlatArray[index];
						++index;
					}
				}
			}
		}

		[Benchmark]
		public void FlatArrayCacheLength()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				int length = m_FlatArray.Length;
				for(int x = 0; x < length; ++x)
				{
					++m_FlatArray[x];
				}
			}
		}

		[Benchmark(Baseline = true)]
		public void FlatArray()
		{
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				for(int x = 0; x < m_FlatArray.Length; ++x)
				{
					++m_FlatArray[x];
				}
			}
		}
	}
}
