using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace Benchmarks.CacheMiss
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest)]
	public class CacheMiss
	{
		private struct StructHandler
		{
			public int Value;
			public int SizeIncreaser;

			public void Update()
			{
				++Value;
			}
		}

		private class ClassHandler
		{
			public int Value;
			public int SizeIncreaser;

			public void Update()
			{
				++Value;
			}
		}

		private class ContainerClass
		{
			public readonly ClassHandler Handler = new ClassHandler();

			public void Update()
			{
				Handler.Update();
			}
		}

		private class LargeContainerClass
		{
			public int TrashA = 0;
			public int TrashB = 1;
			public int TrashC = 2;
			public int TrashD = 3;
			public readonly ClassHandler Handler = new ClassHandler();
			public int TrashE = 4;
			public int TrashF = 5;
			public int TrashG = 6;
			public int TrashH = 7;
			public string HelloWorld = "Hello World";
			public readonly int[] Array = new int[8];
			public long LongA = 0;
			public long LongB = 0;
			public long LongC = 0;
			public long LongD = 0;

			public void Update()
			{
				Handler.Update();
			}
		}

		//tested on i5 6600k, 256kb L1 cache, 1mb L2 cache, 6mb L3 cache
		private const int ITEMS = 256*1024;

		private readonly StructHandler[] m_ArrayStructHandlers;
		private readonly ClassHandler[] m_ArrayClassHandlers;
		private readonly List<ClassHandler> m_ListClassHandlers;
		private readonly List<ClassHandler> m_ListTrashedClassHandlers;

		private readonly ContainerClass[] m_ArrayContainers;
		private readonly List<ContainerClass> m_ListContainers;
		private readonly List<ContainerClass> m_ListTrashedContainers;

		private readonly LargeContainerClass[] m_ArrayLargeContainers;
		private readonly List<LargeContainerClass> m_ListLargeContainers;
		private readonly List<LargeContainerClass> m_ListLargeTrashedContainers;


		public CacheMiss()
		{
			m_ArrayStructHandlers = new StructHandler[ITEMS];
			m_ArrayClassHandlers = new ClassHandler[ITEMS];
			m_ListClassHandlers = new List<ClassHandler>();
			m_ListTrashedClassHandlers = new List<ClassHandler>();

			m_ArrayContainers = new ContainerClass[ITEMS];
			m_ListContainers = new List<ContainerClass>();
			m_ListTrashedContainers = new List<ContainerClass>();

			m_ArrayLargeContainers = new LargeContainerClass[ITEMS];
			m_ListLargeContainers = new List<LargeContainerClass>();
			m_ListLargeTrashedContainers = new List<LargeContainerClass>();

			for(int x = 0; x < ITEMS; ++x)
			{
				m_ArrayClassHandlers[x] = new ClassHandler();
				m_ListClassHandlers.Add(new ClassHandler());
				m_ListTrashedClassHandlers.Add(new ClassHandler());

				m_ArrayContainers[x] = new ContainerClass();
				m_ListContainers.Add(new ContainerClass());
				m_ListTrashedContainers.Add(new ContainerClass());

				m_ArrayLargeContainers[x] = new LargeContainerClass();
				m_ListLargeContainers.Add(new LargeContainerClass());
				m_ListLargeTrashedContainers.Add(new LargeContainerClass());
			}

			Shuffle(m_ListTrashedClassHandlers, new Random());
			Shuffle(m_ListTrashedContainers, new Random());
			Shuffle(m_ListLargeTrashedContainers, new Random());
		}

		public static void Shuffle<T>(List<T> list, Random rng)
		{
			int n = list.Count;
			while(n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		[Benchmark(Baseline = true)]
		public void ArrayStructHandlers()
		{
			for(int x = 0; x < m_ArrayStructHandlers.Length; ++x)
			{
				m_ArrayStructHandlers[x].Update();
			}
		}

		[Benchmark()]
		public void ArrayClassHandlers()
		{
			for(int x = 0; x < m_ArrayClassHandlers.Length; ++x)
			{
				m_ArrayClassHandlers[x].Update();
			}
		}

		[Benchmark()]
		public void ListClassHandlers()
		{
			int count = m_ListClassHandlers.Count;
			for(int x = 0; x < count; ++x)
			{
				m_ListClassHandlers[x].Update();
			}
		}

		[Benchmark()]
		public void ListTrashedClassHandlers()
		{
			int count = m_ListTrashedClassHandlers.Count;
			for(int x = 0; x < count; ++x)
			{
				m_ListTrashedClassHandlers[x].Update();
			}
		}

		[Benchmark()]
		public void ArrayContainers()
		{
			for(int x = 0; x < m_ArrayContainers.Length; ++x)
			{
				m_ArrayContainers[x].Update();
			}
		}

		[Benchmark()]
		public void ListContainers()
		{
			int count = m_ListContainers.Count;
			for(int x = 0; x < count; ++x)
			{
				m_ListContainers[x].Update();
			}
		}

		[Benchmark()]
		public void ListTrashedContainers()
		{
			int count = m_ListTrashedContainers.Count;
			for(int x = 0; x < count; ++x)
			{
				m_ListTrashedContainers[x].Update();
			}
		}

		[Benchmark()]
		public void ArrayLargeContainers()
		{
			for(int x = 0; x < m_ArrayLargeContainers.Length; ++x)
			{
				m_ArrayLargeContainers[x].Update();
			}
		}

		[Benchmark()]
		public void ListLargeContainers()
		{
			int count = m_ListLargeContainers.Count;
			for(int x = 0; x < count; ++x)
			{
				m_ListLargeContainers[x].Update();
			}
		}

		[Benchmark()]
		public void ListLargeTrashedContainers()
		{
			int count = m_ListLargeTrashedContainers.Count;
			for(int x = 0; x < count; ++x)
			{
				m_ListLargeTrashedContainers[x].Update();
			}
		}
	}
}
