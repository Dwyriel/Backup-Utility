using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Backup_Utility
{
    static class FileManager
    {
        private static List<ManualResetEvent> MT_Events = new List<ManualResetEvent>();
        private static List<Task> Tasks = new List<Task>();

        #region Public Attributes:
        public static List<string> FilesToSave { get { return PresetManager.CurrentPreset.FilesToSave; } }
        public static List<string> FoldersToSave { get { return PresetManager.CurrentPreset.FoldersToSave; } }
        public static uint BackupNumber { get { return PresetManager.CurrentPreset.BackupNumber; } set { PresetManager.CurrentPreset.BackupNumber = value; } }
        public static bool isThereItemsToSave { get { return FilesToSave.Count > 0 || FoldersToSave.Count > 0; } }
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

        public static void RemoveFromLists(string item)
        {
            var list = FilesToSave.Contains(item) ? FilesToSave : FoldersToSave;
            int index = list.IndexOf(item);
            if (index == -1)
                return;
            list.RemoveAt(index);
        }

        public static void Clear()
        {
            FilesToSave.Clear();
            FoldersToSave.Clear();
        }

        public static bool Backup()
        {
            if (PresetManager.ConfigAndPresets.Multithreaded)
                return BackupMT();
            else
                return BackupST();
        }

        #region Backup MT:
        private static bool BackupMT()
        {
            try
            {
                MT_Events = new List<ManualResetEvent>();
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
                    Tasks.Add(new Task(() => { return; }));
                    int index = Tasks.Count - 1;
                    ThreadPool.QueueUserWorkItem(state => { File.Copy(fileInfo.FullName, backupDir.FullName + @"\" + fileInfo.Name); Tasks[(int)state].RunSynchronously(); }, index);
                }
                foreach (string folder in FoldersToSave)
                {
                    if (!Directory.Exists(folder))
                    {
                        ErrorLogger.ShowErrorText($"Folder '{folder}' doesn't exist or was deleted, skipping folder");
                        continue;
                    }
                    BackupAllInDirMT(new DirectoryInfo(folder), backupDir);
                }
                Task.WaitAll(Tasks.ToArray());
                return true;
            }
            catch (Exception exception)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage("An error occurred while backing up files.", exception, true);
                return false;
            }
        }

        private static void BackupAllInDirMT(DirectoryInfo folderToCopy, DirectoryInfo destDir)
        {
            DirectoryInfo backupDir = CreateNewFolder(destDir.FullName + @"\" + folderToCopy.Name);
            if (backupDir is null)
                return;
            FileInfo[] filesToSave = folderToCopy.GetFiles();
            DirectoryInfo[] foldersToSave = folderToCopy.GetDirectories();
            foreach (FileInfo file in filesToSave)
            {
                Tasks.Add(new Task(() => { return; }));
                int index = Tasks.Count - 1;
                ThreadPool.QueueUserWorkItem(state => { file.CopyTo(Path.Combine(backupDir.FullName, file.Name)); Tasks[(int)state].RunSynchronously(); }, index);
            }
            foreach (DirectoryInfo subDirs in foldersToSave)
                BackupAllInDirMT(subDirs, backupDir);
        }

        private static void WaitAllExt(WaitHandle[] waitHandles)
        {
            const int waitAllArrayLimit = 64;
            var prevEndIndex = -1;
            while (prevEndIndex < waitHandles.Length - 1)
            {
                var startIndex = prevEndIndex + 1;
                var endIndex = startIndex + waitAllArrayLimit - 1;
                if (endIndex > waitHandles.Length - 1)
                {
                    endIndex = waitHandles.Length - 1;
                }
                prevEndIndex = endIndex;
                WaitHandle[] trimmedWaitHandles = new WaitHandle[endIndex - startIndex + 1];
                for (int i = startIndex, i2 = 0; i <= endIndex; i++, i2++)
                {
                    trimmedWaitHandles[i2] = waitHandles[i];
                }
                WaitHandle.WaitAll(trimmedWaitHandles);
            }
        }
        #endregion

        #region Backup ST:
        private static bool BackupST()
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
                foreach (string folder in FoldersToSave)
                {
                    if (!Directory.Exists(folder))
                    {
                        ErrorLogger.ShowErrorText($"Folder '{folder}' doesn't exist or was deleted, skipping folder");
                        continue;
                    }
                    BackupAllInDirST(new DirectoryInfo(folder), backupDir);
                }
                return true;
            }
            catch (Exception exception)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage("An error occurred while backing up files.", exception, true);
                return false;
            }
        }

        private static void BackupAllInDirST(DirectoryInfo folderToCopy, DirectoryInfo destDir)
        {
            DirectoryInfo backupDir = CreateNewFolder(destDir.FullName + @"\" + folderToCopy.Name);
            if (backupDir is null)
                return;
            FileInfo[] filesToSave = folderToCopy.GetFiles();
            DirectoryInfo[] foldersToSave = folderToCopy.GetDirectories();
            foreach (FileInfo file in filesToSave)
                file.CopyTo(Path.Combine(backupDir.FullName, file.Name));
            foreach (DirectoryInfo subDirs in foldersToSave)
                BackupAllInDirST(subDirs, backupDir);
        }
        #endregion

        private static DirectoryInfo CreateNewFolder(string path)
        {
            DirectoryInfo dir = Directory.CreateDirectory(path);
            return (dir is null || dir.FullName is null) ? null : dir;
        }
        #endregion
    }
}
