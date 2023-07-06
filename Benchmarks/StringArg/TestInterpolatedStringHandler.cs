using System.Runtime.CompilerServices;
using System.Text;

namespace Benchmarks.StringArg
{
	[InterpolatedStringHandler]
	public ref struct TestInterpolatedStringHandler
	{
		private StringBuilder m_Builder;

		public TestInterpolatedStringHandler(int literalLength, int formattedCount, bool condition)
		{
			if(condition)
			{
				m_Builder = new StringBuilder(literalLength);
			}
			else
			{
				m_Builder = null;
			}
		}

		public void AppendLiteral(string s)
		{
			m_Builder.Append(s);
		}

		public void AppendFormatted<T>(T t)
		{
			m_Builder.Append(t?.ToString());
		}

		internal string GetFormattedText()
		{
			return m_Builder.ToString();
		}
	}
}
