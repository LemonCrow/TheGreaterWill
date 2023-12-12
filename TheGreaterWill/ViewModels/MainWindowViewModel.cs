using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGreaterWill.Models;
using TheGreaterWill.ViewModels.Property;

namespace TheGreaterWill.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private JsonEditor jsonEditor;
        private List<SaveInfoData> saveInfos;

        public List<SaveInfoData> SaveData
        {
            get { return saveInfos; }
            set
            {
                saveInfos = value;
                OnPropertyChanged(nameof(SaveData));
            }
        }

        public MainWindowViewModel()
        {
            jsonEditor = new JsonEditor();
            SaveData = jsonEditor.LoadJsonFile();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
