using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using System;
using System.Threading;

namespace BenchmarkDotNet.PresentationSamples
{
	public class ColumnsConfiguration
	{
		private static Random random = new Random();

		private class Config : ManualConfig
		{
			public Config()
			{
				Add(StatisticColumn.StdErr,
					StatisticColumn.StdDev,
					StatisticColumn.Min,
					StatisticColumn.Q1,
					StatisticColumn.Median,
					StatisticColumn.Q3,
					StatisticColumn.Max);
			}
		}

		[Benchmark]
		public void SleepExactly100ms()
		{
			Sleep(timeoutMs: 100, absoluteErrorMs: 0);
		}

		[Benchmark]
		public void SleepWith30msError()
		{
			Sleep(timeoutMs: 100, absoluteErrorMs: 30);
		}

		[Benchmark]
		public void SleepWith60msError()
		{
			Sleep(timeoutMs: 100, absoluteErrorMs: 60);
		}

		[Benchmark]
		public void SleepWith90msError()
		{
			Sleep(timeoutMs: 100, absoluteErrorMs: 90);
		}

		private static void Sleep(int timeoutMs, int absoluteErrorMs)
		{
			var error = random.Next(random.Next(absoluteErrorMs + 1));
			var sign = random.Next(0, 2) * 2 - 1;
			Thread.Sleep(timeoutMs + sign * error);
		}
	}
}