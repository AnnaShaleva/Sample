using CommandLine;
using CommandLine.Text;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CompileOptions, DeployOptions>(args)
              .WithParsed<CompileOptions>(ContractCompile)
              .WithParsed<DeployOptions>(ContractDeploy)
              .WithNotParsed(HandleParseError);
            Console.ReadLine();
        }
        static void ContractCompile(CompileOptions opts)
        {
            Console.WriteLine($"Run contract compile with opts: \n\tIn: {opts.In}\n\tOut: {opts.Out}\n\tDebug: {opts.Debug}");
        }
        static void ContractDeploy(DeployOptions opts)
        {
            Console.WriteLine($"Run contract deploywith opts: \n\tIn: {opts.In}\n\tConfig: {opts.Config}");

            try
            {
                using (var sr = new StreamReader(opts.Config))
                {
                    var deserializer = new DeserializerBuilder()
                        .WithNamingConvention(CamelCaseNamingConvention.Instance)
                        .Build();
                    var config = deserializer.Deserialize<Config>(sr);
                    Client.Instance.DeployContract(config);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while parsing config file: {e.Message}");
            }            
        }
        static void HandleParseError(IEnumerable<Error> errors)
        {
            Console.WriteLine("Parse error (do smth here).");            
        }
    }
}
