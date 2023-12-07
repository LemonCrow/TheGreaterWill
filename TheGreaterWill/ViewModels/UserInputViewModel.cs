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

namespace TheGreaterWill.ViewModels
{
    public class UserInputViewModel : DependencyObject
    {
        public static readonly DependencyProperty NumberOfEntriesProperty =
            DependencyProperty.Register(
                "NumberOfEntries",
                typeof(int),
                typeof(UserInputViewModel),
                new PropertyMetadata(0, OnNumberOfEntriesChanged));

        public int NumberOfEntries
        {
            get { return (int)GetValue(NumberOfEntriesProperty); }
            set { SetValue(NumberOfEntriesProperty, value); }
        }

        private static void OnNumberOfEntriesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UserInputViewModel viewModel)
            {
                viewModel.UpdateEntries((int)e.NewValue);
            }
        }

        private void UpdateEntries(int count)
        {
            // Entries 리스트를 업데이트하는 로직
        }

        // ViewModel 클래스 내
        public ICommand SelectPathCommand => new RelayCommand(SelectPath);

        private void SelectPath()
        {
            var dialog = new OpenFileDialog();
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;
            dialog.FileName = "폴더 선택"; // 사용자에게 보여질 파일 이름 (실제 선택되지 않음)

            if (dialog.ShowDialog() == true)
            {
                var folderPath = Path.GetDirectoryName(dialog.FileName);
                // 선택된 폴더 경로를 처리합니다
            }
        }

        public ICommand NextCommand => new RelayCommand(ExecuteNext);

        private void ExecuteNext()
        {
            // '다음' 버튼의 로직을 구현합니다
        }

        // RelayCommand 클래스는 ICommand 인터페이스를 구현하는 간단한 커맨드 클래스입니다
        // 필요에 따라 구현해야 할 수도 있습니다

    }

}
