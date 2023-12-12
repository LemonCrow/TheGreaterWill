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

        internal bool FileLoad(List<SaveInfoData> ch, string saveName)
        {
            try
            {
                if (!Directory.Exists(ch[0].ChName))
                {
                    return false;
                }

                string zipFilePath = Path.Combine(ch[0].ChName, saveName);

                var encoding = Encoding.UTF8;

                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string destinationPath = Path.GetFullPath(Path.Combine(ch[0].ChPath, entry.FullName));

                        if (destinationPath.StartsWith(ch[0].ChPath, StringComparison.Ordinal))
                        {
                            entry.ExtractToFile(destinationPath, true);
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
