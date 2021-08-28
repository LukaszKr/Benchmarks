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
		public int ListForeachMethod()
		{
			int sum = 0;

			list.ForEach((element) => { sum += element; });

			return sum;
		}

		[Benchmark]
		public int ListForeach()
		{
			int sum = 0;

			foreach(int element in list)
			{
				sum += element;
			}

			return sum;
		}

		[Benchmark]
		public int ListGetCount()
		{
			int sum = 0;

			for(int x = 0; x < list.Count; ++x)
			{
				sum += list[x];
			}

			return sum;
		}

		[Benchmark]
		public int ListCacheCount()
		{
			int sum = 0;
			int count = list.Count;

			for(int x = 0; x < count; ++x)
			{
				sum += list[x];
			}

			return sum;
		}

		[Benchmark]
		public int ArrayForeach()
		{
			int sum = 0;

			foreach(int element in array)
			{
				sum += element;
			}

			return sum;
		}

		[Benchmark]
		public int ArrayForeachMethod()
		{
			int sum = 0;

			Array.ForEach(array, (element) => { sum += element; });

			return sum;
		}

		[Benchmark]
		public int ArrayGetLength()
		{
			int sum = 0;

			for(int x = 0; x < array.Length; ++x)
			{
				sum += array[x];
			}

			return sum;
		}

		[Benchmark]
		public int ArrayCacheLength()
		{
			int sum = 0;
			int length = array.Length;

			for(int x = 0; x < length; ++x)
			{
				sum += array[x];
			}

			return sum;
		}
	}
}