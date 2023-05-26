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
using Utilities;

namespace LinearCalc
{
    /**************************************/
    /*******Main Functions For Even*********/
    public partial class MainUI : Form
    {
        #region Init
        public MainUI()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
            InitializeCustomComponent();               
        }
        #endregion

        #region SystemDLLAssemble
        public System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");

            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources")) return null;

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

            byte[] bytes = (byte[])rm.GetObject(dllName);

            return System.Reflection.Assembly.Load(bytes);
        }
        #endregion

        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData  == (Keys.Control | Keys.G))
            {
                MessageBox.Show("What the Ctrl+G?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }*/

        #region FormDrag Event
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            string[] enterFormats;
            string fileDropName;
            string tempExt;
            bool isFile;
            int tempManu = -1;

            enterFormats = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (enterFormats.Length == 1)
            {
                fileDropName = enterFormats[0];
                FileAttributes attr;
                try
                {
                    attr = File.GetAttributes(fileDropName);
                }
                catch(Exception ex)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
                isFile = !attr.HasFlag(FileAttributes.Directory);
                if (isFile)
                {
                    tempExt = Path.GetExtension(fileDropName);
                    tempManu = Array.FindIndex(UtilityParameters.manuExtList,
                            s => s.Equals(tempExt));
                    if (-1 == tempManu)
                    {
                        e.Effect = DragDropEffects.None;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.Link;
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.Link;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string fileDropName;
            bool isFile;
            FileAttributes attr;

            fileDropName = (e.Data.GetData(DataFormats.FileDrop) as string[])[0];

            try
            {
                attr = File.GetAttributes(fileDropName);
            }
            catch (Exception ex)
            {
                return;
            }
            isFile = !attr.HasFlag(FileAttributes.Directory);
            if (isFile)
            {
                this.openFileReturn = true;
                this.usrInputOpenFileName = false;

                this.openFileExt = Path.GetExtension(fileDropName);
                this.manufactory = (manufactoryList) Array.FindIndex(UtilityParameters.manuExtList,
                        s => s.Equals(this.openFileExt));

                this.openFileName = Path.GetFileNameWithoutExtension(fileDropName);
                this.openFileExt = Path.GetExtension(fileDropName);
                this.openFullPath = Path.GetDirectoryName(fileDropName);

                FileStreamHandler();
            }
            else
            {
                Program.currentPath = fileDropName;
                this.openFullPath = fileDropName;
                if (this.autoSaveFileName)
                {
                    this.saveFullPath = this.openFullPath;
                }
                MasterSLP();
            }
        }
#endregion

        private void openPathText_MouseHover(object sender, EventArgs e)
        {           
            this.openFileTip.SetToolTip(this.openPathText, this.openFullPath);     
        }

        private void savePathText_MouseHover(object sender, EventArgs e)
        {
            this.saveFileTip.SetToolTip(this.savePathText, this.saveFullPath);            
        }

        private void openFileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (this.openFileReturn)
            {
                this.openFileReturn = false;
            }
            else
            {
                this.usrInputOpenFileName = true;
            }

            if (CheckFileNameValid(this.openFileNameBox))
            {                
                this.openFileName = this.openFileNameBox.Text;                
                if (autoSaveFileName)
                {
                    this.saveFileName = this.openFileName;
                    this.saveFileNameBox.Text = this.saveFileName;
                }

                if (autoApp && (0 == autoAppRule))
                {
                    this.suffixTextBox.Text = this.openFileName;
                    ChangeSuffixBoxTextToValid(); 
                }
            }

            SetInfoText(infoText.NONE);            
        }

        private void saveFileNameBox_TextChanged(object sender, EventArgs e)
        {
            if (this.saveFileReturn)
            {
                this.saveFileReturn = false;                
            }
            else
            {
                this.usrInputSaveFileName = true;
            }

            if (CheckFileNameValid(this.saveFileNameBox))
            {
                this.saveFileName = this.saveFileNameBox.Text;
                
                if (autoApp && (1 == autoAppRule))
                {
                    this.suffixTextBox.Text = this.saveFileName;
                    ChangeSuffixBoxTextToValid(); 
                }
            }

            SetInfoText(infoText.NONE);
        }

        private void openFilePathButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void saveFilePathButton_Click(object sender, EventArgs e)
        {
            SelectSavePath();
        }

        private void fileGenerateButton_Click(object sender, EventArgs e)
        {
            GenerateFile();
        }

        private void optionMenuStrip_Click(object sender, EventArgs e)
        {
   
        }

        private void menuChildFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void menuChildAbout_Click(object sender, EventArgs e)
        {
            AboutPage();
        }

        private void menuChildManual_Click(object sender, EventArgs e)
        {
            HelpPage();
        }

        private void openFileExtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            OptionsPage();
        }

        private void menuChildAutoApp_Click(object sender, EventArgs e)
        {
            this.autoApp = !this.autoApp;
            this.menuChildAutoApp.Checked = this.autoApp;
            this.suffixTextBox.ReadOnly = this.autoApp;           
            if (this.autoApp)
            {
                this.suffixTextBox.BackColor = SystemColors.Control;
                this.suffixTextBox.Text = this.saveFileNameBox.Text;
                ChangeSuffixBoxTextToValid();                
            }
            else
            {
                this.suffixTextBox.BackColor = SystemColors.Window;
            }
        }

        private void menuChildQuickGen_Click(object sender, EventArgs e)
        {
            this.quickGen = !this.quickGen;
            this.menuChildQuickGen.Checked = this.quickGen;
        }

        private void SuffixTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((ModifierKeys != Keys.Control) && (e.KeyChar != '\u001b'))
            {
                if (this.autoApp)
                {
                    BalloonTip ballon = new BalloonTip("自动添加后缀选项已启用，无法输入", this.suffixTextBox);
                }
            }      
            /*else
            {
               e.Handled = true;
            }*/
        }

        private void suffixTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.autoApp)
            {
                CheckSuffixValid(this.suffixTextBox);
            }
        }

        private void infoTextLabel_Changed(object sender, EventArgs e)
        {
        }

        private void menuChildAutoSaveFileName_Click(object sender, EventArgs e)
        {
            this.autoSaveFileName = !this.autoSaveFileName;
            this.menuChildAutoSaveFileName.Checked = this.autoSaveFileName;
            if (this.autoSaveFileName)
            {
                this.saveFileNameBox.Text = this.openFileNameBox.Text;
            }
        }

        private void extDropList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.openFileExt = this.extDropList.SelectedItem as string;
        }

        private void menuChildOpenSavedFIle_Click(object sender, EventArgs e)
        {
            if (saved)
            {
                try
                {
                    System.Diagnostics.Process.Start(this.savedFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件错误：" + this.savedFilePath + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }            
        }

        private void menuChildFolder_Select(object n, EventArgs e)
        {
            this.menuTipVirtualLabel.Text = "";
            this.menuTipVirtualLabel.Location = new System.Drawing.Point(MousePosition.X-this.Location.X , 20 );
            this.menuTipVirtualLabel.Visible = false;
            this.menuTip.Show("设置干涉仪文件所在目录", this.menuTipVirtualLabel, 2000);
        }

        private void menuChildOpenSavedFile_Select(object n, EventArgs e)
        {            
            this.menuTip.Hide(this.menuTipVirtualLabel);
        }

        private void menuRootFile_Popup(object sender, EventArgs e)
        {
            if (!saved)
            {
                this.menuChildOpenSavedFIle.Enabled = false;
            }
            else
            {
                this.menuChildOpenSavedFIle.Enabled = true;
            }

            if ((string.Empty == this.openFileName) || (null == this.openFileName))
            {
                this.menuChildOpenFile.Enabled = false;
            }
            else
            {
                this.menuChildOpenFile.Enabled = true;
            }
        }

        private void menuChildOpenFile_Click(object sender, EventArgs e)
        {
            if (this.menuChildOpenFile.Enabled)
            {
                try
                {
                    System.Diagnostics.Process.Start(this.openFullPath + '\\' + this.openFileName + this.openFileExt);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("无法打开干涉仪文件:" +this.openFileName + this.openFileExt + "\n" + ex.Message,"错误",
                        MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void openFolderOpenButton_Click(object sender, EventArgs e)
        {
            /*this.openFolderContextMenuStrip.Show(this.openFolderOpenButton,
                this.openFolderOpenButton.Width, 0);*/
            try
            {          
                System.Diagnostics.Process.Start(this.openFullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开文件夹:" + this.openFullPath + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveFolderOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this.saveFullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开文件夹:" + this.saveFullPath + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void menuChldeGenScript_Click(object sender, EventArgs e)
        {

        }

        private void menuChildMergeSaveData_Click(object sender, EventArgs e)
        {
            MergeTool();
        }
      
        private void menuChildDataMeasure_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            ScriptFormRun(task.MEASURE);            
        }

        private void menuChildZero_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            ScriptFormRun(task.ZERO);
        }

        private void menuChildComp_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            ScriptFormRun(task.COMPEN);
        }

        private void OpenFileNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }*/
        }

        private void SaveFileNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {         
            /*if (ModifierKeys == Keys.Control)
            {
                e.Handled = true;
            }*/
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuODFACS_Click(object sender, EventArgs e)
        {
            ChangeOutDataFormat(DataFormator.ACS);
        }

        private void menuODFAeroTech_Click(object sender, EventArgs e)
        {
            ChangeOutDataFormat(DataFormator.AeroTech);
        }

        private void OutDataColNum_ValueChanged(object sender, EventArgs e)
        {
            mergeForm.outDataColNum = OutDataColNum.Value;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            ChangeOutDataFormat(DataFormator.Vulcan);
        }
    }    
}
