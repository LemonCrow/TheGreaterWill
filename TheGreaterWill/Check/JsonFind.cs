using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreaterWill.Check
{
    class JsonFind
    {
        public JsonFind() 
        {
            
        }


        //설정파일 존재하는지 확인 없으면 InsertId.xaml로 보낼 것 있어도 일단은 MainWindow.xaml로 바로 보냄 추후 json내용 가공해서 같이 보낼 것
        public bool CheckJsonFile()
        {
            var infoFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveInfo.json");

            Debug.WriteLine(infoFilePath);

            if (!File.Exists(infoFilePath))
            {
                return false;   
            }
            else
            {
                return true;
            }
        }
    }
}
