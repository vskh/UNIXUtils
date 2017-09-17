using System.Collections.Generic;
using CommandLine;
using vskh.UNIXUtils.Shared;

namespace vskh.UNIXUtils.Concat
{
	internal class Options : BaseOptions
	{
		[Option('A', "show-all", HelpText = "equivalent to -vET")]
		public bool ShowAll { get; set; }

		[Option('b', "number-nonblank", HelpText = "number non-empty output lines, overrides -n")]
		public bool NumberNonEmptyLines { get; set; }

		[Option('e', null, HelpText = "equivalent to -vE")]
		public bool ShowNonPrintingWithEnds { get; set; }

		[Option('E', "show-ends", HelpText = "display $ at the end of each line")]
		public bool ShowEnds { get; set; }

		[Option('n', "number", HelpText = "number all output lines")]
		public bool NumberAll { get; set; }

		[Option('s', "squeeze-blank", HelpText = "suppress repeated empty lines")]
		public bool SqueezeBlanks { get; set; }

		[Option('t', null, HelpText = "equivalent to -vT")]
		public bool ShowNonPrintingWithTabs { get; set; }

		[Option('T', "show-tabs", HelpText = "display tab characters as ^I")]
		public bool ShowTabs { get; set; }

		[Option('v', "show-nonprinting", HelpText = "use ^ and M- notation, except for LFD and TAB")]
		public bool ShowNonPrinting { get; set; }

		[ValueList(typeof(List<string>))]
		public List<string> FileNames { get; set; }
	}
}