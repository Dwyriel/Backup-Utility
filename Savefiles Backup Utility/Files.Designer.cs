
namespace Savefiles_Backup_Utility
{
    partial class Files
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
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.AddFileBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.BUNumberEditCheckBox = new System.Windows.Forms.CheckBox();
            this.BUNumberTxtBox = new System.Windows.Forms.TextBox();
            this.AddFolderBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FilesListBox
            // 
            this.FilesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.HorizontalScrollbar = true;
            this.FilesListBox.ItemHeight = 16;
            this.FilesListBox.Location = new System.Drawing.Point(12, 12);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(287, 276);
            this.FilesListBox.TabIndex = 0;
            // 
            // AddFileBtn
            // 
            this.AddFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFileBtn.Location = new System.Drawing.Point(305, 12);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(98, 32);
            this.AddFileBtn.TabIndex = 1;
            this.AddFileBtn.Text = "Add File";
            this.AddFileBtn.UseVisualStyleBackColor = true;
            this.AddFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveBtn.Location = new System.Drawing.Point(305, 88);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(98, 32);
            this.RemoveBtn.TabIndex = 3;
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(305, 126);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(98, 32);
            this.ClearBtn.TabIndex = 4;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBtn.Location = new System.Drawing.Point(305, 256);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(98, 32);
            this.CloseBtn.TabIndex = 7;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // BUNumberEditCheckBox
            // 
            this.BUNumberEditCheckBox.AutoSize = true;
            this.BUNumberEditCheckBox.Location = new System.Drawing.Point(359, 164);
            this.BUNumberEditCheckBox.Name = "BUNumberEditCheckBox";
            this.BUNumberEditCheckBox.Size = new System.Drawing.Size(44, 17);
            this.BUNumberEditCheckBox.TabIndex = 5;
            this.BUNumberEditCheckBox.Text = "Edit";
            this.BUNumberEditCheckBox.UseVisualStyleBackColor = true;
            this.BUNumberEditCheckBox.CheckedChanged += new System.EventHandler(this.BUNumberEditCheckBox_CheckedChanged);
            // 
            // BUNumberTxtBox
            // 
            this.BUNumberTxtBox.Location = new System.Drawing.Point(359, 187);
            this.BUNumberTxtBox.Name = "BUNumberTxtBox";
            this.BUNumberTxtBox.Size = new System.Drawing.Size(44, 20);
            this.BUNumberTxtBox.TabIndex = 6;
            this.BUNumberTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BUNumberTxtBox.Leave += new System.EventHandler(this.BUNumberTxtBox_Leave);
            // 
            // AddFolderBtn
            // 
            this.AddFolderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFolderBtn.Location = new System.Drawing.Point(305, 50);
            this.AddFolderBtn.Name = "AddFolderBtn";
            this.AddFolderBtn.Size = new System.Drawing.Size(98, 32);
            this.AddFolderBtn.TabIndex = 2;
            this.AddFolderBtn.Text = "Add Folder";
            this.AddFolderBtn.UseVisualStyleBackColor = true;
            this.AddFolderBtn.Click += new System.EventHandler(this.AddFolderBtn_Click);
            // 
            // Files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 298);
            this.Controls.Add(this.AddFolderBtn);
            this.Controls.Add(this.BUNumberTxtBox);
            this.Controls.Add(this.BUNumberEditCheckBox);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.AddFileBtn);
            this.Controls.Add(this.FilesListBox);
            this.Name = "Files";
            this.Text = "Files";
            this.Load += new System.EventHandler(this.Files_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.Button AddFileBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.CheckBox BUNumberEditCheckBox;
        private System.Windows.Forms.TextBox BUNumberTxtBox;
        private System.Windows.Forms.Button AddFolderBtn;
    }
}