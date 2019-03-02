using EsoLogFormatter.Helpers;
using EsoLogFormatter.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace EsoLogFormatter.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class HomeViewModel
    {
        public FileSelectorViewModel FileSelector { get; set; }
        public Log CurrentLog { get; set; }

        public ICommand ImportCommand { get; set; }

        public HomeViewModel()
        {
            FileSelector = new FileSelectorViewModel();

            ImportCommand = new RelayCommand(() =>
            {
                try
                {
                    CurrentLog = Log.FromFile(FileSelector.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Log parse error");
                }
            });
        }
    }
}
