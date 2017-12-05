using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace BenchmarkDotNet.PresentationSamples._4.Diagnosers
{
	[HardwareCounters(HardwareCounter.CacheMisses, HardwareCounter.TotalCycles)]
	public class SampleHardwareDiagnoser2
	{
		private const int length = 1_000_000;
		private int[] array = new int[length];

		[Benchmark]
		public int ProcessUnsortedArray()
		{
			var sum = 0;
			for (int i = 0; i < 1000; i++)
			{
				sum += array[i];
			}
			return sum;
		}

		[Benchmark]
		public int ProcessSortedArray()
		{
			var sum = 0;
			for (int i = 0; i < 1_000_000; i += 1000)
			{
				sum += array[i];
			}
			return sum;
		}
	}
}