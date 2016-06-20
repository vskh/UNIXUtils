using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khondar.UNIXUtils.Concat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.Version)
                {
                    var assemblyInfo = typeof(Program).Assembly.GetName();
                    Console.WriteLine(assemblyInfo.Name + " v" + assemblyInfo.Version);
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
            FileInfo file = new FileInfo(fileName);
            TextReader input = null;
            TextWriter output = Console.Out;
            try
            {
                input = file.OpenText();
                string buf;
                while ((buf = input.ReadLine()) != null)
                {
                    if (opts.ShowTabs)
                    {
                        buf = buf.Replace("\t", "^I");
                    }
                    if (opts.ShowEnds)
                    {
                        buf += "$";
                    }
                    output.WriteLine(buf);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine();
                Console.WriteLine("cat: {0}: {1}", fileName, ex.Message);
            }
            finally
            {
                input?.Close();
                output?.Close();
            }
        }
    }
}