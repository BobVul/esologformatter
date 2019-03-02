using EsoLogFormatter.Helpers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EsoLogFormatter.ViewModels
{
    class FileSelectorViewModel
    {
        public string FileName { get; set; }
        public ICommand BrowseCommand { get; set; }

        public FileSelectorViewModel()
        {
            BrowseCommand = new RelayCommand(() =>
            {
                var dialog = new OpenFileDialog();
                dialog.ShowDialog();
            });
        }
    }
}
