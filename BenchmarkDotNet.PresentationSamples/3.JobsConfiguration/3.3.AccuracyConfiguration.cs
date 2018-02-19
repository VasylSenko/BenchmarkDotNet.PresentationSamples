using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Linq;

namespace BenchmarkDotNet.PresentationSamples.Accuracy
{
	public class Config : ManualConfig
	{
		public Config()
		{
			Add(Job.Default
				.WithMinInvokeCount(2048)
				.WithEvaluateOverhead(true)
				.WithRemoveOutliers(true)
				.WithMaxRelativeError(0.01));
		}
	}

	[Config(typeof(Config))]
	public class AccuracyConfiguration
	{
		private List<int> list;
		private HashSet<int> hashset;

		[GlobalSetup]
		public void Setup()
		{
			var range = Enumerable.Range(0, 100_000);
			list = range.ToList();
			hashset = new HashSet<int>(range);
		}

		[Benchmark]
		public bool ListContains()
		{
			return list.Contains(int.MaxValue);
		}

		[Benchmark]
		public bool HashSetContains()
		{
			return hashset.Contains(int.MaxValue);
		}
	}
}