using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Savefiles_Backup_Utility
{
    static class PresetManager
    {
        #region Private Attributes:
        private static readonly string ConfigAndPresetsFileName = "SFBU_Config.xml";
        private static DirectoryInfo currentDir;
        private static string configAndPresetsFilePath;
        #endregion

        #region Public Attributes:
        public static Preset CurrentPreset { get { return ConfigAndPresets.Presets[ConfigAndPresets.CurrentPresetIndex]; } set { ConfigAndPresets.Presets[ConfigAndPresets.CurrentPresetIndex] = value; } }
        public static ConfigAndPresets ConfigAndPresets;
        #endregion

        #region Methods:
        public static void Initialize()
        {
            currentDir = new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath));
            configAndPresetsFilePath = currentDir.FullName + @"\" + ConfigAndPresetsFileName;
            bool loaded = false;
            if (File.Exists(configAndPresetsFilePath))
                loaded = Load();
            if (loaded)
                return;
            ConfigAndPresets = new ConfigAndPresets();
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
        #endregion
    }

    public class ConfigAndPresets
    {
        public bool FirstTime = true;
        public Point StartLocation;
        public string BackupFolderPath = "";
        public int CurrentPresetIndex = 0;
        public List<Preset> Presets = new List<Preset>();
    }

    public class Preset
    {
        public string PresetName;
        public ulong BackupNumber = 0;
        public List<string> FilesToSave = new List<string>();
    }
}
