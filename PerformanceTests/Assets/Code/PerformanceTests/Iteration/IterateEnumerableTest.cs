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
		public void IterateEnumerable([Values(25000000)] int collectionSize)
		{
			List<int> list = new List<int>(collectionSize);
			int[] array = new int[collectionSize];

			for(int x = 0; x < collectionSize; ++x)
			{
				list.Add(1);
				array[x] = 1;
			}

			Tester.Measure(() => ListForeachMethod(list), nameof(ListForeachMethod));
			Tester.Measure(() => ListForeach(list), nameof(ListForeach));
			Tester.Measure(() => ListGetCount(list), nameof(ListGetCount));
			Tester.Measure(() => ListCacheCount(list), nameof(ListCacheCount));

			Tester.Measure(() => ArrayForeachMethod(array), nameof(ArrayForeachMethod));
			Tester.Measure(() => ArrayForeach(array), nameof(ArrayForeach));
			Tester.Measure(() => ArrayGetLength(array), nameof(ArrayGetLength));
			Tester.Measure(() => ArrayCacheLength(array), nameof(ArrayCacheLength));
		}

		private void ListForeachMethod(List<int> list)
		{
			int sum = 0;

			list.ForEach((element) => { sum += element; });
		}

		private void ListForeach(List<int> list)
		{
			int sum = 0;
			
			foreach(int element in list)
			{
				sum += element;
			}
		}

		private void ListGetCount(List<int> list)
		{
			int sum = 0;

			for(int x = 0; x < list.Count; ++x)
			{
				sum += list[x];
			}
		}

		private void ListCacheCount(List<int> list)
		{
			int sum = 0;
			int count = list.Count;

			for(int x = 0; x < count; ++x)
			{
				sum += list[x];
			}
		}

		private void ArrayForeach(int[] array)
		{
			int sum = 0;

			foreach(int element in array)
			{
				sum += element;
			}
		}

		private void ArrayForeachMethod(int[] array)
		{
			int sum = 0;

			Array.ForEach(array, (element) => { sum += element; });
		}

		private void ArrayGetLength(int[] array)
		{
			int sum = 0;

			for(int x = 0; x < array.Length; ++x)
			{
				sum += array[x];
			}
		}

		private void ArrayCacheLength(int[] array)
		{
			int sum = 0;
			int length = array.Length;

			for(int x = 0; x < length; ++x)
			{
				sum += array[x];
			}
		}
	}
}
