﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utilities;
using System.Linq;

namespace LinearCalc
{
    partial class MergeWindow
    {
        #region Init
        private void InitialCustomComponent()
        {
            FormBorderStyle = FormBorderStyle.Fixed3D;
            fileList.Scrollable = false;
            FileListFill();
            fileList.LabelEdit = false;
            offset[0] = Size - fileList.Size;
            SizeChanged += new EventHandler(FormSize_Change);
            openSavedFileButton.Enabled = false;
            fileList.MouseDoubleClick += new MouseEventHandler(fileList_MouseDoubleClick);
            fileList.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(fileList_ItemSelectChanged);
            fileList.DragEnter += FileList_DragEnter;
            fileList.DragDrop += FileList_DragDrop;
            fileFlipCheckBox.Click += FileFlipCheckBox_Click;
            KeyDown += Form2_KeyDown;
            FunctionAdder();
            Activate();
        }

        #endregion

        #region HotKey
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            string pressedKeyS = e.KeyCode.ToString();
            Char pressedKey = pressedKeyS[0];
            if (e.Control)
            {
                if (pressedKeyS.Length == 1)
                {
                    HotKeyHandle(pressedKey);
                }
                else if (Keys.Enter.ToString() == pressedKeyS)
                {
                    pressedKey = 'G';
                    HotKeyHandle(pressedKey);
                }
            }

            if (Keys.Escape.ToString() == pressedKeyS)
            {
                pressedKey = 'Q';
                HotKeyHandle(pressedKey);
            }
        }

        private void FunctionAdder()
        {
            functionList.AddRange(new List<voidFunction>
            {
                OpenFile,
                GenerateFile,
                OpenFolder,
                None,
                None,
                GenerateFile,
                None,
                None,
                None,
                Quit
            });
        }

        private void HotKeyHandle(char keyChar)
        {
            int index;
            hotKeyMessage message;
            UtilityFunctions.HotKeyMessage(keyChar, out message);
            index = (int)message;

            if (hotKeyMessage.NONE != message)
            {
                functionList[index]();
            }
        }

