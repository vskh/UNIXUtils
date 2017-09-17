using System;
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

		[HelpOption]
		public string GetUsage()
		{
			return HelpText.AutoBuild(this,
				current => HelpText.DefaultParsingErrorsHandler(this, current));
		}
	}
}