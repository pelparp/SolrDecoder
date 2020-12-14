using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SWDecoder
{
    public class FileRead
    {
        public static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();
        public static void readFile()
        {
            try
            {
                string filetext = File.ReadAllText(Settings.infile);
                string pattern = "OrionImprovementBusinessLayer.ZipHelper.Unzip\\(\".+?\"\\)";
                int count = File.ReadAllLines(Settings.infile).Length;
                List<ReportWriter> mappings = new List<ReportWriter>();
                string[] AllLines = new string[count]; //only allocate memory here
                using (StreamReader sr = File.OpenText(Settings.infile))
                {
                    int x = 0;
                    while (!sr.EndOfStream)
                    {
                        AllLines[x] = sr.ReadLine();
                        x += 1;
                    }
                } //Finished. Close the file

                _log.Info("Searching for compressed Base64 strings. Please hold...");
                //});
                for (var i = 0; i < AllLines.Length; i++)
                {
                    //look for pattern
                    //SWDecoder.RegEx.searchRegex(AllLines[i]);
                    Regex regex = new Regex(pattern);
                    foreach (Match match in regex.Matches(AllLines[i]))
                    {
                        mappings.Add(SolrDecoder.reLookup.ReLookup(match));
                        filetext = filetext.Replace("OrionImprovementBusinessLayer.ZipHelper.Unzip(\"" + match.Value.Split('"')[1]+"\")", "\""+SolrDecoder.ZipHelper.Unzip(match.Value.Split('"')[1])+"\"");
                    }
                }
                _log.Info("Finished searching for Base64 strings. Attempting to decode now.");
                FileWrite.writeReport(mappings, Settings.outdir + "\\SolrDecodedStrings_" + Settings.epoch + ".csv", "Encoded,Decoded");
                _log.Info("Decoded Strings report located at {0}", Settings.outdir + "\\SWDecodedStrings_output_" + Settings.epoch + ".csv");
                _log.Info("Decoded CS file report located at {0}", Settings.outdir + "\\SWDecodedCS_" + Settings.epoch + ".cs");
                File.WriteAllText(Settings.outdir + "\\SWDecodedCS_" + Settings.epoch + ".cs", filetext);
            }
            catch (Exception fileRead)
            {
                _log.Error("Error: {Name}", fileRead.Message);
            }
        }

    }
}
