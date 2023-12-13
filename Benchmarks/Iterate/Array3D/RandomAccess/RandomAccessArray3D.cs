using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Iterate
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest), MarkdownExporterAttribute.GitHub]
	public class RandomAccessArray3D
	{
		private readonly int[,,] m_MultiDimArray;
		private readonly int[][][] m_JaggedArray;
		private readonly int[] m_FlatArray;

		private int m_RandomSeed = 12345;
		private int m_ArraySize = 100;
		private int m_IterationCount = 10;

		public RandomAccessArray3D()
		{
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

		#region Random Access
		[Benchmark]
		public void JaggedRandomAccess()
		{
			Random rand = new Random(m_RandomSeed);
			int length = m_FlatArray.Length;
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				for(int x = 0; x < length; ++x)
				{
					int xIndex = rand.Next(0, m_ArraySize);
					int yIndex = rand.Next(0, m_ArraySize);
					int zIndex = rand.Next(0, m_ArraySize);
					++m_JaggedArray[xIndex][yIndex][zIndex];
				}
			}
		}

		[Benchmark(Baseline = true)]
		public void MultiDimRandomAccess()
		{
			Random rand = new Random(m_RandomSeed);
			int length = m_FlatArray.Length;
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				for(int x = 0; x < length; ++x)
				{
					int xIndex = rand.Next(0, m_ArraySize);
					int yIndex = rand.Next(0, m_ArraySize);
					int zIndex = rand.Next(0, m_ArraySize);
					++m_MultiDimArray[xIndex, yIndex, zIndex];
				}
			}
		}

		[Benchmark]
		public void FlatArrayRandomAccess()
		{
			Random rand = new Random(m_RandomSeed);
			int length = m_FlatArray.Length;
			for(int iteration = 0; iteration < m_IterationCount; ++iteration)
			{
				for(int x = 0; x < length; ++x)
				{
					int index = rand.Next(0, length);
					++m_FlatArray[index];
				}
			}
		}
		#endregion
	}
}
