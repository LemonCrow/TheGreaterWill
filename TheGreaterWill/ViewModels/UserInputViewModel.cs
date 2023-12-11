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

namespace TheGreaterWill.ViewModels
{

    public class UserInputViewModel : DependencyObject, INotifyPropertyChanged
    {
        //private int _numberOfEntries;
        private string _chPath;

        JsonEditor jsonEditor = new JsonEditor();

        //public ObservableCollection<SaveInfoData> Entries { get; set; }

        public ICommand FilePathCommand { get; private set; }

        

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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserInputViewModel() 
        {
            ChPath = "선택 안함";
            jsonEditor.CreateJsonFile("test", "123");
            //Entries = new ObservableCollection<SaveInfoData>();
            FilePathCommand = new RelayCommand(OpenFolderBrowserDialogWrapper);
        }

        //폴더 경로 받아오기
        private void OpenFolderBrowserDialogWrapper()
        {
            ChPath = jsonEditor.OpenFolderBrowserDialog();
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
