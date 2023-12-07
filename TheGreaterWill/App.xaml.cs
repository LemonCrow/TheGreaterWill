using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TheGreaterWill
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Logo.xaml 윈도우 생성
            var splashScreen = new TheGreaterWill.Logo.Logo();
            splashScreen.Show();

            // 3초 대기
            System.Threading.Thread.Sleep(3000);

            // Logo.xaml 닫기
            splashScreen.Close();

            // MainWindow 표시
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
