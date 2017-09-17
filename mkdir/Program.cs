using CommandLine;

namespace Khondar.UNIXUtils.MakeDirectory
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var options = ParseOptions(args);
			
			
		}

		private static Options ParseOptions(string[] args)
		{
			var options = new Options();
			if (Parser.Default.ParseArguments(args, options))
			{
				return options;
			}

			return null;
		}
	}
}