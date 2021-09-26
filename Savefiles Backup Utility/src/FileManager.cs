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
        public static List<string> FilePaths { get { return PresetManager.CurrentPreset.FilesToSave; } }
        public static uint BackupNumber { get { return PresetManager.CurrentPreset.BackupNumber; } set { PresetManager.CurrentPreset.BackupNumber = value; } }

        public static void Add(string filePath)
        {
            FilePaths.Add(filePath);
        }

        public static void Clear()
        {
            FilePaths.Clear();
        }

        public static void RemoveByIndex(int index)
        {
            if (index < 0 || index >= FilePaths.Count)
                return;
            FilePaths.RemoveAt(index);
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
            if (FilePaths.Count < 1)
                return null;
            for (int i = 0; i < FilePaths.Count; i++)
            {
                if (FilePaths[i] == path)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
