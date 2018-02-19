using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using System;

namespace BenchmarkDotNet.PresentationSamples.Env
{
	public class Config : ManualConfig
	{
		public Config()
		{
			Add(Job.Clr.With(Jit.RyuJit).With(Platform.X64));
			Add(Job.Core.With(Jit.RyuJit).With(Platform.X64));
		}
	}

	[Config(typeof(Config))]
	public class EnvironmentConfiguration
	{
		private byte[] source = new byte[100_000];
		private byte[] desctination = new byte[100_000];

		[Benchmark]
		public void For()
		{
			for (int i = 0; i < source.Length; i++)
			{
				desctination[i] = source[i];
			}
		}

		[Benchmark]
		public void Copy()
		{
			Array.Copy(source, desctination, source.Length);
		}
	}
}