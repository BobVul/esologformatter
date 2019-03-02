using EsoLogFormatter.Helpers;
using Microsoft.Win32;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace EsoLogFormatter.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class FileSelectorViewModel
    {
        public string FileName { get; set; }
        public ICommand BrowseCommand { get; set; }

        public FileSelectorViewModel()
        {
            BrowseCommand = new RelayCommand(() =>
            {
                var dialog = new OpenFileDialog
                {
                    FileName = this.FileName
                };

                if (dialog.ShowDialog().GetValueOrDefault(false))
                {
                    this.FileName = dialog.FileName;
                }
            });
        }
    }
}
