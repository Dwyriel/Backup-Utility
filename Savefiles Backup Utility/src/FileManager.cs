using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Savefiles_Backup_Utility
{
    static class FileManager
    {
        public static List<string> FilesToSave { get { return PresetManager.CurrentPreset.FilesToSave; } }
        public static uint BackupNumber { get { return PresetManager.CurrentPreset.BackupNumber; } set { PresetManager.CurrentPreset.BackupNumber = value; } }

        public static void Add(string filePath)
        {
            FilesToSave.Add(filePath);
        }

        public static void Clear()
        {
            FilesToSave.Clear();
        }

        public static void RemoveByIndex(int index)
        {
            if (index < 0 || index >= FilesToSave.Count)
                return;
            FilesToSave.RemoveAt(index);
        }

        public static void RemoveByPath(string path)
        {
            int? index = IndexOf(path);
            if (index is null)
                return;
            RemoveByIndex((int)index);
        }

        private static int? IndexOf(string path)
        {
            if (FilesToSave.Count < 1)
                return null;
            for (int i = 0; i < FilesToSave.Count; i++)
            {
                if (FilesToSave[i] == path)
                {
                    return i;
                }
            }
            return null;
        }

        public static bool Backup()
        {
            try
            {
                DirectoryInfo presetDir = CreateNewFolder(PresetManager.ConfigAndPresets.BackupFolderPath + @"\" + PresetManager.CurrentPreset.PresetName);
                if (presetDir is null)
                    return false;
                DirectoryInfo backupDir = CreateNewFolder(presetDir.FullName + @"\" + "Backup " + PresetManager.CurrentPreset.BackupNumber++.ToString());
                if (backupDir is null)
                    return false;
                foreach (string file in FilesToSave)
                {
                    if (!File.Exists(file))
                    {
                        ErrorLogger.ShowErrorText($"File '{file}' doesn't exist or was deleted, skipping file");
                        continue;
                    }
                    FileInfo fileInfo = new FileInfo(file);
                    File.Copy(fileInfo.FullName, backupDir.FullName + @"\" + fileInfo.Name);
                }
                return true;
            }
            catch (Exception exception)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage("An error occurred while backing up files.", exception);
                return false;
            }
        }

        private static DirectoryInfo CreateNewFolder(string path)
        {
            DirectoryInfo dir = Directory.CreateDirectory(path);
            return (dir is null || dir.FullName is null) ? null : dir;
        }
    }
}
