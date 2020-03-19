using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    // CommandLine currently does not support sub-commands out-of-the-box, see https://github.com/commandlineparser/commandline/issues/353
    // So they suggest to use hyphenation on such subcommands.
    [Verb("contract-compile", HelpText = "compile a smart contract to a .avm file")]
    public class CompileOptions
    {
        [Option('i', "in",
            Required =true,
            HelpText = "Input file for the smart contract to be compiled")]
        public string In { get; set; }
        [Option('o', "out",
            Required = true,
            HelpText = "Output of the compiled contract")]
        public string Out { get; set; }
        [Option('d', "debug",
            Default = false,
            Required = false,
            HelpText = "Debug mode will print out additional information after a compiling")]
        public bool Debug { get; set; }

    }

    [Verb("contract-deploy", HelpText = "Deploy a smart contract (.avm with description)")]
    public class DeployOptions
    {
        [Option('i', "in",
            Required = true,
            HelpText = "Input file for the smart contract (*.avm)")]
        public string In { get; set; }
        [Option('c', "config",
            Required = true,
            HelpText = "Configuration input file (*.yml)")]
        public string Config { get; set; }

    }
}
