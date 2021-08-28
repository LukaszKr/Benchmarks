using BenchmarkDotNet.Attributes;

namespace Benchmarks.Iterate
{
	public class IterateAndModifyArray3D
	{
		private readonly int[,,] m_MultiDimArray;
		private readonly int[][][] m_JaggedArray;
		private readonly int[] m_FlatArray;

		[Params(20)]
		public int ArraySize;

		public IterateAndModifyArray3D()
		{
			m_MultiDimArray = new int[ArraySize, ArraySize, ArraySize];
			m_FlatArray = new int[ArraySize*ArraySize*ArraySize];

			m_JaggedArray = new int[ArraySize][][];
			for(int x = 0; x < ArraySize; ++x)
			{
				int[][] subArray = new int[ArraySize][];
				m_JaggedArray[x] = subArray;
				for(int y = 0; y < ArraySize; ++y)
				{
					subArray[y] = new int[ArraySize];
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
			int xMod = ArraySize*ArraySize;
			for(int x = 0; x < ArraySize; ++x)
			{
				for(int y = 0; y < ArraySize; ++y)
				{
					for(int z = 0; z < ArraySize; ++z)
					{
						int index = x*xMod + y*ArraySize + z;
						++m_FlatArray[index];
					}
				}
			}
		}

		[Benchmark(Baseline = true)]
		public void FlatArrayLinearAccess()
		{
			int index = 0;
			for(int x = 0; x < ArraySize; ++x)
			{
				for(int y = 0; y < ArraySize; ++y)
				{
					for(int z = 0; z < ArraySize; ++z)
					{
						++m_FlatArray[index++];
					}
				}
			}
		}
	}
}
