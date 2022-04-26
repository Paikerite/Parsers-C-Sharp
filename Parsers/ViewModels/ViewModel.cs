﻿using Parsers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Windows;

namespace Parsers.ViewModels
{
    // INotifyPropertyChanged notifies the View of property changes, so that Bindings are updated.
    public class ViewModel : INotifyPropertyChanged
    {
        private Content content;
        public ViewModel()
        {
            content = new Content
            {
                Result = "",
                Path = ""
            };
        }

        public string Result
        {
            get { return content.Result; }
            set { content.Result = value; OnPropertyChange(nameof(Result)); }
        }

        public string Path
        {
            get { return content.Path; }
            set { content.Path = value; OnPropertyChange(nameof(Path)); }
        }

        //private RelayCommand readFCommand;
        //public RelayCommand ReadFCommand
        //{
        //    get { return readFCommand ??= new RelayCommand(obj =>
        //            {
        //                if (!string.IsNullOrEmpty(Path))
        //                {
        //                    string text = File.ReadAllText(Path);
        //                    Result = text;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("File directory is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //                }
        //            });}
        //}

        //ReadAndParseFile
        private RelayCommand readFCommand;
        public RelayCommand ReadFCommand
        {
            get { return readFCommand ??= new RelayCommand(obj =>
                    {
                        Result = content.ReadAndParseFile(Path);
                    });}
        }

        private RelayCommand browseFCommand;
        public RelayCommand BrowseFCommand
        {
            get
            {
                return browseFCommand ??= new RelayCommand(obj =>
                {
                    Path = content.BtnClickBrowse();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
