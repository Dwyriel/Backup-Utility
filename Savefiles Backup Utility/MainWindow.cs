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
        #endregion

        #region Events:
        private void newPresetBtn_Click(object sender, EventArgs e)
        {
            //todo create my own input form
            //string str = Microsoft.VisualBasic.Interaction.InputBox("Preset Name:", "New Preset");
        }

        private void deletePresetBtn_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
