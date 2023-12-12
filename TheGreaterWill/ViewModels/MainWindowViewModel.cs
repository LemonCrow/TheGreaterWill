using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using TheGreaterWill.Models;
using TheGreaterWill.ViewModels.Property;

namespace TheGreaterWill.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private JsonEditor jsonEditor;
        private SaveManager saveManager;
        private List<SaveInfoData> saveInfos;

        private string _saveName;
        private string _alertMsg;

        public ICommand SaveCommand { get; private set; }

        public List<SaveInfoData> SaveData
        {
            get { return saveInfos; }
            set
            {
                saveInfos = value;
                OnPropertyChanged(nameof(SaveData));
            }
        }

        public string SaveName
        {
            get { return _saveName; }
            set
            {
                _saveName = value;
                OnPropertyChanged(nameof(SaveName));
            }
        }

        public string AlertMsg
        {
            get { return _alertMsg; }
            set
            {
                _alertMsg = value;
                OnPropertyChanged(nameof(AlertMsg));
            }
        }

        public MainWindowViewModel()
        {
            jsonEditor = new JsonEditor();
            saveManager = new SaveManager();
            SaveData = jsonEditor.LoadJsonFile();
            SaveCommand = new RelayCommand(SaveCommandWrapper);
        }

        private void SaveCommandWrapper()
        {
            if (SaveName != null && SaveName != "")
            {
                saveManager.FileSave(SaveData, SaveName);
                AlertMsg = "";
            }
            else
                AlertMsg = "제목을 작성해주세요.";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