        private void OpenFile()
        {
            if (saved)
            {
                try
                {
                    System.Diagnostics.Process.Start(savedFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件错误：" + savedFilePath + ex.Message, "错误",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                OpenFolder();
            }
        }

        private void OpenFolder()
        {
            bool emptyTop;
            ListViewItem tempTop = fileList.TopItem;
            if (null != tempTop)
            {
                emptyTop = false;
                defaultPath = fileList.Items[fileList.Items.Count - 1].SubItems[1].Text;
                defaultFileName = Path.GetFileNameWithoutExtension(fileList.Items[fileList.Items.Count - 1].Text);
                addFileDialog.InitialDirectory = defaultPath;
                addFileDialog.FileName = defaultFileName;
            }
            else
            {
                emptyTop = true;
                addFileDialog.InitialDirectory = defaultPath;
                addFileDialog.FileName = defaultFileName;
            }

            OpenFileDialogProcess(emptyTop);
        }

        private void GenerateFile()
        {
            if (fileList.Items.Count < 1)
            {
                OpenFolder();
            }

            if (fileList.Items.Count < 1)
            {
                return;
            }

            GetDataAndSaveFile();
        }

        private void Quit()
        {
            DialogResult result = MessageBox.Show("是否退出合并？", "提示",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (DialogResult.OK == result)
            {
                Close();
            }
        }
        private void None()
        {
            //Nothing Will Happen Here
        }
        #endregion

        void FileListFill()
        {
            foreach (ColumnHeader ch in fileList.Columns)
            {
                ch.Width = AverageWidth;
            }
            fileList.Columns[ColumnCount - 1].Width = AverageWidth + 10;
        }

        private void ChangeCheck()
        {
            ListView.SelectedListViewItemCollection tempItems = fileList.SelectedItems;

            foreach (ListViewItem tempItem in tempItems)
            {
                try
                {
                    tempItem.SubItems[3].Text = fileFlipCheckBox.Checked ? "Yes" : "No";
                }
                catch
                {

                }

            }
        }

        public void SetDefault(string setPath, string fileName)
        {
            defaultPath = setPath;
            defaultFileName = fileName;
        }

        private void OpenFileDialogProcess(bool emptyTop)
        {
            if (addFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileList = addFileDialog.FileNames;
                AddItem(emptyTop);
            }
        }

        private void AddItem(bool emptyTop, bool externalAdd = false, string[] fileDirList = null,
            double weight = 1.0, bool flip = false, double offset = 0.00000)
        {
            fileList.Scrollable = true;
            ListViewItem tempItem = new ListViewItem();
            if (fileDirList == null)
            {
                fileDirList = openFileList;
            }
            foreach (string line in fileDirList)
            {
                if (ExistFile(line,ref tempItem))
                {
                    if (externalAdd)
                    {
                        tempItem.SubItems[2].Text = weight.ToString();
                        tempItem.SubItems[3].Text = flip ? "Yes" : "No";
                        tempItem.SubItems[4].Text = offset.ToString();
                    }
                    continue;
                }
                tempItem = new ListViewItem(Path.GetFileName(line));
                tempItem.SubItems.Add(Path.GetDirectoryName(line));
                tempItem.SubItems.Add(weight.ToString());
                tempItem.SubItems.Add(flip ? "Yes" : "No");
                tempItem.SubItems.Add(offset.ToString("F5"));
                fileList.Items.Add(tempItem);
                if (emptyTop)
                {
                    defaultPath = fileList.Items[fileList.Items.Count - 1].SubItems[1].Text;
                    defaultFileName = Path.GetFileNameWithoutExtension(fileList.Items[fileList.Items.Count - 1].Text);
                    ChangeVarName();
                    emptyTop = false;
                }
                else
                {
                    defaultFileName = Path.GetFileNameWithoutExtension(fileList.Items[0].Text);
                }
            }
            fileList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            fileList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            fileList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            fileList.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void ExternelAddItem(string[] fileDirList, double weight, bool flip, double offset)
        {
            Invoke(new Action(()=> { AddItem(false, true, fileDirList, weight, flip, offset); }));
        }

        private void FileGenButtonUpdate()
        {
            if (fileList.Items.Count >= 2)
            {
                genFileButton.Enabled = true;
            }
            else
            {
                genFileButton.Enabled = false;
            }
        }

        private void ChangeVarName()
        {
            string ext = Path.GetExtension(fileList.TopItem.Text);
            if ((DataFormator.ACS != outDataFormat)|| 
                !ext.Equals(".txt",StringComparison.CurrentCultureIgnoreCase))
                return;

            string tempString;
            string tempFilePath;
            StreamReader tempStreamReader;
            int rule = 0;

            tempFilePath = fileList.TopItem.SubItems[1].Text +
                '\\' + fileList.TopItem.Text;
            try
            {
                tempStreamReader = new StreamReader(tempFilePath);
                tempString = tempStreamReader.ReadLine();
                tempStreamReader.Close();
                varName = tempString.Substring(0, tempString.IndexOf('('));
                if (varName.Contains(UtilityParameters.defaultPrefix))
                {
                    tempString = varName;
                    UtilityFunctions.ChangeVarNameToValid(ref varName, rule);
                    if (!tempString.Equals(varName))
                    {
                        varNameBox.BackColor = Color.Yellow;
                    }
                    else
                    {
                        varNameBox.BackColor = Color.LightGreen;
                    }
                    varNameBoxAutoChange = !varName.Equals(varNameBox.Text);
                    varNameBox.Text = varName;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取文件错误：" + fileList.TopItem.Text + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            varNameBox.BackColor = Color.Yellow;
            varName = UtilityParameters.defaultPrefix;
            varNameBox.Text = varName;
            BalloonTip ballon = new BalloonTip("请手动输入变量名", varNameBox);
            fileList.TopItem.BackColor = Color.Red;
            genFileButton.Enabled = true;
        }
        private void GetDataAndSaveFile()
        {
            (double[][] dataSource, double[][] pos) = GetData();
            if (null == dataSource)
            {
                return;
            }
            double[] result = Sum(dataSource);
            SaveFile(result, pos);
        }

        private (double[][] data, double[][] pos) GetData()
        {
            int rows = -1;
            int i = 0;
            string fileString;
            double[] data, p;
            string filePath;
            double offset, ratio;
            double[][] dataSource = new double[fileList.Items.Count][];
            double[][] pos = new double[fileList.Items.Count][];
            double r;          

            foreach (ListViewItem tempItem in fileList.Items)
            {
                filePath = tempItem.SubItems[1].Text + '\\' + tempItem.Text;
                string ext = Path.GetExtension(filePath);
                try
                {
                    fileString = File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件错误：" + tempItem.Text + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempItem.BackColor = Color.Red;
                    return (null, null);
                }

                try
                {                    
                    if (ext.Equals(".txt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        r = 1;
                        (data, p) = FormatorManager.ReadFormatedData(outDataFormat, fileString);
                    }
                    else
                    {
                        data = ManuManager.GetDataByExtWithDot(ext, fileString, UNIT.mm);
                        p = ManuManager.GetPosMMByExtWithDot(ext, fileString);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件格式错误：" + tempItem.Text + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempItem.BackColor = Color.Red;
                    return (null, null);
                }

                

                //Check if length is same
                if (-1 == rows)
                {                    
                    rows = data.Length;
                }
                else
                {
                    if (data.Length != rows)
                    {
                        MessageBox.Show("数据维度不相同：" + filePath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempItem.BackColor = Color.Red;
                        return (null, null);
                    }
                }

                //Flip
                if (tempItem.SubItems[3].Text == "Yes")
                {
                    List<double> ldata = new List<double>(data);
                    ldata.Reverse();
                    data = ldata.ToArray();
                }

                //Ratio and offset
                try
                {
                    ratio = double.Parse(tempItem.SubItems[2].Text);
                    offset = double.Parse(tempItem.SubItems[4].Text);
                }
                catch
                {
                    MessageBox.Show("权重或偏移值错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempItem.BackColor = Color.Red;
                    return (null, null);
                }

                dataSource[i] = data.Select(d => (d + offset) * ratio).ToArray();
                pos[i] = p;
                i++;
            }

            return (dataSource, pos);
        }

        private double[] Sum(double[][] dataSource)
        {
            int rn = dataSource[0].Length;
            double[] result = new double[rn];

            foreach (double[] d in dataSource)
            {
                for (int i = 0; i < rn; i++)
                {
                    result[i] += d[i];
                }
            }

            return result;
        }

        private void SaveFile(double[] data, double[][] pos)
        {
            string tempPath = defaultPath + '\\' + defaultFileName + ".txt";
            int n = data.Length;
            int colNum;
            try
            {
                colNum = Convert.ToInt16(outDataColNum);
                if (colNum <= 0 || colNum > 50)
                {
                    throw new Exception();
                }
            }
            catch
            {
                colNum = 7;
                outDataColNum = 7;
            }

            if (outDataFormat == DataFormator.AeroTech)
            {
                n = (int)Math.Ceiling((double)data.Length / colNum);
            }

            saveFileDialog.InitialDirectory = defaultPath;
            saveFileDialog.FileName = defaultFileName + "_Converted";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tempPath = saveFileDialog.FileName;
                string[] tempString = FormatorManager.FormatData(outDataFormat, data, pos[0],  varName, "", colNum);

                try
                {
                    File.WriteAllLines(tempPath, tempString);
                    savedFilePath = tempPath;
                    saved = true;
                    openSavedFileButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存文件错误：" + defaultFileName + ".txt\n" +
                        ex.Message, "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }       

        private bool ExistFile(string line, ref ListViewItem item)
        {
            string tempFileName = line;
            foreach (ListViewItem tempItem in fileList.Items)
            {
                if (tempFileName.Equals(tempItem.SubItems[1].Text + '\\' + tempItem.Text))
                {
                    item = tempItem;
                    return true;
                }
            }
            return false;
        }

        private void OpenSelectedItem()
        {
            ListViewItem tempItem;

            if (fileList.SelectedItems.Count == 0)
            {
                OpenFolder();
                return;
            }

            tempItem = fileList.SelectedItems[0];
            try
            {
                System.Diagnostics.Process.Start(tempItem.SubItems[1].Text + '\\' 
                    + tempItem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件错误：" + tempItem.SubItems[1].Text + '\\' 
                    + tempItem.Text + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteItems()
        {
            ListView.SelectedListViewItemCollection tempItem = fileList.SelectedItems;
            int index;
            foreach (ListViewItem selectedItem in tempItem)
            {
                index = tempItem.IndexOf(selectedItem);
                selectedItem.Remove();
            }

            ListViewItem tempTop = fileList.TopItem;
            if (null != tempTop)
            {
                ChangeVarName();
            }
            else
            {
                fileList.Scrollable = false;
                FileListFill();
            }
        }

        private void ClearList()
        {
            fileList.Items.Clear();
            fileList.Scrollable = false;
            FileListFill();
        }
    }

    partial class MergeWindow
    {
        private Size[] offset = new Size[2];
        private AutoCompleteStringCollection pathAutoComplete = new AutoCompleteStringCollection();
        private string defaultPath;
        private string defaultFileName;
        private string[] openFileList;
        private string varName;
        private bool saved = false;
        private string savedFilePath;
        private bool varNameBoxAutoChange = false;
        private bool[] dropFileIndex;
        private bool dropFolder;

        public DataFormator outDataFormat;
        public decimal outDataColNum;

        private delegate void voidFunction();
        List<voidFunction> functionList = new List<voidFunction>();
        int ColumnCount
        { get { return fileList.Columns.Count; } }

        int AverageWidth
        { get { return fileList.Width / ColumnCount; } }
    }
}