using System;
using System.Linq;
using System.Reflection;
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
					settings.HelpWriter = Console.Out;
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
			HelpText helpText = HelpText.AutoBuild(this,
				current => HelpText.DefaultParsingErrorsHandler(this, current));

			string toolDescription = Assembly.GetEntryAssembly()
				.GetAttribute<AssemblyDescriptionAttribute, string>(attr => attr.Description);
			
			helpText.AddPreOptionsLine(toolDescription);

			return helpText;
		}

		public override string ToString()
		{
			return "\n\t" + GetType()
				.GetProperties()
				.Where(propInfo => propInfo.GetCustomAttribute<BaseOptionAttribute>() != null)
				.Select(propInfo => $"{propInfo.Name} = {propInfo.GetValue(this)}")
				.Aggregate((s1, s2) => $"{s1}\n\t{s2}") + "\n";
		}
	}
}