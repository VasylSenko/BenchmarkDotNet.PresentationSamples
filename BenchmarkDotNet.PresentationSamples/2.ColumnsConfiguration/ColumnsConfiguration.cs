using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using System;
using System.Threading;

namespace BenchmarkDotNet.PresentationSamples
{
	public class Config : ManualConfig
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

	[Config(typeof(Config))]
	public class ColumnsConfiguration
	{
		[Benchmark]
		public void StableParserTest() => StableParser.Parse();

		[Benchmark]
		public void UnstableParserTest() => UnstableParser.Parse();
	}

	public static class StableParser
	{
		public static void Parse()
		{
			Thread.Sleep(100);
		}
	}

	public static class UnstableParser
	{
		private static Random random = new Random();

		public static void Parse()
		{
			var error = random.Next(random.Next(100 + 1));
			var sign = random.Next(0, 2) * 2 - 1;
			Thread.Sleep(100 + sign * error);
		}
	}
}