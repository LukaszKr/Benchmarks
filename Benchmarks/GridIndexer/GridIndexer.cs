using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Grid
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest), MarkdownExporterAttribute.GitHub]
	public class GridIndexer
	{
		private const int ITERATIONS = 1000;
		private const int GRID_SIZE = 1280;

		private interface IIndex
		{
			int X { get; }
		}

		private readonly struct IndexWithInterface : IIndex
		{
			public int X { get; }

			public IndexWithInterface(int x)
			{
				X = x;
			}
		}

		private readonly struct Index
		{
			public readonly int X;

			public Index(int x)
			{
				X = x;
			}
		}

		private class ExplicitIndexerGrid
		{
			public readonly int[] Data;

			public ExplicitIndexerGrid(int size)
			{
				Data = new int[size];
			}

			public int Get(Index i)
			{
				return Data[i.X];
			}
		}

		private class InterfaceIndexedGrid<TIndex>
			where TIndex : IIndex
		{
			public readonly int[] Data;

			public InterfaceIndexedGrid(int size)
			{
				Data = new int[size];
			}

			public int Get(TIndex i)
			{
				return Data[i.X];
			}
		}

		[Benchmark(Baseline = true)]
		public void DirectAccess()
		{
			ExplicitIndexerGrid grid = new ExplicitIndexerGrid(GRID_SIZE);

			int sum = 0;

			for(int x = 0; x < ITERATIONS; ++x)
			{
				for(int y = 0; y < GRID_SIZE; ++y)
				{
					sum += grid.Data[y];
				}
			}
		}

		[Benchmark]
		public void AccessWithIndex()
		{
			ExplicitIndexerGrid grid = new ExplicitIndexerGrid(GRID_SIZE);

			int sum = 0;

			for(int x = 0; x < ITERATIONS; ++x)
			{
				for(int y = 0; y < GRID_SIZE; ++y)
				{
					sum += grid.Get(new Index(y));
				}
			}
		}

		[Benchmark]
		public void AccessWithInterfaceIndex()
		{
			InterfaceIndexedGrid<IndexWithInterface> grid = new InterfaceIndexedGrid<IndexWithInterface>(GRID_SIZE);

			int sum = 0;

			for(int x = 0; x < ITERATIONS; ++x)
			{
				for(int y = 0; y < GRID_SIZE; ++y)
				{
					sum += grid.Get(new IndexWithInterface(y));
				}
			}
		}
	}
}
