using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace BenchmarkDotNet.PresentationSamples._4.Diagnosers
{
	[HardwareCounters(HardwareCounter.CacheMisses)]
	public class SampleCacheHardwareDiagnoser
	{
		const int rows = 32 * 1000;
		const int cols = 1000;
		private byte[,] array = new byte[rows, cols];

		[Benchmark]
		public int Increment()
		{
			int sum = 0;
			for (int row = 0; row < rows; row++)
				for (int col = 0; col < cols; col++)
					sum += array[row, col];
			return sum;
		}

		[Benchmark]
		public int Increment2()
		{
			int sum = 0;
			for (int col = 0; col < cols; col++)
				for (int row = 0; row < rows; row++)
					sum += array[row, col];
			return sum;
		}
	}
}