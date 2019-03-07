using EsoLogFormatter.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EsoLogFormatter.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class ChannelConfigViewModel
    {
        public ChannelConfig Config { get; set; }

        [DependsOn("Config")]
        [AlsoNotifyFor("Config")]
        public int Index
        {
            get => Config.Index;
            set => Config.Index = value;
        }
        [DependsOn("Config")]
        [AlsoNotifyFor("Config")]
        public string Alias
        {
            get => Config.Alias;
            set => Config.Alias = value;
        }
        [DependsOn("Config")]
        [AlsoNotifyFor("Config")]
        public string Type
        {
            get => Config.Type;
            set => Config.Type = value;
        }

        public Log ExampleSource { get; set; }
        [DependsOn("ExampleSource", "Config")]
        public IEnumerable<LogEntry> Examples => ExampleSource.Entries.Where(e => e.Channel == Index).Take(5);

        private ChannelConfigViewModel() { }

        public static ChannelConfigViewModel FromChannelConfig(ChannelConfig config)
        {
            return new ChannelConfigViewModel
            {
                Config = config
            };
        }

        public static ChannelConfigViewModel FromIndex(int index)
        {
            return new ChannelConfigViewModel
            {
                Config = new ChannelConfig(),
                Index = index
            };
        }
    }
}
