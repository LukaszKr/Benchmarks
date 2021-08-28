using BenchmarkDotNet.Attributes;

namespace Benchmarks.Iterate
{
	public class IterateAndModifyArray3D
	{
		private readonly int[,,] m_MultiDimArray;
		private readonly int[][][] m_JaggedArray;
		private readonly int[] m_FlatArray;

		private int m_ArraySize;

		public IterateAndModifyArray3D()
		{
			m_ArraySize = 20;

			m_MultiDimArray = new int[m_ArraySize, m_ArraySize, m_ArraySize];
			m_FlatArray = new int[m_ArraySize*m_ArraySize*m_ArraySize];

			m_JaggedArray = new int[m_ArraySize][][];
			for(int x = 0; x < m_ArraySize; ++x)
			{
				int[][] subArray = new int[m_ArraySize][];
				m_JaggedArray[x] = subArray;
				for(int y = 0; y < m_ArraySize; ++y)
				{
					subArray[y] = new int[m_ArraySize];
				}
			}
		}

		[Benchmark]
		public void MultiDimGetLength()
		{
			for(int x = 0; x < m_MultiDimArray.GetLength(0); ++x)
			{
				for(int y = 0; y < m_MultiDimArray.GetLength(1); ++y)
				{
					for(int z = 0; z < m_MultiDimArray.GetLength(2); ++z)
					{
						++m_MultiDimArray[x, y, z];
					}
				}
			}
		}

		[Benchmark]
		public void MultiDimCacheLength()
		{
			int width = m_MultiDimArray.GetLength(0);
			int height = m_MultiDimArray.GetLength(1);
			int depth = m_MultiDimArray.GetLength(2);

			for(int x = 0; x < width; ++x)
			{
				for(int y = 0; y < height; ++y)
				{
					for(int z = 0; z < depth; ++z)
					{
						++m_MultiDimArray[x, y, z];
					}
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
					for(int z = 0; z < m_JaggedArray[x][y].Length; ++z)
					{
						++m_JaggedArray[x][y][z];
					}
				}
			}
		}

		[Benchmark]
		public void JaggedGetLengthCacheRow()
		{
			for(int x = 0; x < m_JaggedArray.Length; ++x)
			{
				int[][] row = m_JaggedArray[x];
				for(int y = 0; y < row.Length; ++y)
				{
					int[] line = row[y];
					for(int z = 0; z < line.Length; ++z)
					{
						++line[z];
					}
				}
			}
		}

		[Benchmark]
		public void JaggedCacheLength()
		{
			int width = m_JaggedArray.Length;
			int heigth = m_JaggedArray[0].Length;
			int depth = m_JaggedArray[0][0].Length;

			for(int x = 0; x < width; ++x)
			{
				for(int y = 0; y < heigth; ++y)
				{
					for(int z = 0; z < depth; ++z)
					{
						++m_JaggedArray[x][y][z];
					}
				}
			}
		}

		[Benchmark]
		public void JaggedCacheLengthAndRow()
		{
			int width = m_JaggedArray.Length;
			int height = m_JaggedArray[0].Length;
			int depth = m_JaggedArray[0][0].Length;

			for(int x = 0; x < width; ++x)
			{
				int[][] column = m_JaggedArray[x];
				for(int y = 0; y < height; ++y)
				{
					int[] line = column[y];
					for(int z = 0; z < depth; ++z)
					{
						++line[z];
					}
				}
			}
		}

		[Benchmark]
		public void FlatArrayRandomAccess()
		{
			int xMod = m_ArraySize*m_ArraySize;
			for(int x = 0; x < m_ArraySize; ++x)
			{
				for(int y = 0; y < m_ArraySize; ++y)
				{
					for(int z = 0; z < m_ArraySize; ++z)
					{
						int index = x*xMod + y*m_ArraySize + z;
						++m_FlatArray[index];
					}
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
					for(int z = 0; z < m_ArraySize; ++z)
					{
						++m_FlatArray[++index];
					}
				}
			}
		}
	}
}
