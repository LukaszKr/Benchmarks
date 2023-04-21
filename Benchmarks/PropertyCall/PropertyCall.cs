using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Property
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest), MarkdownExporterAttribute.GitHub]
	public class PropertyCall
	{
		private const int ITERATIONS = 10000000;

		private class ExampleClass
		{
			public int Value;
			public int PropertyValue
			{
				get { return Value; }
				set { Value = value; }
			}

			public int AutoBackingValue { get; set; }
		}

		public PropertyCall()
		{

		}

		[Benchmark]
		public void FieldIncrement()
		{
			ExampleClass example = new ExampleClass();
			for(int x = 0; x < ITERATIONS; ++x)
			{
				example.Value++;
			}
		}

		[Benchmark]
		public void PropertyIncrement()
		{
			ExampleClass example = new ExampleClass();
			for(int x = 0; x < ITERATIONS; ++x)
			{
				example.PropertyValue++;
			}
		}

		[Benchmark]
		public void AutoPropertyIncrement()
		{
			ExampleClass example = new ExampleClass();
			for(int x = 0; x < ITERATIONS; ++x)
			{
				example.AutoBackingValue++;
			}
		}
	}
}
