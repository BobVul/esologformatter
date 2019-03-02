using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EsoLogFormatter.Models
{
    class Log
    {
        public List<LogEntry> Entries { get; set; }

        public Log()
        {
            Entries = new List<LogEntry>();
        }

        public static Log FromFile(string filePath)
        {
            var log = new Log();

            foreach (var line in File.ReadLines(filePath))
            {
                log.Entries.Add(LogEntry.FromLogRow(line));
            }

            return log;
        }
    }
}
