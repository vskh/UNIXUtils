using System;
using System.IO;
using Khondar.UNIXUtils.Shared;

namespace Khondar.UNIXUtils.MakeDirectory
{
	internal class Program : BaseUtility<Options>
	{
		private static void Main(string[] args)
		{
			new Program().Run(args);
		}

		protected override void Run(Options options)
		{
			if (options.DirectoryNames.Count > 0)
			{
				foreach (var directory in options.DirectoryNames)
				{
					if (File.Exists(directory) || Directory.Exists(directory))
					{
						Console.WriteLine($"mkdir: Could not create directory '{directory}': File exists");
					} else if (!Directory.Exists(directory))
					{
						try
						{
							if (options.Parents || Directory.GetParent(directory).Exists)
							{
								Directory.CreateDirectory(directory);
								
								if (options.Verbose)
								{
									Console.WriteLine($"mkdir: Creating directory '{directory}'");
								}
							}
							else
							{
								Console.WriteLine(
									$"mkdir: Could not create directory '{directory}': No such file or directory");
							}
						}
						catch (Exception e)
						{
							Console.WriteLine($"mkdir: Could not create directory '{directory}': {e.Message}");
						}
					}
				}
			}
			else
			{
				Console.WriteLine(options.GetUsage());
			}
		}
	}
}