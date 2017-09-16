using CommandLine;
using CommandLine.Text;

namespace Khondar.UNIXUtils.MakeDirectory
{
    internal class Options
    {
        [Option('m', "mode", HelpText = "set file mode (as in chmod), not a=rwx - umask")]
        public string Mode { get; set; }

        [Option('p', "parents", HelpText = "no error if existing, make parent directories as needed")]
        public bool Parents { get; set; }

        [Option('v', "verbose", HelpText = "print message for each created directory")]
        public bool Verbose { get; set; }

        [Option('V', "version", HelpText = "output version information and exit")]
        public bool Version { get; set; }

        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}