using System;
using System.IO;
using System.Text;
using vskh.UNIXUtils.Shared;

namespace vskh.UNIXUtils.Concat
{
	internal class Program : BaseUtility<Options>
	{
		private static void Main(string[] args)
		{
			new Program().Run(args);
		}

		protected override void Run(Options options)
		{
			if (options.FileNames.Count > 0)
			{
				foreach (string fileName in options.FileNames)
				{
					ToConsole(FromFile(fileName), options);
				}
			}
			else
			{
				ToConsole(FromConsole(), options);
			}
		}

		protected override Options ParseOptions(Options options)
		{
			if (options.NumberNonEmptyLines)
			{
				options.NumberAll = true;
			}

			if (options.ShowAll)
			{
				options.ShowNonPrintingWithEnds = true;
				options.ShowNonPrintingWithTabs = true;
			}

			if (options.ShowNonPrintingWithEnds)
			{
				options.ShowNonPrinting = true;
				options.ShowEnds = true;
			}

			if (options.ShowNonPrintingWithTabs)
			{
				options.ShowNonPrinting = true;
				options.ShowTabs = true;
			}

			return options;
		}

		private Source FromFile(string fileName)
		{
			var file = new FileInfo(fileName);
			return new Source(fileName, file.OpenText());
		}

		private Source FromConsole()
		{
			return new Source("<console>", Console.In);
		}

		private void ToConsole(Source source, Options opts)
		{
			TextReader input = source.Reader;
			TextWriter output = Console.Out;
			long lineNo = 0;
			try
			{
				var squeezed = false;
				string buf;
				while ((buf = input.ReadLine()) != null)
				{
					if (opts.SqueezeBlanks && squeezed && buf.Length == 0)
					{
						continue;
					}

					squeezed = buf.Length == 0;

					if (opts.ShowTabs)
					{
						buf = buf.Replace("\t", "^I");
					}

					if (opts.ShowEnds)
					{
						buf += "$";
					}

					if (opts.ShowNonPrinting)
					{
						var sb = new StringBuilder();

						// logic for non-printables translated from http://git.savannah.gnu.org/cgit/coreutils.git/tree/src/cat.c
						foreach (char c in buf)
						{
							if (c < 32)
							{
								sb.Append($"^{(char) (c + 64)}");
							}
							else
							{
								if (c < 127)
								{
									sb.Append(c);
								}
								else if (c == 127)
								{
									sb.Append("^?");
								}
								else
								{
									sb.Append("M-");
									if (c >= 128 + 32)
									{
										if (c < 128 + 127)
										{
											sb.Append((char) (c - 127));
										}
										else
										{
											sb.Append("^?");
										}
									}
									else
									{
										sb.Append($"^{(char) (c - 128 + 64)}");
									}
								}
							}
						}

						buf = sb.ToString();
					}

					if (opts.NumberAll)
					{
						if (!opts.NumberNonEmptyLines || buf.Length != 0)
						{
							++lineNo;
							buf = $"{lineNo,6:d}\t{buf}";
						}
					}

					output.WriteLine(buf);
				}
			}
			catch (IOException ex)
			{
				Console.WriteLine();
				Console.WriteLine($"cat: {source.Description}:{lineNo}: {ex.Message}");
			}
			finally
			{
				input?.Close();
				output?.Close();
			}
		}
	}
}