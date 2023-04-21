using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Runtime.CompilerServices;

namespace Benchmarks.Class
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest), MarkdownExporterAttribute.GitHub]
	public class MethodCall
	{
		private interface IClass
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			int InterfaceMethod();
		}

		private abstract class ABaseClass : IClass
		{
			protected int m_Next = 0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public int Method()
			{
				return ++m_Next;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public int InlinedMethod()
			{
				return ++m_Next;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public virtual int VirtualMethod()
			{
				return ++m_Next;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public virtual int VirtualOverridenMethod()
			{
				return ++m_Next;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public abstract int AbstractMethod();

			[MethodImpl(MethodImplOptions.NoInlining)]
			public int InterfaceMethod()
			{
				return ++m_Next;
			}
		}

		private class TestClass : ABaseClass
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			public override int VirtualOverridenMethod()
			{
				return ++m_Next;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override int AbstractMethod()
			{
				return ++m_Next;
			}
		}

		private struct TestStruct : IClass
		{
			private int m_Next;

			public TestStruct()
			{
				m_Next = 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public int InterfaceMethod()
			{
				return ++m_Next;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public int Method()
			{
				return ++m_Next;
			}
		}

		private int iterationCount = 500000;

		[Benchmark(Baseline = true)]
		public void Method()
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.Method();
			}
		}

		[Benchmark]
		public void InlinedMethod()
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.InlinedMethod();
			}
		}

		[Benchmark]
		public void StructMethod()
		{
			int value = 0;
			TestStruct test = new TestStruct();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.Method();
			}
		}

		[Benchmark]
		public void StructViaInterfaceMethod()
		{
			int value = 0;
			TestStruct test = new TestStruct();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.InterfaceMethod();
			}
		}

		[Benchmark]
		public void VirtualMethod()
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.VirtualMethod();
			}
		}

		[Benchmark]
		public void VirtualOverridenMethod()
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.VirtualOverridenMethod();
			}
		}

		[Benchmark]
		public void AbstractMethod()
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.AbstractMethod();
			}
		}

		[Benchmark]
		public void InterfaceMethod()
		{
			int value = 0;
			IClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.InterfaceMethod();
			}
		}
	}
}
