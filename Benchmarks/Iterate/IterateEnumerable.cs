﻿using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Iterate
{
	public class IterateEnumerable
	{
		private readonly List<int> m_List;
		private readonly int[] m_Array;

		private int m_CollectionSize = 5000000;


		public IterateEnumerable()
		{


			m_List = new List<int>(m_CollectionSize);
			m_Array = new int[m_CollectionSize];

			for(int x = 0; x < m_CollectionSize; ++x)
			{
				m_List.Add(1);
				m_Array[x] = 1;
			}
		}

		[Benchmark]
		public int ListForeachMethod()
		{
			int sum = 0;

			m_List.ForEach((element) => { sum += element; });

			return sum;
		}

		[Benchmark]
		public int ListForeach()
		{
			int sum = 0;

			foreach(int element in m_List)
			{
				sum += element;
			}

			return sum;
		}

		[Benchmark]
		public int ListGetCount()
		{
			int sum = 0;

			for(int x = 0; x < m_List.Count; ++x)
			{
				sum += m_List[x];
			}

			return sum;
		}

		[Benchmark]
		public int ListCacheCount()
		{
			int sum = 0;
			int count = m_List.Count;

			for(int x = 0; x < count; ++x)
			{
				sum += m_List[x];
			}

			return sum;
		}

		[Benchmark]
		public int ArrayForeach()
		{
			int sum = 0;

			foreach(int element in m_Array)
			{
				sum += element;
			}

			return sum;
		}

		[Benchmark]
		public int ArrayForeachMethod()
		{
			int sum = 0;

			Array.ForEach(m_Array, (element) => { sum += element; });

			return sum;
		}

		[Benchmark]
		public int ArrayGetLength()
		{
			int sum = 0;

			for(int x = 0; x < m_Array.Length; ++x)
			{
				sum += m_Array[x];
			}

			return sum;
		}

		[Benchmark]
		public int ArrayCacheLength()
		{
			int sum = 0;
			int length = m_Array.Length;

			for(int x = 0; x < length; ++x)
			{
				sum += m_Array[x];
			}

			return sum;
		}
	}
}