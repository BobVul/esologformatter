using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsoLogFormatter.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class ConfigViewModel
    {
        public ColumnConfigViewModel ColumnConfig { get; set; }

        public ConfigViewModel()
        {
            ColumnConfig = new ColumnConfigViewModel();
        }
    }
}
