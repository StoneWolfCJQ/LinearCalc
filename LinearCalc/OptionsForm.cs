using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace LinearCalc
{
    public partial class OptionsForm : Form
    {
        protected internal bool autoOpen;
        protected internal bool autoOverwrite;
        protected internal String prefix = UtilityParameters.defaultPrefix;
        public OptionsForm(bool inputAutoOpen = true, bool inputAutoOverwrite = true, 
            String prefix = UtilityParameters.defaultPrefix)
        {
            this.autoOpen = inputAutoOpen;
            this.autoOverwrite = inputAutoOverwrite;
            InitializeComponent();
            this.prefix = prefix;
            this.prefixTextBox.Text = this.prefix;
            this.KeyPreview = true;
            this.KeyDown += OptionsForm_KeyDown;
        }

        private void OptionsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || ((e.KeyCode == Keys.Enter) && (! this.buttonOK.Enabled)))
            {
                Quit();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SaveAndClose();
            }
        }

        private void Quit()
        {
            DialogResult result = MessageBox.Show("是否退出，更改不会被保存", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (DialogResult.OK == result)
            {
                this.Close();
            }
        }

        private void autoOpenCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            /*this.autoOpenCheckBox.Checked = !this.autoOpenCheckBox.Checked;
            this.autoOpenCheckBox.CheckState = (this.autoOpenCheckBox.CheckState == CheckState.Checked) ?
                CheckState.Unchecked : CheckState.Checked;*/
        }

        private void prefixTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UtilityFunctions.CheckVariableName(this.prefixTextBox, this.prefixTextBox.Text, true, true))
            {
                this.buttonOK.Enabled = true;                
            }      
            else
            {
                this.buttonOK.Enabled = false;
            }
        }       

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void SaveAndClose()
        {
            this.prefix = this.prefixTextBox.Text;
            this.autoOverwrite = this.autoOverwriteCheckBox.Checked;
            this.autoOpen = this.autoOpenCheckBox.Checked;
            this.Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            this.autoOverwriteCheckBox.Checked = this.autoOverwrite;
            this.autoOpenCheckBox.Checked = this.autoOpen;
            this.autoOpenCheckBox.CheckState = this.autoOpen? CheckState.Checked : CheckState.Unchecked;
            this.autoOverwriteCheckBox.CheckState = this.autoOverwrite ? CheckState.Checked : CheckState.Unchecked;
        }

        private void autoOverwriteCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            /*this.autoOverwriteCheckBox.Checked = !this.autoOverwriteCheckBox.Checked;
            this.autoOverwriteCheckBox.CheckState = (this.autoOverwriteCheckBox.CheckState==CheckState.Checked) ? 
                CheckState.Unchecked : CheckState.Checked;*/
        }
    }

    
}
