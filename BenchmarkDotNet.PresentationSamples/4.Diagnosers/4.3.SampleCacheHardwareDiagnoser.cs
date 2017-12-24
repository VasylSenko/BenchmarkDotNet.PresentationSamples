using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace BenchmarkDotNet.PresentationSamples._4.Diagnosers
{
	[HardwareCounters(HardwareCounter.CacheMisses)]
	public class SampleCacheHardwareDiagnoser
	{
		const int rows = 32 * 1024;
		const int cols = 1024;
		private byte[,] array = new byte[rows, cols];

		[Benchmark]
		public void Increment()
		{
			for (int row = 0; row < rows; row++)
				for (int col = 0; col < cols; col++)
					array[row, col]++;
		}

		[Benchmark]
		public void Increment2()
		{
			for (int col = 0; col < cols; col++)
				for (int row = 0; row < rows; row++)
					array[row, col]++;
		}
	}
}