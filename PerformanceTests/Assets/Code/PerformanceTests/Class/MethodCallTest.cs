using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class MethodCallTest
	{
		private abstract class ABaseClass
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

		[Test, Performance]
		public void IterateEnumerable([Values(10000000)] int iterationCount)
		{
			MeasureMethod(() => MethodCall(iterationCount), nameof(MethodCall));
			MeasureMethod(() => VirtualMethodCall(iterationCount), nameof(VirtualMethodCall));
			MeasureMethod(() => VirtualOverridenMethodCall(iterationCount), nameof(VirtualOverridenMethodCall));
			MeasureMethod(() => AbstractMethodCall(iterationCount), nameof(AbstractMethodCall));
		}

		private void MeasureMethod(Action method, string name)
		{
			Measure.Method(method).SampleGroup(name).MeasurementCount(20).Run();
		}

		private void MethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value = test.Method();
			}
		}

		private void VirtualMethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value = test.VirtualMethod();
			}
		}

		private void VirtualOverridenMethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value = test.VirtualOverridenMethod();
			}
		}

		private void AbstractMethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value = test.AbstractMethod();
			}
		}
	}
}
