using System;
using System.IO;
using System.Text;
using CommandLine;

namespace Khondar.UNIXUtils.Concat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (Parser.Default.ParseArguments(args, options))
            {
                if (options.Version)
                {
                    var assemblyInfo = typeof(Program).Assembly.GetName();
                    Console.WriteLine(assemblyInfo.Name + " v" + assemblyInfo.Version);
                }

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

                foreach (var fileName in options.FileNames)
                {
                    DisplayFile(fileName, options);
                }
            }
        }

        private static void DisplayFile(string fileName, Options opts)
        {
            var file = new FileInfo(fileName);
            TextReader input = null;
            var output = Console.Out;
            long lineNo = 0;
            try
            {
                input = file.OpenText();
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
                        foreach (var c in buf)
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
                Console.WriteLine($"cat: {fileName}: {ex.Message}");
            }
            finally
            {
                input?.Close();
                output?.Close();
            }
        }
    }
}
