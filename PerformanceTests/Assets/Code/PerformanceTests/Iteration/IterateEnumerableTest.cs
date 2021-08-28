using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.PerformanceTesting;

namespace ProceduralLevel.PerformanceTests
{
	public class IterateEnumerableTest
	{
		private const int MEASUREMENT_COUNT = 20;

		[Test, Performance]
		public void IterateEnumerable([Values(8192)] int collectionSize, [Values(5000)] int iterationCount)
		{
			List<int> list = new List<int>(collectionSize);
			int[] array = new int[collectionSize];

			for(int x = 0; x < collectionSize; ++x)
			{
				list.Add(1);
				array[x] = 1;
			}

			MeasureMethod(() => ListForeachMethod(list, iterationCount), nameof(ListForeachMethod));
			MeasureMethod(() => ListForeach(list, iterationCount), nameof(ListForeach));
			MeasureMethod(() => ListGetCount(list, iterationCount), nameof(ListGetCount));
			MeasureMethod(() => ListCacheCount(list, iterationCount), nameof(ListCacheCount));

			MeasureMethod(() => ArrayForeach(array, iterationCount), nameof(ArrayForeach));
			MeasureMethod(() => ArrayGetLength(array, iterationCount), nameof(ArrayGetLength));
			MeasureMethod(() => ArrayCacheLength(array, iterationCount), nameof(ArrayCacheLength));
		}

		private void MeasureMethod(Action method, string name)
		{
			Measure.Method(method).SampleGroup(name).MeasurementCount(20).Run();
		}

		private void ListForeachMethod(List<int> list, int iterationCount)
		{
			int sum = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				list.ForEach((element) => { sum += element; });
			}
		}

		private void ListForeach(List<int> list, int iterationCount)
		{
			int sum = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				foreach(int element in list)
				{
					sum += element;
				}
			}
		}

		private void ListGetCount(List<int> list, int iterationCount)
		{
			int sum = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				for(int x = 0; x < list.Count; ++x)
				{
					sum += list[x];
				}
			}
		}

		private void ListCacheCount(List<int> list, int iterationCount)
		{
			int sum = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				int count = list.Count;

				for(int x = 0; x < count; ++x)
				{
					sum += list[x];
				}
			}
		}

		private void ArrayForeach(int[] array, int iterationCount)
		{
			int sum = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				foreach(int element in array)
				{
					sum += element;
				}
			}
		}

		private void ArrayGetLength(int[] array, int iterationCount)
		{
			int sum = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				for(int x = 0; x < array.Length; ++x)
				{
					sum += array[x];
				}
			}
		}

		private void ArrayCacheLength(int[] array, int iterationCount)
		{
			int sum = 0;

			for(int iteration = 0; iteration < iterationCount; ++iteration)
			{
				int length = array.Length;

				for(int x = 0; x < length; ++x)
				{
					sum += array[x];
				}
			}
		}
	}
}
