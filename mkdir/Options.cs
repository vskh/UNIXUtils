using System.Collections.Generic;
using CommandLine;
using Khondar.UNIXUtils.Shared;

namespace Khondar.UNIXUtils.MakeDirectory
{
	internal class Options : BaseOptions
	{
		[Option('p', "parents", HelpText = "no error if existing, make parent directories as needed")]
		public bool Parents { get; set; }

		[Option('v', "verbose", HelpText = "print message for each created directory")]
		public bool Verbose { get; set; }

		[ValueList(typeof(List<string>))]
		public List<string> DirectoryNames { get; set; }
	}
}