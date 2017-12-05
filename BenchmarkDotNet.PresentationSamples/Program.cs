using BenchmarkDotNet.Running;
using System.Reflection;

namespace BenchmarkDotNet.PresentationSamples
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkSwitcher.FromAssembly(typeof(Program).GetTypeInfo().Assembly).Run(args);
		}
	}
}