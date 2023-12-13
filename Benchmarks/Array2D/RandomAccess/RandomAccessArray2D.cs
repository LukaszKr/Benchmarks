using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Iterate
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest), MarkdownExporterAttribute.GitHub]
	public class RandomAccessArray2D
	{
		private readonly int[,] m_MultiDimArray;
		private readonly int[][] m_JaggedArray;
		private readonly int[] m_FlatArray;

		private int m_RandomSeed = 12345;
		private int m_ArraySize = 2000;
		private int m_IterationCount = 10;

		public RandomAccessArray2D()
		{
			m_MultiDimArray = new int[m_ArraySize, m_ArraySize];
			m_FlatArray = new int[m_ArraySize*m_ArraySize];

			m_JaggedArray = new int[m_ArraySize][];
			for(int x = 0; x < m_ArraySize; ++x)
			{
				m_JaggedArray[x] = new int[m_ArraySize];
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
					++m_JaggedArray[xIndex][yIndex];
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
					++m_MultiDimArray[xIndex, yIndex];
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
