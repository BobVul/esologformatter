using EsoLogFormatter.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsoLogFormatter.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class LogTableViewModel
    {
        public Log CurrentLog { get; set; }

        public Config Config { get; set; }

        public LogTableViewModel()
        {
            CurrentLog = new Log();
        }
    }
}
