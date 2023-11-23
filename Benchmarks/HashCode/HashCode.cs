using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.HashCode
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest), MarkdownExporterAttribute.GitHub]
	public class HashCode
	{
		private readonly struct BitShiftHashStruct
		{
			public readonly int X;
			public readonly int Y;

			public BitShiftHashStruct(int x, int y)
			{
				X = x;
				Y = y;
			}

			public override int GetHashCode()
			{
				return (X << 16)+Y;
			}
		}

		private readonly struct ValueTupleHashStruct
		{
			public readonly int X;
			public readonly int Y;

			public ValueTupleHashStruct(int x, int y)
			{
				X = x;
				Y = y;
			}

			public override int GetHashCode()
			{
				return (X, Y).GetHashCode();
			}
		}

		private const int REPEAT = 1000000;

		[Benchmark(Baseline = true)]
		public void BitShiftHash()
		{
			long sum = 0;
			for(int x = 0; x < REPEAT; ++x)
			{
				BitShiftHashStruct s = new BitShiftHashStruct(x, x);
				int hash = s.GetHashCode();
				sum += hash;
			}
		}

		[Benchmark()]
		public void ValueTupleHash()
		{
			long sum = 0;
			for(int x = 0; x < REPEAT; ++x)
			{
				ValueTupleHashStruct s = new ValueTupleHashStruct(x, x);
				int hash = s.GetHashCode();
				sum += hash;
			}
		}
	}
}
