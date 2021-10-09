using System;
using System.IO;
using System.Collections.Generic;

namespace Savefiles_Backup_Utility
{
    static class FileManager
    {
        #region Public Attributes:
        public static List<string> FilesToSave { get { return PresetManager.CurrentPreset.FilesToSave; } }
        public static List<string> FoldersToSave { get { return PresetManager.CurrentPreset.FoldersToSave; } }
        public static uint BackupNumber { get { return PresetManager.CurrentPreset.BackupNumber; } set { PresetManager.CurrentPreset.BackupNumber = value; } }
        #endregion

        #region Methods:
        public static void AddFile(string filePath)
        {
            FilesToSave.Add(filePath);
        }

        public static void AddFolder(string folderPath)
        {
            FoldersToSave.Add(folderPath);
        }

        public static void Clear()
        {
            FilesToSave.Clear();
            FoldersToSave.Clear();
        }

        public static void RemoveFromLists(string item)
        {
            var list = FilesToSave.Contains(item) ? FilesToSave : FoldersToSave;
            int index = list.IndexOf(item);
            if (index == -1)
                return;
            list.RemoveAt(index);
        }

        public static bool Backup()//todo redo logic to also save folders and any files and folders inside
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
        #endregion
    }
}
