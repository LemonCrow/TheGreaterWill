using System.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections.ObjectModel;
using TheGreaterWill.ViewModels.Property;
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using TheGreaterWill.Models;
using System.Windows.Shapes;
using System;

namespace TheGreaterWill.ViewModels
{

    public class UserInputViewModel : DependencyObject, INotifyPropertyChanged
    {
        //private int _numberOfEntries;
        private string _chPath;
        private string _chName;
        private string _alertMsg;

        JsonEditor jsonEditor = new JsonEditor();

        public event Action WindowChangeRequested;
        public event Action CloseRequested;

        public virtual void OnWindowChangeRequested()
        {
            WindowChangeRequested?.Invoke();
        }

        //public ObservableCollection<SaveInfoData> Entries { get; set; }

        public ICommand FilePathCommand { get; }

        public ICommand CreateJsonFileCommand { get; }

#region 콤보박스
        //public int NumberOfEntries
        //{
        //    get { return _numberOfEntries; }
        //    set
        //    {
        //        _numberOfEntries = value;
        //        OnPropertyChanged(nameof(NumberOfEntries));
        //        UpdateEntries(_numberOfEntries);
        //    }
        //}
        #endregion

        public string ChPath
        {
            get { return _chPath; }
            set 
            {
                _chPath = value;
                OnPropertyChanged (nameof(ChPath));
            }
        }

        public string ChName
        {
            get { return _chName; }
            set
            {
                _chName = value;
                OnPropertyChanged (nameof(ChName));
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserInputViewModel() 
        {
            ChPath = "선택 안함";
            //Entries = new ObservableCollection<SaveInfoData>();
            FilePathCommand = new RelayCommand(OpenFolderBrowserDialogWrapper);
            CreateJsonFileCommand = new RelayCommand(CreateJsonFileWrapper);
        }

        //폴더 경로 받아오기
        private void OpenFolderBrowserDialogWrapper()
        {
            ChPath = jsonEditor.OpenFolderBrowserDialog();
        }

        private void CreateJsonFileWrapper() 
        {
            
            if (ChName != null && ChPath != "선택 안함" && ChName != "")
            {
                jsonEditor.CreateJsonFile(ChName, ChPath);
                OnWindowChangeRequested();
                CloseRequested?.Invoke();
            }
            else
                AlertMsg = "공백이 존재합니다.";

        }

        #region 콤보박스
        //private void UpdateEntries(int count)
        //{
        //    Entries.Clear();
        //    for (int i = 0; i < count; i++)
        //    {
        //        Entries.Add(new SaveInfoData());
        //    }
        //}
        #endregion



    }

}
