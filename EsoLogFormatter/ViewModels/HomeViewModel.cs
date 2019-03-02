using System;
using System.Collections.Generic;
using System.Text;

namespace EsoLogFormatter.ViewModels
{
    class HomeViewModel
    {
        public FileSelectorViewModel FileSelector { get; set; }

        public HomeViewModel()
        {
            FileSelector = new FileSelectorViewModel();
        }
    }
}
