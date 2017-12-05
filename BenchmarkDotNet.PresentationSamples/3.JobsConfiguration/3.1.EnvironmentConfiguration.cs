using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using System;

namespace BenchmarkDotNet.PresentationSamples
{
	[Config(typeof(Config))]
	public class EnvironmentConfiguration
	{
		private class Config : ManualConfig
		{
			public Config()
			{
				Add(Job.Clr
					.With(Jit.RyuJit)
					.With(Platform.X64)
					.With(Platform.X64));
				Add(Job.Core
					.With(Jit.RyuJit)
					.With(Platform.X64)
					.With(Platform.X64));
			}
		}

		private byte[] source = new byte[100_000];
		private byte[] desctination = new byte[100_000];

		[Benchmark]
		public void Copy()
		{
			Array.Copy(source, desctination, source.Length);
		}

		[Benchmark]
		public void For()
		{
			for (int i = 0; i < source.Length; i++)
			{
				desctination[i] = source[i];
			}
		}
	}
}