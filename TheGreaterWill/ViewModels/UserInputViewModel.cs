using System.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections.ObjectModel;
using TheGreaterWill.ViewModels.Property;
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace TheGreaterWill.ViewModels
{

    public class UserInputViewModel : DependencyObject, INotifyPropertyChanged
    {
        private int _numberOfEntries;
        private string _filePath;

        public ObservableCollection<SaveInfoData> Entries { get; set; }

        public ICommand FilePathCommand { get; private set; }

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

        public string FilePath 
        {
            get { return _filePath; }
            set 
            {
                _filePath = value;
                OnPropertyChanged (nameof(FilePath));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UserInputViewModel() 
        {
            
            FilePath = "선택 안함";
            Entries = new ObservableCollection<SaveInfoData>();
            FilePathCommand = new RelayCommand(OpenFolderBrowserDialog);
        }

        private void UpdateEntries(int count)
        {
            Entries.Clear();
            for (int i = 0; i < count; i++)
            {
                Entries.Add(new SaveInfoData());
            }
        }

        private void OpenFolderBrowserDialog()
        {
            Debug.WriteLine("일단 파일 메소드 테스트");
            var dialog = new OpenFileDialog
            {
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "폴더 선택", // 사용자에게 표시될 텍스트
                Filter = "Folder|*.folder", // 폴더 선택을 위한 가상 필터
                ValidateNames = false, // 파일 이름 검증 비활성화
            };

            if (dialog.ShowDialog() == true)
            {
                Debug.WriteLine("if문 테스트");
                FilePath = Path.GetDirectoryName(dialog.FileName);
            }
        }

    }

}
