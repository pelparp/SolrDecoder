using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CommandLine;
using System.Collections.Generic;
using NLog.Targets;
using NLog;

namespace SWDecoder
{
    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Full path of .cs file that contains the payload")]
        public string InputPath { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output path")]
        public string OutputPath { get; set; }
    }
    public class Program
    {
        public static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            /* Set up logging configuration */
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile")
            {
                Layout = @"[${longdate}] [${level}] [${callsite}:${callsite-linenumber}] ${message} ${exception}",
                FileName = Settings.outdir + "\\SWDecoder_" + Settings.epoch + ".log"
            };

            var logconsole = new ColoredConsoleTarget("logconsole") { Layout = @"[${longdate}] [${level}] ${message} ${exception}" };
            var lognullstream = new NLog.Targets.NullTarget();
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile, "SWDecoder*"); // Only log from the SWDecoder logger and ignore libraries
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole, "SWDecoder*");
            NLog.LogManager.Configuration = config;
            Console.WriteLine(" _____       _     ______                   _           ");
            Console.WriteLine("/  ___|     | |    |  _  \\                 | |          ");
            Console.WriteLine("\\ `--.  ___ | |_ __| | | |___  ___ ___   __| | ___ _ __ ");
            Console.WriteLine(" `--. \\/ _ \\| | '__| | | / _ \\/ __/ _ \\ / _` |/ _ \\ '__|");
            Console.WriteLine("/\\__/ / (_) | | |  | |/ /  __/ (_| (_) | (_| |  __/ |   ");
            Console.WriteLine("\\____/ \\___/|_|_|  |___/ \\___|\\___\\___/ \\__,_|\\___|_|   ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("======== A tool to convert compressed base64 compressed strings to plaintext ============");
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                            .WithParsed<Options>(o =>
                            {
                                Settings.infile = Path.GetFullPath(o.InputPath.TrimEnd('\\'));
                                Settings.outdir = Path.GetFullPath(o.OutputPath.TrimEnd('\\'));
                            })
                            .WithNotParsed(HandleParseError);
            _log.Info("Reading the input file");
            FileRead.readFile();
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            _log.Fatal("Error with options provided by the user");
            System.Environment.Exit(1);
        }
    }
}
