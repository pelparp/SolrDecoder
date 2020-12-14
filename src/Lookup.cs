using SWDecoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolrDecoder
{
    public class reLookup
    {
        public static ReportWriter ReLookup(Match match)
        {
            ReportWriter record = new ReportWriter();
            try
            {
                record.Base64Encoded = match.Value.Split('"')[1];
                record.Base64Decoded = SolrDecoder.ZipHelper.Unzip(match.Value.Split('"')[1]);
                return record;
            }
            catch
            {
                return record;
            }
        }
    }
}
