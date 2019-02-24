﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace EsoLogFormatter.Models
{
    class LogEntry
    {
        public DateTimeOffset TimeStamp { get; private set; }

        public int Channel { get; private set; }

        public string Text { get; private set; }

        private LogEntry() { }

        private static readonly Regex logRegex = new Regex(@"^(?<timestamp>[^ ]+) (?<channel>\d+),(?<text>.*)$", RegexOptions.Compiled);
        public static LogEntry FromLogRow(string row)
        {
            var match = logRegex.Match(row);

            return new LogEntry
            {
                TimeStamp = DateTimeOffset.ParseExact(match.Groups["timestamp"].Value, "K", CultureInfo.InvariantCulture),
                Channel = Int32.Parse(match.Groups["channel"].Value),
                Text = match.Groups["text"].Value
            };
        }
    }
}