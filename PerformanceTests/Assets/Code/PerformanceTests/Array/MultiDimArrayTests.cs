using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class MultiDimArrayTests
	{
		[Test, Performance]
		public void Test()
		{
			Measure.Method(() => { }).Run();
		}
	}
}
