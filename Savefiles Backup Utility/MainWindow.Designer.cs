
namespace Savefiles_Backup_Utility
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
            this.SuspendLayout();
            // 
            // presetComboBox
            // 
            this.presetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presetComboBox.FormattingEnabled = true;
            this.presetComboBox.Location = new System.Drawing.Point(27, 32);
            this.presetComboBox.Name = "presetComboBox";
            this.presetComboBox.Size = new System.Drawing.Size(227, 26);
            this.presetComboBox.TabIndex = 0;
            // 
            // newPresetBtn
            // 
            this.newPresetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPresetBtn.Location = new System.Drawing.Point(260, 32);
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
            this.deletePresetBtn.Location = new System.Drawing.Point(334, 32);
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
            this.presetLabel.Location = new System.Drawing.Point(12, 9);
            this.presetLabel.Name = "presetLabel";
            this.presetLabel.Size = new System.Drawing.Size(59, 20);
            this.presetLabel.TabIndex = 3;
            this.presetLabel.Text = "Preset:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.presetLabel);
            this.Controls.Add(this.deletePresetBtn);
            this.Controls.Add(this.newPresetBtn);
            this.Controls.Add(this.presetComboBox);
            this.Name = "MainWindow";
            this.Text = "Savefiles Backup Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox presetComboBox;
        private System.Windows.Forms.Button newPresetBtn;
        private System.Windows.Forms.Button deletePresetBtn;
        private System.Windows.Forms.Label presetLabel;
    }
}

