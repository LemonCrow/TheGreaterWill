using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;
using TheGreaterWill.ViewModels.Property;
using System.Diagnostics;
using System.ComponentModel;

namespace TheGreaterWill.ViewModels
{

    public class UserInputViewModel : DependencyObject
    {
        private int _numberOfEntries;

        public ObservableCollection<SaveInfoData> Entries { get; set; }

        public int NumberOfEntries
        {
            get { return _numberOfEntries; }
            set
            {
                _numberOfEntries = value;
                OnPropertyChanged(nameof(NumberOfEntries));
                UpdateEntries(_numberOfEntries);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserInputViewModel() 
        { 
            Entries = new ObservableCollection<SaveInfoData>();
        }

        private void UpdateEntries(int count)
        {
            Entries.Clear();
            for (int i = 0; i < count; i++)
            {
                Entries.Add(new SaveInfoData());
            }
        }


    }

}
