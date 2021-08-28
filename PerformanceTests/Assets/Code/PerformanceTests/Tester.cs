using System;

namespace ProceduralLevel.PerformanceTests
{
	public static class Tester
	{
		public static void Measure(Action method, string name)
		{
			Unity.PerformanceTesting.Measure.Method(method).SampleGroup(name).MeasurementCount(20).Run();
		}
	}
}
