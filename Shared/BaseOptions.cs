using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;

namespace Khondar.UNIXUtils.Shared
{
	public class BaseOptions
	{
		public Action<ParserSettings> ParserSettings
		{
			get
			{
				return settings =>
				{
					settings.CaseSensitive = true;
					settings.IgnoreUnknownArguments = false;
				};
			}
		}

		[Option('V', "version", HelpText = "output version information and exit")]
		public bool Version { get; set; }

		[Option("debug", HelpText = "add debug logging")]
		public bool Debug { get; set; }
		
		[HelpOption]
		public string GetUsage()
		{
			return HelpText.AutoBuild(this,
				current => HelpText.DefaultParsingErrorsHandler(this, current));
		}

		public override string ToString()
		{
			return GetType()
				.GetProperties()
				.Select(propInfo => $"{propInfo.Name} = {propInfo.GetValue(this)}")
				.Aggregate((s1, s2) => $"{s1}\n{s2}");
		}
	}
}