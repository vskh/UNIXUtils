using System;
using System.Collections.Generic;
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
            }
        }
    }
}