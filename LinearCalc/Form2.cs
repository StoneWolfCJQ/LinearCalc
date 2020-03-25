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
using System.Text.RegularExpressions;

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
            dropFileIndex = new bool[enterFormats.Length];
            dropFolder = false;

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
                    string reg = @"^(?i)(\.(txt|rtl|pos))$";
                    if (Regex.IsMatch(tempExt, reg))
                    {
                        hasTxtFile = true;
                        dropFileIndex[i] = true;
                    }
                    else
                    {
                        dropFileIndex[i] = false;
                    }
                }
                else
                {
                    if (enterFormats.Length == 1)
                    {
                        dropFolder = true;
                    }
                }
                i++;
            }

            if (hasTxtFile || dropFolder)
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
            ListViewItem tempTop = fileList.TopItem;
            String tempPath;
            int fileCount = dropFileIndex.Count(s => s == true);
            openFileList = new String[fileCount];

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

            if (dropFolder)
            {
                addFileDialog.InitialDirectory = tempPath;
                OpenFileDialogProcess(emptyTop);
            }

            else
            {
                foreach (String fileDropName in enterFormats)
                {
                    if (dropFileIndex[i])
                    {
                        openFileList[j] = fileDropName;
                        j++;
                    }
                    i++;
                }
                AddItem(emptyTop);
            }
        }

        private void FormSize_Change(object sender, EventArgs e)
        {
            fileList.Size = Size - offset[0];
        }

        private void genFileButton_Click(object sender, EventArgs e)
        {
            if (fileList.ContainsFocus)
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
            if (fileList.SelectedItems.Count == 1)
            {
                fileWeightNumeric.Text = fileList.SelectedItems[0].SubItems[2].Text;
                fileFlipCheckBox.Checked = fileList.SelectedItems[0].SubItems[3].Text
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
                System.Diagnostics.Process.Start(Path.GetDirectoryName(saved ? savedFilePath : defaultPath + '\\'));
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件夹错误：" + Path.GetDirectoryName(saved ? savedFilePath : defaultPath) +
                    "\n" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void varNameBox_TextChanged(object sender, EventArgs e)
        {
            bool changeColor = !varNameBoxAutoChange;
            if (UtilityFunctions.CheckVariableName(varNameBox, varNameBox.Text, false, changeColor))
            {
                varName = varNameBox.Text;
                genFileButton.Enabled = true;
            }
            else
            {
                genFileButton.Enabled = false;
            }
            varNameBoxAutoChange = false;
        }

        private void fileWeightNumeric_ValueChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection tempItems = fileList.SelectedItems;

            foreach (ListViewItem tempItem in tempItems)
            {
                try
                {
                    tempItem.SubItems[2].Text = fileWeightNumeric.Value.ToString();
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
            ListView.SelectedListViewItemCollection tempItems = fileList.SelectedItems;

            foreach (ListViewItem tempItem in tempItems)
            {
                try
                {
                    string s = fileOffsetNumeric.Value.ToString().TrimEnd('0');
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
