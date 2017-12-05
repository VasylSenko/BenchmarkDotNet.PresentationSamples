using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using System.Threading;

namespace BenchmarkDotNet.PresentationSamples
{
	[Config(typeof(Config))]
	public class RunConfiguration
	{
		private class Config : ManualConfig
		{
			public Config()
			{
				Add(Job.Default
					.With(RunStrategy.Monitoring)
					.WithLaunchCount(2)
					.WithWarmupCount(4)
					.WithTargetCount(10));
			}
		}

		private FakeCalculator calculator = new FakeCalculator();

		[Benchmark]
		public int Calc()
		{
			return calculator.Calc();
		}
	}

	public class FakeCalculator
	{
		private int calculationTimeMs = 100;

		public int Calc()
		{
			Thread.Sleep(calculationTimeMs);
			if(calculationTimeMs > 10)
				calculationTimeMs -= 10;
			return 1;
		}
	}
}