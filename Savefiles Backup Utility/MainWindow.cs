using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savefiles_Backup_Utility
{
    public partial class MainWindow : Form
    {
        #region Constroctor:
        public MainWindow()
        {
            InitializeComponent();
            SetStartAttributes();
        }
        #endregion

        #region Methods:
        private void SetStartAttributes()
        {
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            //Icon = Properties.Resources.Icon;
        }

        private void SetPresetsComboBox()
        {
            presetComboBox.Items.Clear();
            foreach (Preset preset in PresetManager.ConfigAndPresets.Presets)
                presetComboBox.Items.Add(preset.PresetName);
            if (presetComboBox.Items.Count > 0)
                presetComboBox.SelectedIndex = PresetManager.ConfigAndPresets.CurrentPresetIndex;
        }

        private void SetStartLocation()
        {
            if (PresetManager.ConfigAndPresets.FirstTime)
            {
                PresetManager.ConfigAndPresets.FirstTime = false;
                return;
            }
            Location = PresetManager.ConfigAndPresets.StartLocation;
        }

        private void SetBackupFolderStartingValue()
        {
            backupFolderTxtBox.Text = PresetManager.ConfigAndPresets.BackupFolderPath ?? "";
        }
        #endregion

        #region Events:
        #region Form Events:
        private void MainWindow_Load(object sender, EventArgs e)
        {
            PresetManager.Initialize();
            SetStartLocation();
            SetBackupFolderStartingValue();
            SetPresetsComboBox();

            BackupBtn.Select();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            PresetManager.ConfigAndPresets.StartLocation = Location;
            PresetManager.Save();
        }
        #endregion

        #region Preset Events:
        private void newPresetBtn_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm() { description = "Name your new Preset:", title = "Preset" };
            inputForm.ShowDialog(this);
            if (inputForm.DialogResult != DialogResult.OK)
                return;
            PresetManager.AddNewPreset(inputForm.Input);
            SetPresetsComboBox();
            PresetManager.Save();
            inputForm.Dispose();
        }

        private void deletePresetBtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this preset?", "Confirm deletion", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;
            PresetManager.RemovePresetAtCurrentIndex();
            SetPresetsComboBox();
            PresetManager.Save();
        }

        private void presetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PresetManager.SetCurrentIndex((string)presetComboBox.SelectedItem);
            //todo show changed variables to user
        }
        #endregion

        #region Backup Folder Events:
        private void backupFolderTxtBox_Leave(object sender, EventArgs e)
        {
            if (backupFolderTxtBox.Text is null || backupFolderTxtBox.Text == "")
            {
                PresetManager.ConfigAndPresets.BackupFolderPath = backupFolderTxtBox.Text;
                return;
            }
            if (!Directory.Exists(backupFolderTxtBox.Text))
            {
                MessageBox.Show("Must be a valid folder path", "Invalid path");
                backupFolderTxtBox.Focus();
                return;
            }
            PresetManager.ConfigAndPresets.BackupFolderPath = backupFolderTxtBox.Text;
        }

        private void backupFolderSearchBtn_Click(object sender, EventArgs e)
        {
            CustomFolderPicker customFolderPicker = new CustomFolderPicker() { Title = "Select Backup Folder" };
            customFolderPicker.ShowDialog(Handle);
            string resultPath = customFolderPicker.ResultPath;
            if (resultPath is null)
                return;
            if (!Directory.Exists(resultPath))
            {
                MessageBox.Show("Must be a valid folder path", "Invalid path");
                return;
            }
            backupFolderTxtBox.Text = resultPath;
            PresetManager.ConfigAndPresets.BackupFolderPath = resultPath;
            PresetManager.Save();
        }
        #endregion

        #region Files:
        private void button1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Backup:
        private void BackupBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #endregion
    }
}
