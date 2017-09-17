using System;
using CommandLine;

namespace Khondar.UNIXUtils.Shared
{
	public abstract class BaseUtility<TOptions>
		where TOptions : BaseOptions, new()
	{
		public void Run(string[] args)
		{
			var options = ParseOptions(args);
			if (options != null)
			{
				if (options.Version)
				{
					var assemblyInfo = GetType().Assembly.GetName();
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

		protected abstract TOptions ParseOptions(TOptions options);
	}
}