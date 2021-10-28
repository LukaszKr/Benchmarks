﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Class
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	public class MethodCall
	{
		private interface IClass
		{
			int InterfaceMethod();
		}

		private abstract class ABaseClass : IClass
		{
			protected int m_Next = 0;

			public int Method()
			{
				return ++m_Next;
			}

			public virtual int VirtualMethod()
			{
				return ++m_Next;
			}

			public virtual int VirtualOverridenMethod()
			{
				return ++m_Next;
			}

			public abstract int AbstractMethod();

			public int InterfaceMethod()
			{
				return ++m_Next;
			}
		}

		private class TestClass : ABaseClass
		{
			public override int VirtualOverridenMethod()
			{
				return ++m_Next;
			}

			public override int AbstractMethod()
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
