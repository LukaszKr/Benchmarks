using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Iterate
{
	public class IterateEnumerable
	{
		private readonly List<int> list;
		private readonly int[] array;

		public IterateEnumerable()
		{
			int collectionSize = 5000000;


			list = new List<int>(collectionSize);
			array = new int[collectionSize];

			for(int x = 0; x < collectionSize; ++x)
			{
				list.Add(1);
				array[x] = 1;
			}
		}

		[Benchmark]
		public void ListForeachMethod()
		{
			int sum = 0;

			list.ForEach((element) => { sum += element; });
		}

		[Benchmark]
		public void ListForeach()
		{
			int sum = 0;

			foreach(int element in list)
			{
				sum += element;
			}
		}

		[Benchmark]
		public void ListGetCount()
		{
			int sum = 0;

			for(int x = 0; x < list.Count; ++x)
			{
				sum += list[x];
			}
		}

		[Benchmark]
		public void ListCacheCount()
		{
			int sum = 0;
			int count = list.Count;

			for(int x = 0; x < count; ++x)
			{
				sum += list[x];
			}
		}

		[Benchmark]
		public void ArrayForeach()
		{
			int sum = 0;

			foreach(int element in array)
			{
				sum += element;
			}
		}

		[Benchmark]
		public void ArrayForeachMethod()
		{
			int sum = 0;

			Array.ForEach(array, (element) => { sum += element; });
		}

		[Benchmark]
		public void ArrayGetLength()
		{
			int sum = 0;

			for(int x = 0; x < array.Length; ++x)
			{
				sum += array[x];
			}
		}

		[Benchmark]
		public void ArrayCacheLength()
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