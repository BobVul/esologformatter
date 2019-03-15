using EsoLogFormatter.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace EsoLogFormatter.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class ConfigViewModel
    {
        public ObservableCollection<ChannelConfigViewModel> Channels { get; set; }

        private Log exampleSource;
        [AlsoNotifyFor("Channels")]
        public Log ExampleSource
        {
            set
            {
                exampleSource = value;
                foreach (var channel in Channels)
                {
                    channel.ExampleSource = value;
                }
            }
        }

        public ConfigViewModel()
        {
            Channels = new ObservableCollection<ChannelConfigViewModel>();
        }

        public void ImportLog(Log log)
        {
            foreach (var channel in log.Entries.Select(e => e.Channel).Distinct())
            {
                if (!Channels.Select(c => c.Index).Contains(channel))
                {
                    var cConfig = ChannelConfigViewModel.FromIndex(channel);
                    cConfig.ExampleSource = exampleSource;
                    Channels.Add(cConfig);
                }
            }
        }

        public Config GetConfig()
        {
            return new Config
            {
                Channels = Channels.Select(c => c.Config).ToList()
            };
        }
    }
}
