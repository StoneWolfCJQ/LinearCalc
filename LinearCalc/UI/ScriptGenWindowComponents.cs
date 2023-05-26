using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LinearCalc;
using Utilities;

namespace LinearCalc
{
    partial class ScriptGenWindow
    {
        private void InitialCustomComponent()
        {
            this.Deactivate += Form3_Deactivated;
            this.Resize += Form3_Resize;
            this.programTextBox.MouseWheel += ProgramTextBox_MouseWheel;
            this.oriSize = this.Size;
            this.textBoxOriFont = this.programTextBox.Font;
            this.scriptChooseComboBox.Items.AddRange(Utilities.UtilityParameters.scriptName);           
            this.copiedLabelTimer.Enabled = false;
            this.KeyDown += Form3_KeyDown;
            this.programTextBox.KeyPress += ProgramTextBox_KeyPress;
            this.KeyPreview = true;
            this.programTextBox.MouseClick += ProgramTextBox_MouseClick;
        }

        private void CopyText()
        {
            Clipboard.SetText(this.programTextBox.Text);
            this.copiedLabel.Visible = true;
            this.copiedLabelTimer.Enabled = true;
            this.copiedLabelTimer.Start();
        }

        private void Quit()
        {
            this.Close();
            /* DialogResult result = MessageBox.Show("是否关闭脚本？", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
             if (DialogResult.OK == result)
             {
                 this.Close();
             }*/
        }


        public void SetTask(task taskNum)
        {            
            this.taskNum = taskNum;
            this.programTextBox.BackColor = SystemColors.Window;
            this.scriptChooseComboBox.SelectedIndex = (int)this.taskNum;
            this.Text = UtilityParameters.scriptName[(int)this.taskNum];           
            ShowScript();
            this.programTextBox.TextChanged += this.programTextBox_TextChanged;
            this.scriptChooseComboBox.SelectedIndexChanged +=this.scriptChooseComboBox_SelectedIndexChanged;
        }

        public void ChangeTask(task taskNum)
        {
            this.programTextBox.TextChanged -= this.programTextBox_TextChanged;
            this.scriptChooseComboBox.SelectedIndexChanged -=this.scriptChooseComboBox_SelectedIndexChanged;
            SetTask(taskNum);
        }

        private void ShowScript()
        {
            switch (this.taskNum)
            {
                case task.ZERO:
                    this.programTextBox.Text = LinearCalc.Properties.Resources.Zero;
                    break;
                case task.MEASURE:
                    this.programTextBox.Text = LinearCalc.Properties.Resources.Measure;
                    break;
                case task.COMPEN:
                    this.programTextBox.Text = LinearCalc.Properties.Resources.Comp;
                    break;
                default:
                    break;
            }
            this.programTextBox.Show();
        }
    }

    partial class ScriptGenWindow
    {
        private task taskNum= task.MEASURE;
        private Size oriSize;
        private Font textBoxOriFont;
        public static bool running = true;
    }
}