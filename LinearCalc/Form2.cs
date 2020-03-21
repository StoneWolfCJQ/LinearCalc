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
    public partial class Form2 : Form
    {

        public Form2()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Form2));           
            InitializeComponent();
            InitialCustomComponent();
        }

        private void FileList_DragEnter(object sender, DragEventArgs e)
        {
            String[] enterFormats;
            String tempExt;
            bool isFile;
            bool hasTxtFile = false;
            int i = 0;            

            enterFormats = e.Data.GetData(DataFormats.FileDrop) as String[];
            this.dropFileIndex = new bool[enterFormats.Length];
            this.dropFolder = false;

            foreach (String fileDropName in enterFormats)
            {
                FileAttributes attr;
                try
                {
                    attr = File.GetAttributes(fileDropName);
                }
                catch (Exception ex)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
                isFile = !attr.HasFlag(FileAttributes.Directory);
                if (isFile)
                {
                    tempExt = Path.GetExtension(fileDropName);
                    if (tempExt.Equals(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        hasTxtFile = true;
                        this.dropFileIndex[i] = true;
                    }
                    else
                    {
                        this.dropFileIndex[i] = false;
                    }
                }
                else
                {
                   if (enterFormats.Length == 1)
                    {
                        this.dropFolder = true;
                    }
                }
                i++;
            }     
            
            if (hasTxtFile || this.dropFolder)
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FileList_DragDrop(object sender, DragEventArgs e)
        {
            String[] enterFormats;
            int i = 0, j = 0;            
            bool emptyTop;
            ListViewItem tempTop = this.fileList.TopItem;            
            String tempPath;
            int fileCount = this.dropFileIndex.Count(s => s == true);
            this.openFileList = new String[fileCount];

            enterFormats = e.Data.GetData(DataFormats.FileDrop) as String[];
            tempPath = enterFormats[0];
            if (null != tempTop)
            {
                emptyTop = false;
            }
            else
            {
                emptyTop = true;
            }

            if (this.dropFolder)
            {               
                this.addFileDialog.InitialDirectory = tempPath;
                OpenFileDialogProcess(emptyTop);
            }
            
            else
            {                
                foreach (String fileDropName in enterFormats)
                {
                    if (this.dropFileIndex[i])
                    {
                        this.openFileList[j] = fileDropName;
                        j++;
                    }
                    i++;
                }
                AddItem(emptyTop);
            }
        }

        private void FormSize_Change(object sender, EventArgs e)
        {
            this.fileList.Size = this.Size - this.offset[0];
        }

        private void genFileButton_Click(object sender, EventArgs e)
        {
            if (this.fileList.ContainsFocus)
            {
                OpenSelectedItem();
                return;
            }
            GenerateFile();
        }

        private void fileList_MouseDoubleClick(object sender, EventArgs e)
        {
            OpenSelectedItem();
        }

        private void addFilesButton_Click(object sender, EventArgs e)
        {
            OpenFolder();      
        }

        private void deleteFileButton_Click(object sender, EventArgs e)
        {
            DeleteItems();
        }

        private void clearFileButton_Click(object sender, EventArgs e)
        {
            ClearList();
        }

        private void fileList_ItemSelectChanged(object sender, EventArgs e)
        {
            if (this.fileList.SelectedItems.Count == 1)
            {
                this.fileWeightNumeric.Text = this.fileList.SelectedItems[0].SubItems[2].Text;
                this.fileFlipCheckBox.Checked = this.fileList.SelectedItems[0].SubItems[3].Text 
                    == "Yes" ? true : false;
                fileOffsetNumeric.Text = fileList.SelectedItems[0].SubItems[4].Text;
            }      
        }

        private void openSavedFileButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void openSavedFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Path.GetDirectoryName(saved ? this.savedFilePath : this.defaultPath + '\\'));
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件夹错误：" + Path.GetDirectoryName(saved ? this.savedFilePath : this.defaultPath) +
                    "\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void varNameBox_TextChanged(object sender, EventArgs e)
        {
            bool changeColor = !this.varNameBoxAutoChange;
            if (UtilityFunctions.CheckVariableName(this.varNameBox, this.varNameBox.Text, false, changeColor))
            {
                this.varName = this.varNameBox.Text;
                this.genFileButton.Enabled = true;
            }
            else
            {
                this.genFileButton.Enabled = false;
            }
            this.varNameBoxAutoChange = false;
        }

        private void fileWeightNumeric_ValueChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection tempItems = this.fileList.SelectedItems;

            foreach (ListViewItem tempItem in tempItems)
            {                
                try
                {
                    tempItem.SubItems[2].Text = this.fileWeightNumeric.Value.ToString();
                }
                catch
                {

                }
                
            }
        }

        private void fileFlipCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FileFlipCheckBox_Click(object sender, EventArgs e)
        {
            ChangeCheck();
        }

        private void offsetBox_ValueChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection tempItems = this.fileList.SelectedItems;

            foreach (ListViewItem tempItem in tempItems)
            {
                try
                {
                    string s = this.fileOffsetNumeric.Value.ToString().TrimEnd('0');
                    if (s.EndsWith("."))
                    {
                        s += '0';
                    }
                    tempItem.SubItems[4].Text = s;
                }
                catch
                {

                }

            }
        }
    }
}
