﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Win32;
using TheGreaterWill.ViewModels.Property;

namespace TheGreaterWill.Models
{
    internal class JsonEditor
    {
        internal string OpenFolderBrowserDialog()
        {
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
                if (Path.GetDirectoryName(dialog.FileName) == null)
                    return "선택 안함";
                else
                    return Path.GetDirectoryName(dialog.FileName);

            }
            return "선택 안함";
        }

        internal string CreateJsonFile(string chName, string chPath)
        {
            try
            {
                var saveData = new List<SaveInfoData>
            {
                new SaveInfoData { ChName = chName, ChPath = chPath }
            };

                string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("ChSaveData.json", json);

                return "저장 완료";
            }
            catch (Exception ex)
            {
                return "저장 실패";
            }
            
        }


    }

}