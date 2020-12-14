using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace SWDecoder
{
    class FileWrite
    {
        //we don't really need read-write locks here but adding it for future feature implementations 
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();
        public static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();
        public static void writeReport(List<ReportWriter> outcsv,string outpath, string header)
        {
            try
            {
                _readWriteLock.EnterWriteLock();
                if (!File.Exists(outpath))
                {
                    File.AppendAllText(outpath, header + Environment.NewLine);
                }
                using (var stream = File.Open(outpath, System.IO.FileMode.Append))
                using (var writer = new System.IO.StreamWriter(stream, Encoding.UTF8))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    csv.WriteRecords(outcsv);
                }
            }
            catch (Exception writer)
            {
                _log.Error("Error writing Report {name}", writer.Message);
            }
            finally
            {
                // Release lock
                _readWriteLock.ExitWriteLock();
            }

        }
    }
}
