using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGreaterWill.ViewModels.Property;

namespace TheGreaterWill.Models
{
    internal class SaveManager
    {
        internal bool FileSave(List<SaveInfoData> ch, string saveName)
        {
            try
            {
                if (!Directory.Exists(ch[0].ChName))
                {
                    Directory.CreateDirectory(ch[0].ChName);
                }

                DateTime now = DateTime.Now;
                string formattedData = now.ToString("yyyy-MM-dd-HH-mm-ss");

                saveName += " " + formattedData;

                string zipFilePath = Path.Combine(ch[0].ChName, saveName + ".zip");

                ZipFile.CreateFromDirectory(ch[0].ChPath, zipFilePath);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
