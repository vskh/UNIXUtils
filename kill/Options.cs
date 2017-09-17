using System.Collections.Generic;
using CommandLine;
using vskh.UNIXUtils.Shared;

namespace vskh.UNIXUtils.Kill
{
	public class Options : BaseOptions
	{
		[Option('v', "verbose", HelpText = "print message for each process killed")]
		public bool Verbose { get; set; }

		[ValueList(typeof(List<string>))]
		public List<string> ArgList { get; set; }
	}
}