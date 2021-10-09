using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Backup_Utility
{
    static class PresetManager
    {
        #region Private Attributes:
        private static readonly string ConfigAndPresetsFileName = "Savefiles Backup Utility.ini";
        private static DirectoryInfo currentDir;
        private static string configAndPresetsFilePath;
        #endregion

        #region Public Attributes:
        public static Preset CurrentPreset { get { return ConfigAndPresets.Presets[ConfigAndPresets.CurrentPresetIndex]; } set { ConfigAndPresets.Presets[ConfigAndPresets.CurrentPresetIndex] = value; } }
        public static ConfigAndPresets ConfigAndPresets;
        public static bool ConfigFileExists { get { return File.Exists(configAndPresetsFilePath); } }
        public static bool PresetsExist { get { return ConfigAndPresets.Presets.Count > 0; } }
        #endregion

        #region Methods:
        public static void Initialize()
        {
            currentDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath));
            configAndPresetsFilePath = currentDir.FullName + @"\" + ConfigAndPresetsFileName;
            bool loaded = false;
            if (ConfigFileExists)
                loaded = Load();
            if (loaded)
            {
                CheckFilesIntegrity();
                return;
            }
            ConfigAndPresets = new ConfigAndPresets();
        }

        public static void CheckFilesIntegrity()
        {
            foreach (Preset preset in ConfigAndPresets.Presets)
            {
                List<string> newFilePathList = new List<string>();
                List<string> deletedFilePaths = new List<string>();
                List<string> newFolderPathList = new List<string>();
                List<string> deletedFolderPaths = new List<string>();
                bool fileDidntExist = false;
                foreach (string file in preset.FilesToSave)
                {
                    if (!File.Exists(file))
                    {
                        fileDidntExist = true;
                        deletedFilePaths.Add(file);
                        continue;
                    }
                    newFilePathList.Add(file);
                }
                bool folderDidntExist = false;
                foreach (string folder in preset.FoldersToSave)
                {
                    if (!Directory.Exists(folder))
                    {
                        folderDidntExist = true;
                        deletedFolderPaths.Add(folder);
                        continue;
                    }
                    newFolderPathList.Add(folder);
                }
                if (fileDidntExist || folderDidntExist)
                {
                    string deletedItems = Environment.NewLine + Environment.NewLine + "Deleted Items:";
                    foreach (string file in deletedFilePaths)
                        deletedItems += Environment.NewLine + file;
                    foreach (string folder in deletedFolderPaths)
                        deletedItems += Environment.NewLine + folder;
                    ErrorLogger.ShowErrorText($"One or more items in '{preset.PresetName}' preset don't exist or were deleted and were removed from the list" + deletedItems, true);
                    preset.FilesToSave = newFilePathList;
                    preset.FoldersToSave = newFolderPathList;
                }
            }
        }

        public static bool Load()
        {
            XmlSerializer format = new XmlSerializer(typeof(ConfigAndPresets));
            FileStream inFile = new FileStream(configAndPresetsFilePath, FileMode.Open);
            try
            {
                byte[] buffer = new byte[inFile.Length];
                inFile.Read(buffer, 0, (int)inFile.Length);
                MemoryStream stream = new MemoryStream(buffer);
                ConfigAndPresets = (ConfigAndPresets)format.Deserialize(stream);
                return true;
            }
            catch (Exception e)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage($"An error occurred while reading {ConfigAndPresetsFileName}, check {ErrorLogger.ErrorLogFileName} file.", e, true);
                return false;
            }
            finally
            {
                inFile.Close();
            }
        }

        public static void Save()
        {
            FileStream outFile = File.Create(configAndPresetsFilePath);
            try
            {
                XmlSerializer format = new XmlSerializer(typeof(ConfigAndPresets));
                format.Serialize(outFile, ConfigAndPresets);
            }
            catch (Exception e)
            {
                ErrorLogger.ShowErrorTextWithExceptionMessage($"An error occurred while saving presets, check {ErrorLogger.ErrorLogFileName} file.", e, true);
            }
            finally
            {
                outFile.Close();
            }
        }

        public static void SetCurrentIndex(string presetName)
        {
            for (int i = 0; i < ConfigAndPresets.Presets.Count; i++)
            {
                if (ConfigAndPresets.Presets[i].PresetName == presetName)
                {
                    ConfigAndPresets.CurrentPresetIndex = i;
                    return;
                }
            }
        }

        public static void AddNewPreset(string presetName)
        {
            ConfigAndPresets.Presets.Add(new Preset() { PresetName = presetName });
            ConfigAndPresets.CurrentPresetIndex = ConfigAndPresets.Presets.Count - 1;
        }

        public static void RemovePresetAtCurrentIndex()
        {
            if (ConfigAndPresets.Presets.Count < 1)
                return;
            ConfigAndPresets.Presets.RemoveAt(ConfigAndPresets.CurrentPresetIndex);
            ConfigAndPresets.CurrentPresetIndex = 0;
        }

        public static bool CheckIfNameIsValid(string name)
        {
            if (name.Contains(@"\") || name.Contains(@"/") || name.Contains(@":") || name.Contains(@"*") || name.Contains(@"?") || name.Contains('"'.ToString()) || name.Contains(@"<") || name.Contains(@">") || name.Contains(@"|"))
                return false;
            return true;
        }
        #endregion
    }

    public class ConfigAndPresets
    {
        public Point StartLocation;
        public bool Multithreaded = true;
        public string BackupFolderPath = "";
        public int CurrentPresetIndex = 0;
        public List<Preset> Presets = new List<Preset>();
    }

    public class Preset
    {
        public string PresetName;
        public uint BackupNumber = 1;
        public List<string> FilesToSave = new List<string>();
        public List<string> FoldersToSave = new List<string>();
    }
}
