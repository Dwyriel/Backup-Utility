using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Savefiles_Backup_Utility
{
    static class PresetManager
    {
        #region Private Attributes:
        private static readonly string presetsFileName = "SFBU_Config.xml";
        private static DirectoryInfo currentDir;
        private static string presetFilePath;
        #endregion

        #region Public Attributes:
        public static Preset CurrentPreset { get { return ConfigAndPresets.presets[ConfigAndPresets.currentPresetIndex]; } set { ConfigAndPresets.presets[ConfigAndPresets.currentPresetIndex] = value; } }
        public static ConfigAndPresets ConfigAndPresets;
        #endregion

        #region Methods:
        public static void Initialize()
        {
            currentDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath));
            presetFilePath = currentDir.FullName + @"\" + presetsFileName;
            bool loaded = false;
            if (File.Exists(presetFilePath))
                loaded = Load();
            if (loaded)
                return;
            ConfigAndPresets = new ConfigAndPresets();
        }

        public static bool Load()
        {
            XmlSerializer format = new XmlSerializer(typeof(ConfigAndPresets));
            FileStream inFile = new FileStream(presetFilePath, FileMode.Open);
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
                ErrorLogger.ShowErrorTextWithExceptionMessage($"An error occurred while reading {presetsFileName}, check {ErrorLogger.ErrorLogFileName} file.", e, true);
                return false;
            }
            finally
            {
                inFile.Close();
            }
        }

        public static void Save()
        {
            FileStream outFile = File.Create(presetFilePath);
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
            for (int i = 0; i < ConfigAndPresets.presets.Count; i++)
            {
                if (ConfigAndPresets.presets[i].presetName == presetName)
                {
                    ConfigAndPresets.currentPresetIndex = i;
                    return;
                }
            }
        }

        public static void AddNewPreset(string presetName)
        {
            ConfigAndPresets.presets.Add(new Preset() { presetName = presetName });
            ConfigAndPresets.currentPresetIndex = ConfigAndPresets.presets.Count - 1;
        }

        public static void RemovePresetAtCurrentIndex()
        {
            if (ConfigAndPresets.presets.Count < 1)
                return;
            ConfigAndPresets.presets.RemoveAt(ConfigAndPresets.currentPresetIndex);
            ConfigAndPresets.currentPresetIndex = 0;
        }
        #endregion
    }

    public class ConfigAndPresets
    {
        public List<Preset> presets = new List<Preset>();
        public string backupFolderPath = "";
        public int currentPresetIndex = 0;
    }

    public class Preset
    {
        public string presetName;
        public List<string> filesToSave = new List<string>();
        public ulong backupNumber = 0;
    }
}
