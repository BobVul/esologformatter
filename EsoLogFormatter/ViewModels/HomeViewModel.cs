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
        public ConfigViewModel Config { get; set; }

        public Log CurrentLog { get; set; }

        public ICommand ImportCommand { get; set; }
        public ICommand ShowTableCommand { get; set; }

        public HomeViewModel()
        {
            FileSelector = new FileSelectorViewModel();
            Config = new ConfigViewModel();

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
                Config.ExampleSource = CurrentLog;
                Config.ImportLog(CurrentLog);
            });

            ShowTableCommand = new RelayCommand(() =>
            {
                LogTableViewModel lvVM = new LogTableViewModel
                {
                    //Config = Config,
                    LogLines = CurrentLog.Entries
                };
                Window lvWindow = new LogViewerWindow
                {
                    DataContext = lvVM
                };
                lvWindow.Show();
            });
        }
    }
}
