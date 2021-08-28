using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class MethodCallTest
	{
		public interface IClass
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

		[Test, Performance]
		public void IterateEnumerable([Values(50000000)] int iterationCount)
		{
			Tester.Measure(() => VirtualOverridenMethodCall(iterationCount), nameof(VirtualOverridenMethodCall));
			Tester.Measure(() => VirtualMethodCall(iterationCount), nameof(VirtualMethodCall));
			Tester.Measure(() => InterfaceMethodCall(iterationCount), nameof(InterfaceMethodCall));
			Tester.Measure(() => AbstractMethodCall(iterationCount), nameof(AbstractMethodCall));
			Tester.Measure(() => MethodCall(iterationCount), nameof(MethodCall));
		}

		private void MethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.Method();
			}
		}

		private void VirtualMethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.VirtualMethod();
			}
		}

		private void VirtualOverridenMethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.VirtualOverridenMethod();
			}
		}

		private void AbstractMethodCall(int iterationCount)
		{
			int value = 0;
			TestClass test = new TestClass();

			for(int x = 0; x < iterationCount; ++x)
			{
				value += test.AbstractMethod();
			}
		}

		private void InterfaceMethodCall(int iterationCount)
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
