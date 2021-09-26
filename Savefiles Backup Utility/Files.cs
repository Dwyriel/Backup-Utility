﻿using System;
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
    public partial class Files : Form
    {
        public Files()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            InitializeComponent();
        }

        #region Methods:
        private void ShowFiles()
        {
            FilesListBox.Items.Clear();
            foreach (string file in FileManager.FilePaths)
                FilesListBox.Items.Add(file);
        }

        private void SetButtonsState()
        {
            bool shouldEnable = FileManager.FilePaths.Count > 0;
            RemoveBtn.Enabled = shouldEnable;
            ClearBtn.Enabled = shouldEnable;
        }
        #endregion

        #region Events:
        private void Files_Load(object sender, EventArgs e)
        {
            BUNumberTxtBox.ReadOnly = true;
            BUNumberTxtBox.Text = FileManager.BackupNumber.ToString();
            ShowFiles();
            SetButtonsState();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog() { Multiselect = true, Title = "Select Files", CheckFileExists = true };
            fileDialog.ShowDialog(this);
            string[] selectedFiles = fileDialog.FileNames;
            foreach (string selectedFile in selectedFiles)
            {
                bool shouldAdd = true;
                foreach (string filePath in FileManager.FilePaths)
                    if (selectedFile == filePath)
                        shouldAdd = false;
                if (shouldAdd)
                    FileManager.Add(selectedFile);
            }
            PresetManager.Save();
            ShowFiles();
            SetButtonsState();
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (FilesListBox.SelectedItem is null)
                return;
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to remove this file?", "Confirm removal", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;
            FileManager.RemoveByPath((string)FilesListBox.SelectedItem);
            PresetManager.Save();
            ShowFiles();
            SetButtonsState();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to clear the file list?", "Confirm", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;
            FileManager.Clear();
            PresetManager.Save();
            ShowFiles();
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