using EsoLogFormatter.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Linq;

namespace EsoLogFormatter.BindingValueConverters
{
    [ValueConversion(typeof(int), typeof(string))]
    class IndexAliasConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty ConfigProperty = DependencyProperty.Register("Config", typeof(Config), typeof(IndexAliasConverter),
            new PropertyMetadata(new PropertyChangedCallback(OnConfigChanged)));
        public Config Config
        {
            get => (Config)GetValue(ConfigProperty);
            set => SetValue(ConfigProperty, value);
        }

        private Dictionary<int, ChannelConfig> ChannelMap { get; set; }

        private static void OnConfigChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var me = (IndexAliasConverter)d;
            var newVal = (Config)e.NewValue;

            me.ChannelMap = newVal.Channels.ToDictionary(c => c.Index);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (ChannelMap == null)
            {
                return "";
            }
            var val = (int)value;
            return ChannelMap[val].Alias;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
