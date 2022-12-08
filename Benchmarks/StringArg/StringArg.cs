using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;

namespace Benchmarks.StringArg
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class StringArg
    {
        private const int ITERATIONS = 1000;

        [Benchmark(Baseline = true)]
        public void StringArgument()
        {
            for (int x = 0; x < ITERATIONS; ++x)
            {
                StringArgument(x >= 0, $"{x} is smaller than 0");
            }
        }

        [Benchmark]
        public void FormattableString()
        {
            for (int x = 0; x < ITERATIONS; ++x)
            {
                FormattableString(x >= 0, $"{x} is smaller than 0");
            }
        }

        [Benchmark]
        public void StringFormat()
        {
            for (int x = 0; x < ITERATIONS; ++x)
            {
                StringFormat(x >= 0, "{0} is smaller than 0", x);
            }
        }

        private void StringArgument(bool condition, string msg)
        {
            if (!condition)
            {
                throw new Exception(msg);
            }
        }

        private void FormattableString(bool condition, FormattableString msg)
        {
            if (!condition)
            {
                throw new Exception(msg.ToString());
            }
        }

        private void StringFormat<T0>(bool condition, string msg, T0 arg)
        {
            if (!condition)
            {
                throw new Exception(string.Format(msg, arg));
            }
        }
    }
}
