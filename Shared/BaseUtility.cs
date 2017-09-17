using System;
using System.Reflection;
using CommandLine;

namespace Khondar.UNIXUtils.Shared
{
	public abstract class BaseUtility<TOptions>
		where TOptions : BaseOptions, new()
	{
		public void Run(string[] args)
		{
			TOptions options = ParseOptions(args);
			if (options != null)
			{
				if (options.Debug)
				{
					Console.WriteLine($"Invoked with options: {options}");
				}
				
				if (options.Version)
				{
					AssemblyName assemblyInfo = GetType().Assembly.GetName();
					Console.WriteLine(assemblyInfo.Name + " v" + assemblyInfo.Version);
					return;
				}

				Run(options);
			}
		}

		protected abstract void Run(TOptions options);

		protected TOptions ParseOptions(string[] args)
		{
			var options = new TOptions();
			var parser = new Parser(options.ParserSettings);
			
			if (parser.ParseArgumentsStrict(args, options))
			{
				return ParseOptions(options);
			}

			return null;
		}

		protected virtual TOptions ParseOptions(TOptions options)
		{
			return options;
		}
	}
}