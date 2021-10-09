using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backup_Utility
{
    public partial class MainWindow : Form
    {
        #region Attributes:
        Timer timer = null;
        bool BackupInProgress = false;
        bool WasBackupSuccess = false;
        #endregion

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
            Icon = Properties.Resources.icon;
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
            if (!PresetManager.ConfigFileExists)
                return;
            Location = PresetManager.ConfigAndPresets.StartLocation;
        }

        private void SetBackupFolderStartingValue()
        {
            backupFolderTxtBox.Text = PresetManager.ConfigAndPresets.BackupFolderPath ?? "";
        }

        private void CheckForPreset()
        {
            FilesBtn.Enabled = PresetManager.ConfigAndPresets.Presets.Count > 0;
        }

        private bool CheckBackupFolder()
        {
            if (PresetManager.ConfigAndPresets.BackupFolderPath == "" || PresetManager.ConfigAndPresets.BackupFolderPath is null)
            {
                MessageBox.Show("Backup folder can't be empty.", "Invalid Backup Folder");
                return false;
            }
            if (!Directory.Exists(PresetManager.ConfigAndPresets.BackupFolderPath))
            {
                MessageBox.Show("Backup Folder must be a valid folder path", "Invalid Backup Folder");
                return false;
            }
            return true;
        }

        private void ShowStatusLabel(string status)
        {
            StatusLabel.Text = status;
            StatusLabel.Visible = true;
        }

        private void HideStatusLabelTimer(string status)
        {
            StatusLabel.Text = status;
            if (timer is null)
            {
                timer = new Timer();
                timer.Tick += Timer_Tick;
            }
            if (timer.Enabled)
                timer.Stop();
            timer.Interval = 5000;
            timer.Start();
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
            CheckForPreset();
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
            if (!PresetManager.CheckIfNameIsValid(inputForm.Input))
            {
                MessageBox.Show(@"Preset name cannot contain any of the following characters: \ / : * ? " + '"' + " < > | ", "Invalid Name");
                return;
            }
            PresetManager.AddNewPreset(inputForm.Input);
            inputForm.Dispose();
            SetPresetsComboBox();
            PresetManager.Save();
            CheckForPreset();
        }

        private void deletePresetBtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this preset?", "Confirm deletion", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;
            PresetManager.RemovePresetAtCurrentIndex();
            SetPresetsComboBox();
            PresetManager.Save();
            CheckForPreset();
        }

        private void presetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PresetManager.SetCurrentIndex((string)presetComboBox.SelectedItem);
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
        private void FilesBtn_Click(object sender, EventArgs e)
        {
            Files filesForm = new Files() { Text = $"{PresetManager.CurrentPreset.PresetName} - Files" };
            filesForm.ShowDialog(this);
        }
        #endregion

        #region Backup:
        private async void BackupBtn_Click(object sender, EventArgs e)
        {
            if (BackupInProgress)
            {
                ShowStatusLabel("Not done yet baka!");
                return;
            }
            BackupInProgress = true;
            ShowStatusLabel("Working on it..");
            if (!CheckBackupFolder())
            {
                HideStatusLabelTimer("Failed");
                return;
            }
            if (FileManager.FilesToSave.Count < 1)
            {
                MessageBox.Show("No files to backup, Select files first");
                HideStatusLabelTimer("Failed");
                return;
            }
            await Task.Factory.StartNew(() =>
            {
                WasBackupSuccess = FileManager.Backup();
                BackupInProgress = false;
            }, TaskCreationOptions.LongRunning);
            HideStatusLabelTimer(WasBackupSuccess ? "Done!" : "Failed");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (BackupInProgress)
                return;
            StatusLabel.Visible = false;
            timer.Stop();
        }
        #endregion
        #endregion
    }
}
