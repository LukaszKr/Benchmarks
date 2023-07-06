using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.StringArg
{
	[Orderer(SummaryOrderPolicy.FastestToSlowest), MarkdownExporterAttribute.GitHub]
	public class StringArg
	{
		//proxy methods without inlining to prevent optimizer from doing magic with loops
		private const int ITERATIONS = 1000;

		#region String Argument
		[Benchmark(Baseline = true)]
		public void StringArgument()
		{
			for(int x = 0; x < ITERATIONS; ++x)
			{
				StringArgumentMethod(x);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StringArgumentMethod(int index)
		{
			AssertStringArgument(index >= 0, $"{index} is smaller than 0");
		}

		private void AssertStringArgument(bool condition, string msg)
		{
			if(!condition)
			{
				throw new Exception(msg);
			}
		}
		#endregion

		#region No Message
		[Benchmark]
		public void NoMessage()
		{
			for(int x = 0; x < ITERATIONS; ++x)
			{
				NoMessageMethod(x);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void NoMessageMethod(int index)
		{
			AssertNoMessage(index >= 0);
		}

		private void AssertNoMessage(bool condition)
		{
			if(!condition)
			{
				throw new Exception();
			}
		}
		#endregion

		#region Formattable String
		[Benchmark]
		public void FormattableString()
		{
			for(int x = 0; x < ITERATIONS; ++x)
			{
				FormattableStringMethod(x);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void FormattableStringMethod(int index)
		{
			AssertFormattableString(index >= 0, $"{index} is smaller than 0");
		}

		private void AssertFormattableString(bool condition, FormattableString msg)
		{
			if(!condition)
			{
				throw new Exception(msg.ToString());
			}
		}
		#endregion

		#region String Format
		[Benchmark]
		public void StringFormat()
		{
			for(int x = 0; x < ITERATIONS; ++x)
			{
				StringFormatMethod(x);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StringFormatMethod(int index)
		{
			AssertStringFormat(index >= 0, "{0} is smaller than 0", index);
		}

		private void AssertStringFormat<T0>(bool condition, string msg, T0 arg)
		{
			if(!condition)
			{
				throw new Exception(string.Format(msg, arg));
			}
		}
		#endregion

		#region String Format Params
		[Benchmark]
		public void StringFormatParams()
		{
			for(int x = 0; x < ITERATIONS; ++x)
			{
				StringFormatparamsMethod(x);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void StringFormatparamsMethod(int index)
		{
			AssertStringFormatParams(index >= 0, "{0} is smaller than 0", index);
		}

		private void AssertStringFormatParams(bool condition, string msg, params object[] args)
		{
			if(!condition)
			{
				throw new Exception(string.Format(msg, args));
			}
		}
		#endregion

		#region Interpolated String Handler
		[Benchmark]
		public void InterpolatedStringHandler()
		{
			for(int x = 0; x < ITERATIONS; ++x)
			{
				InterpolatedStringHandlerMethod(x);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void InterpolatedStringHandlerMethod(int index)
		{
			AssertInterpolatedString(index >= 0, $"{index} is smaller than 0");
		}

		private void AssertInterpolatedString(bool condition, [InterpolatedStringHandlerArgument("condition")] TestInterpolatedStringHandler message)
		{
			if(!condition)
			{
				throw new Exception(message.GetFormattedText());
			}
		}
		#endregion
	}
}
