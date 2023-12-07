using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace TheGreaterWill
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow mainWindow;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Logo.xaml 윈도우 생성
            var splashScreen = new TheGreaterWill.Logo.Logo();
            splashScreen.Show();

            // 3초 대기
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            timer.Tick += (s, args) =>
            {
                timer.Stop();

                mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                splashScreen.Close();
            };
            timer.Start();
        }
    }
}
