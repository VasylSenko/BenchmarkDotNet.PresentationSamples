using BenchmarkDotNet.Attributes;
using System;

namespace BenchmarkDotNet.PresentationSamples
{
	[MemoryDiagnoser]
	public class SampleMemoryDiagnoser
	{
		[Benchmark]
		public object EmptyObject() => new object();

		[Benchmark]
		public object ObjectWithIntProp() => new { IntProp = 1 };

		[Benchmark]
		public byte[] EmptyByteArray() => Array.Empty<byte>();

		[Benchmark]
		public byte[] ZeroBytesArray() => new byte[0];

		[Benchmark]
		public byte[] TwoBytesArray() => new byte[2];
	}
}