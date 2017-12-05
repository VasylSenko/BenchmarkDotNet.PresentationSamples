using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet.PresentationSamples
{
	public class IntParseBenchmark
	{
		private string str = int.MaxValue.ToString();

		[Benchmark]
		public int Int_Parse()
		{
			return int.Parse(str);
		}

		[Benchmark]
		public int CustomIntParse()
		{
			int val = 0;
			foreach (var c in str) val = 10 * val + (c - '0');
			return val;
		}
	}
}