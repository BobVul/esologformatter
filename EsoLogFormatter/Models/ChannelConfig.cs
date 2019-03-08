using System;
using System.Collections.Generic;
using System.Text;

namespace EsoLogFormatter.Models
{
    class ChannelConfig
    {
        public bool Enabled { get; set; } = true;
        public int Index { get; set; }
        public string Alias { get; set; }
        public string Type { get; set; }
    }
}
