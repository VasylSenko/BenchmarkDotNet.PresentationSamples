using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using System;

namespace BenchmarkDotNet.PresentationSamples
{
	[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
	public class SampleBranchHardwareDiagnoser
	{
		private int[] sorted = new int[100_000];
		private int[] unsorted = new int[100_000];

		[GlobalSetup]
		public void GlobalSetup()
		{
			var random = new Random();
			for (int i = 0; i < sorted.Length; i++)
			{
				sorted[i] = unsorted[i] = random.Next(256);
			}
			Array.Sort(sorted);
		}

		[Benchmark]
		public int ProcessUnsortedArray() => Process(unsorted);

		[Benchmark]
		public int ProcessSortedArray() => Process(sorted);

		private int Process(int[] array)
		{
			int count = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] > 128) count++;
			}
			return count;
		}
	}
}