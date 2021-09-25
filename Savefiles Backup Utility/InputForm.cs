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
    public partial class InputForm : Form
    {
        public string title, description;
        public string Input { get { return InputBox.Text; } }

        public InputForm()
        {
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            OkBtn.Enabled = false;
            Text = title;
            DescriptionLabel.Text = description;
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            OkBtn.Enabled = InputBox.Text != "" && !(InputBox.Text is null);
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                OkBtn.PerformClick();
                e.Handled = true;
            }
        }
    }
}
