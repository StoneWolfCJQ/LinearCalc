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
    public partial class ScriptGenWindow : Form
    {
        public ScriptGenWindow()
        {            
            InitializeComponent();
            InitialCustomComponent();
        }

        private void ProgramTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (ModifierKeys == Keys.Control)
            {
                if ((e.KeyChar != 'A') && (e.KeyChar != 'C') &&
                    (e.KeyChar != 'X') && (e.KeyChar != 'Z') && (e.KeyChar != 'Y'))
                e.Handled = true;
            }         */   
        }

        private void ProgramTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.AcceptButton = null;
            this.programTextBox.Focus();
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                string keyString = e.KeyCode.ToString();
                char keyChar = keyString[0];
                if (keyString.Length == 1)
                {
                    if (e.KeyCode == Keys.C)
                    {
                        CopyText();
                    }         
                    else if (e.KeyCode == Keys.A)
                    {
                        this.programTextBox.SelectAll();
                    }
                }
                else if (keyString.Length == 2)
                {
                    keyChar = keyString[1];
                    int keyInt;
                    keyString = keyChar.ToString();
                    if (int.TryParse(keyString, out keyInt))
                    {
                        try
                        {
                            ChangeTask((task)keyInt - 1);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            else if (e.KeyCode==Keys.Escape)
            {
                Quit();
            }
        }
        
        private void ProgramTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                float newSize;
                if (e.Delta > 0)
                {
                    newSize = this.programTextBox.Font.Size + 0.2F;
                    if (newSize >= 25)
                    {
                        newSize = 25;
                    }
                    this.programTextBox.Font = new Font(this.programTextBox.Font.FontFamily, newSize);
                }
                else if (e.Delta < 0)
                {
                    newSize = this.programTextBox.Font.Size - 1F;
                    if (newSize <= 5)
                    {
                        newSize = 5;
                    }
                    this.programTextBox.Font = new Font(this.programTextBox.Font.FontFamily, newSize);
                }
            }
        }

        private void Form3_Resize(object sender, EventArgs e)
        {

        }

        private void Form3_Deactivated(object sender, EventArgs e)
        {
            this.copiedLabel.Visible = false;
        }

        private void programTextBox_TextChanged(object sender, EventArgs e)
        {
            this.programTextBox.BackColor = Color.Yellow;
        }

        private void restoreDefaultButton_Click(object sender, EventArgs e)
        {
            ChangeTask(this.taskNum);
            this.programTextBox.BackColor = SystemColors.Window;
            this.programTextBox.Font = this.textBoxOriFont;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            CopyText();
        }

        private void copiedLabelTimer_Tick(object sender, EventArgs e)
        {
            this.copiedLabel.Visible = false;
            this.copiedLabelTimer.Enabled = false;
            this.copiedLabelTimer.Stop();
        }

        private void scriptChooseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.programTextBox.TextChanged -= new System.EventHandler(this.programTextBox_TextChanged);
            this.taskNum = (task)this.scriptChooseComboBox.SelectedIndex;
            this.Text = UtilityParameters.scriptName[(int) this.taskNum];
            ShowScript();
            this.programTextBox.TextChanged += new System.EventHandler(this.programTextBox_TextChanged);
        }
    }
}
