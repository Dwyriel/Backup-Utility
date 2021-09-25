using System;
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
            PresetManager.Initialize();
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
            foreach (Preset preset in PresetManager.ConfigAndPresets.presets)
                presetComboBox.Items.Add(preset.presetName);
            if (presetComboBox.Items.Count > 0)
                presetComboBox.SelectedIndex = PresetManager.ConfigAndPresets.currentPresetIndex;
        }
        #endregion

        #region Events:
        private void MainWindow_Load(object sender, EventArgs e)
        {
            SetPresetsComboBox();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            PresetManager.Save();
        }

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
        }

        private void presetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PresetManager.SetCurrentIndex((string)presetComboBox.SelectedItem);
            //todo show changed variables to user
        }
        #endregion

        private void backupFolderSearchBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
