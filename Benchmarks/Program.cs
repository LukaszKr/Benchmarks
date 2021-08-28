using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Benchmarks.Class;
using Benchmarks.Primitive;

namespace Benchmarks
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Summary summary;
			//summary = BenchmarkRunner.Run<IterateAndModifyArray>();
			//summary = BenchmarkRunner.Run<IterateEnumerable>();
			//summary = BenchmarkRunner.Run<ValueIncrement>();
			summary = BenchmarkRunner.Run<MethodCall>();
		}
	}
}
