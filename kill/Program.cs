using System;
using System.Diagnostics;
using Khondar.UNIXUtils.Shared;

namespace Khondar.UNIXUtils.Kill
{
	internal class Program : BaseUtility<Options>
	{
		public static void Main(string[] args)
		{
			new Program().Run(args);
		}

		protected override void Run(Options options)
		{
			if (options.ArgList.Count > 0)
			{
				string myName = AppDomain.CurrentDomain.FriendlyName.ToLowerInvariant();

				if (myName.Contains("pkill"))
				{
					foreach (string procName in options.ArgList)
					{
						foreach (Process proc in Process.GetProcessesByName(procName))
						{
							try
							{
								string msg = $"kill: Ending process '{proc.ProcessName}' ({proc.Id})";

								proc.Kill();

								if (options.Verbose)
								{
									Console.WriteLine(msg);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine($"kill: Could not kill '{procName}': {ex.Message}");
							}
						}
					}
				}
				else
				{
					foreach (string pidStr in options.ArgList)
					{
						int pid;
						if (int.TryParse(pidStr, out pid))
						{
							try
							{
								Process proc = Process.GetProcessById(pid);
								string msg = $"kill: Ending process '{proc.ProcessName}' ({proc.Id})";

								proc.Kill();

								if (options.Verbose)
								{
									Console.WriteLine(msg);
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine($"kill: Could not kill '{pid}': {ex.Message}");
							}
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