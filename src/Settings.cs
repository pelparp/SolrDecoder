using System;
using System.Collections.Generic;
using System.Text;

namespace SWDecoder
{
    public class Settings
    {
        public static string infile;
        public static string outdir;
        public static string epoch = DateTime.Now.ToUniversalTime().ToString("yyyyMMdd_HHmmss");
    }
    public class ReportWriter
    {
        public string Base64Encoded { get; set; }
        public string Base64Decoded { get; set; }
    }
}
