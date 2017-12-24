using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet.PresentationSamples
{
	public class IntParseBenchmark
	{
		private string integer = int.MaxValue.ToString();

		[Benchmark]
		public int Int_Parse()
		{
			return int.Parse(integer);
		}

		[Benchmark]
		public int CustomIntParse()
		{
			int val = 0;
			foreach (var c in integer) val = 10 * val + (c - '0');
			return val;
		}
	}
}