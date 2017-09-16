using CommandLine;

namespace Khondar.UNIXUtils.MakeDirectory
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var options = new Options();
			if (Parser.Default.ParseArguments(args, options))
			{
			}
		}
	}
}