
namespace Backup_Utility
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.presetComboBox = new System.Windows.Forms.ComboBox();
            this.newPresetBtn = new System.Windows.Forms.Button();
            this.deletePresetBtn = new System.Windows.Forms.Button();
            this.presetLabel = new System.Windows.Forms.Label();
            this.backupFolderTxtBox = new System.Windows.Forms.TextBox();
            this.backupFolderLabel = new System.Windows.Forms.Label();
            this.backupFolderSearchBtn = new System.Windows.Forms.Button();
            this.BackupBtn = new System.Windows.Forms.Button();
            this.FilesBtn = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionsMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultithreadedSubmenuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // presetComboBox
            // 
            this.presetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.presetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetComboBox.FormattingEnabled = true;
            this.presetComboBox.Location = new System.Drawing.Point(27, 52);
            this.presetComboBox.Name = "presetComboBox";
            this.presetComboBox.Size = new System.Drawing.Size(227, 26);
            this.presetComboBox.TabIndex = 0;
            this.presetComboBox.SelectedIndexChanged += new System.EventHandler(this.presetComboBox_SelectedIndexChanged);
            // 
            // newPresetBtn
            // 
            this.newPresetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPresetBtn.Location = new System.Drawing.Point(260, 52);
            this.newPresetBtn.Name = "newPresetBtn";
            this.newPresetBtn.Size = new System.Drawing.Size(68, 26);
            this.newPresetBtn.TabIndex = 1;
            this.newPresetBtn.Text = "New";
            this.newPresetBtn.UseVisualStyleBackColor = true;
            this.newPresetBtn.Click += new System.EventHandler(this.newPresetBtn_Click);
            // 
            // deletePresetBtn
            // 
            this.deletePresetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletePresetBtn.Location = new System.Drawing.Point(334, 52);
            this.deletePresetBtn.Name = "deletePresetBtn";
            this.deletePresetBtn.Size = new System.Drawing.Size(68, 26);
            this.deletePresetBtn.TabIndex = 2;
            this.deletePresetBtn.Text = "Delete";
            this.deletePresetBtn.UseVisualStyleBackColor = true;
            this.deletePresetBtn.Click += new System.EventHandler(this.deletePresetBtn_Click);
            // 
            // presetLabel
            // 
            this.presetLabel.AutoSize = true;
            this.presetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetLabel.Location = new System.Drawing.Point(12, 29);
            this.presetLabel.Name = "presetLabel";
            this.presetLabel.Size = new System.Drawing.Size(59, 20);
            this.presetLabel.TabIndex = 600;
            this.presetLabel.Text = "Preset:";
            // 
            // backupFolderTxtBox
            // 
            this.backupFolderTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupFolderTxtBox.Location = new System.Drawing.Point(27, 112);
            this.backupFolderTxtBox.Name = "backupFolderTxtBox";
            this.backupFolderTxtBox.Size = new System.Drawing.Size(301, 23);
            this.backupFolderTxtBox.TabIndex = 3;
            this.backupFolderTxtBox.Leave += new System.EventHandler(this.backupFolderTxtBox_Leave);
            // 
            // backupFolderLabel
            // 
            this.backupFolderLabel.AutoSize = true;
            this.backupFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupFolderLabel.Location = new System.Drawing.Point(12, 89);
            this.backupFolderLabel.Name = "backupFolderLabel";
            this.backupFolderLabel.Size = new System.Drawing.Size(116, 20);
            this.backupFolderLabel.TabIndex = 601;
            this.backupFolderLabel.Text = "Backup Folder:";
            // 
            // backupFolderSearchBtn
            // 
            this.backupFolderSearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupFolderSearchBtn.Location = new System.Drawing.Point(334, 110);
            this.backupFolderSearchBtn.Name = "backupFolderSearchBtn";
            this.backupFolderSearchBtn.Size = new System.Drawing.Size(68, 27);
            this.backupFolderSearchBtn.TabIndex = 4;
            this.backupFolderSearchBtn.Text = "Search";
            this.backupFolderSearchBtn.UseVisualStyleBackColor = true;
            this.backupFolderSearchBtn.Click += new System.EventHandler(this.backupFolderSearchBtn_Click);
            // 
            // BackupBtn
            // 
            this.BackupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupBtn.Location = new System.Drawing.Point(16, 141);
            this.BackupBtn.Name = "BackupBtn";
            this.BackupBtn.Size = new System.Drawing.Size(87, 32);
            this.BackupBtn.TabIndex = 5;
            this.BackupBtn.Text = "Backup!";
            this.BackupBtn.UseVisualStyleBackColor = true;
            this.BackupBtn.Click += new System.EventHandler(this.BackupBtn_Click);
            // 
            // FilesBtn
            // 
            this.FilesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilesBtn.Location = new System.Drawing.Point(334, 141);
            this.FilesBtn.Name = "FilesBtn";
            this.FilesBtn.Size = new System.Drawing.Size(68, 32);
            this.FilesBtn.TabIndex = 6;
            this.FilesBtn.Text = "Files";
            this.FilesBtn.UseVisualStyleBackColor = true;
            this.FilesBtn.Click += new System.EventHandler(this.FilesBtn_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(109, 144);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(66, 24);
            this.StatusLabel.TabIndex = 602;
            this.StatusLabel.Text = "Status";
            this.StatusLabel.Visible = false;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.MistyRose;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsMenuStripItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(415, 24);
            this.MenuStrip.TabIndex = 603;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // OptionsMenuStripItem
            // 
            this.OptionsMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MultithreadedSubmenuOptions});
            this.OptionsMenuStripItem.Font = new System.Drawing.Font("Arial", 10F);
            this.OptionsMenuStripItem.Name = "OptionsMenuStripItem";
            this.OptionsMenuStripItem.Size = new System.Drawing.Size(69, 20);
            this.OptionsMenuStripItem.Text = "Options";
            // 
            // MultithreadedSubmenuOptions
            // 
            this.MultithreadedSubmenuOptions.CheckOnClick = true;
            this.MultithreadedSubmenuOptions.Name = "MultithreadedSubmenuOptions";
            this.MultithreadedSubmenuOptions.Size = new System.Drawing.Size(180, 22);
            this.MultithreadedSubmenuOptions.Text = "Multithreaded";
            this.MultithreadedSubmenuOptions.CheckedChanged += new System.EventHandler(this.MultithreadedSubmenuOptions_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 187);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.FilesBtn);
            this.Controls.Add(this.BackupBtn);
            this.Controls.Add(this.backupFolderSearchBtn);
            this.Controls.Add(this.backupFolderLabel);
            this.Controls.Add(this.backupFolderTxtBox);
            this.Controls.Add(this.presetLabel);
            this.Controls.Add(this.deletePresetBtn);
            this.Controls.Add(this.newPresetBtn);
            this.Controls.Add(this.presetComboBox);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainWindow";
            this.Text = "Backup Utility";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox presetComboBox;
        private System.Windows.Forms.Button newPresetBtn;
        private System.Windows.Forms.Button deletePresetBtn;
        private System.Windows.Forms.Label presetLabel;
        private System.Windows.Forms.TextBox backupFolderTxtBox;
        private System.Windows.Forms.Label backupFolderLabel;
        private System.Windows.Forms.Button backupFolderSearchBtn;
        private System.Windows.Forms.Button BackupBtn;
        private System.Windows.Forms.Button FilesBtn;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem MultithreadedSubmenuOptions;
    }
}

