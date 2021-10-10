using System;
using System.IO;
using System.Windows.Forms;

namespace Backup_Utility
{
    public partial class Files : Form
    {
        #region Attributes:
        static readonly string filesItem = "Files:";
        static readonly string foldersItem = "Folders:";
        #endregion

        #region Constructor:
        public Files()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Icon = Properties.Resources.icon;
            InitializeComponent();
        }
        #endregion

        #region Methods:
        private void ShowItems()
        {
            FilesListBox.Items.Clear();
            FilesListBox.Items.Add(filesItem);
            foreach (string file in FileManager.FilesToSave)
                FilesListBox.Items.Add(file);
            FilesListBox.Items.Add(foldersItem);
            foreach (string folder in FileManager.FoldersToSave)
                FilesListBox.Items.Add(folder);
        }

        private void SetButtonsState()
        {
            bool shouldEnable = FileManager.isThereItemsToSave;
            RemoveBtn.Enabled = shouldEnable;
            ClearBtn.Enabled = shouldEnable;
        }
        #endregion

        #region Events:
        private void Files_Load(object sender, EventArgs e)
        {
            BUNumberTxtBox.ReadOnly = true;
            BUNumberTxtBox.Text = FileManager.BackupNumber.ToString();
            ShowItems();
            SetButtonsState();
        }

        private void AddFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { Multiselect = true, Title = "Select Files", CheckFileExists = true };
            fileDialog.ShowDialog(this);
            string[] selectedFiles = fileDialog.FileNames;
            foreach (string selectedFile in selectedFiles)
            {
                bool shouldAdd = true;
                foreach (string filePath in FileManager.FilesToSave)
                    if (selectedFile == filePath)
                    {
                        shouldAdd = false;
                        break;
                    }
                if (shouldAdd)
                    FileManager.AddFile(selectedFile);
            }
            PresetManager.Save();
            ShowItems();
            SetButtonsState();
        }

        private void AddFolderBtn_Click(object sender, EventArgs e)
        {
            CustomFolderPicker customFolderPicker = new CustomFolderPicker() { Title = "Select Folder" };
            customFolderPicker.ShowDialog(Handle);
            string folderPath = customFolderPicker.ResultPath;
            if (folderPath is null)
                return;
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Must be a valid folder path", "Invalid path");
                return;
            }
            bool shouldAdd = true;
            foreach (string folder in FileManager.FoldersToSave)
                if (folderPath == folder)
                {
                    shouldAdd = false;
                    break;
                }
            if (shouldAdd)
                FileManager.AddFolder(folderPath);
            PresetManager.Save();
            ShowItems();
            SetButtonsState();
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (FilesListBox.SelectedItem is null)
                return;
            string selectedItem = FilesListBox.SelectedItem.ToString();
            if (selectedItem.Equals(filesItem) || selectedItem.Equals(foldersItem))
                return;
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to remove this item?", "Confirm removal", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;
            FileManager.RemoveFromLists(selectedItem);
            PresetManager.Save();
            ShowItems();
            SetButtonsState();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear the list?", "Confirm", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;
            FileManager.Clear();
            PresetManager.Save();
            ShowItems();
            SetButtonsState();
        }

        private void BUNumberEditCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BUNumberTxtBox.ReadOnly = !BUNumberEditCheckBox.Checked;
        }

        private void BUNumberTxtBox_Leave(object sender, EventArgs e)
        {
            if (BUNumberTxtBox.ReadOnly)
                return;
            if (uint.TryParse(BUNumberTxtBox.Text, out uint backupNumber))
            {
                FileManager.BackupNumber = backupNumber;
                return;
            }
            ErrorLogger.ShowErrorText("Backup Number must be a positive number");
            BUNumberTxtBox.Focus();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            PresetManager.Save();
            Close();
        }
        #endregion
    }
}
