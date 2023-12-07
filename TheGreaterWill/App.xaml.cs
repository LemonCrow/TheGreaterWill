using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TheGreaterWill.Check;

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

                bool isSaveInfo = new TheGreaterWill.Check.JsonFind().CheckJsonFile();

                //여기서 파일 있는지 체크해서 해당 행동 해주면됨 추후 수정 
                if (isSaveInfo)
                {
                    mainWindow = new MainWindow();
                    Application.Current.MainWindow = mainWindow;
                    mainWindow.Show();
                }
                else
                {
                    InsertInfo insertInfo = new InsertInfo();
                    Application.Current.MainWindow = insertInfo;
                    insertInfo.Show();
                }
                splashScreen.Close();
            };
            timer.Start();
        }
    }
}
