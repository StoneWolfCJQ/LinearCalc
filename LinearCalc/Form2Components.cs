﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utilities;

namespace LinearCalc
{
    partial class Form2
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
            String pressedKeyS = e.KeyCode.ToString();
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

        public void SetDefault(String setPath, String fileName)
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

        private void AddItem(bool emptyTop)
        {
            fileList.Scrollable = true;
            ListViewItem tempItem;
            foreach (String line in openFileList)
            {
                if (ExistFile(line))
                {
                    continue;
                }
                tempItem = new ListViewItem(Path.GetFileName(line));
                tempItem.SubItems.Add(Path.GetDirectoryName(line));
                tempItem.SubItems.Add("1.0");
                tempItem.SubItems.Add("No");
                tempItem.SubItems.Add("0.0");
                fileList.Items.Add(tempItem);
                if (emptyTop)
                {
                    defaultPath = fileList.Items[fileList.Items.Count - 1].SubItems[1].Text;
                    defaultFileName = Path.GetFileNameWithoutExtension(fileList.Items[fileList.Items.Count - 1].Text);
                    ChangeVarName();
                    emptyTop = false;
                }
            }
            fileList.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            fileList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            fileList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            fileList.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
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
            if (DataFormator.AeroTech == outDataFormat)
                return;

            String tempString;
            String tempFilePath;
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
            double[,] dataSource;
            double[] result;
            GetData(out dataSource);
            if (null == dataSource)
            {
                return;
            }
            CalcMean(dataSource, out result);
            SaveFile(result);
        }

        private void GetData(out double[,] dataSource)
        {
            int rows = -1;
            int i = 0, j = 0;
            dataSource = new double[1, 1];
            string fileString;
            double[] data;
            String filePath;

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
                    dataSource = null;
                    tempItem.BackColor = Color.Red;
                    return;
                }

                try
                {                    
                    if (ext.Equals(".txt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        data = FormatorManager.ReadFormatedData(DataFormator.ACS, fileString);
                    }
                    else
                    {
                        data = ManuManager.GetDataByExtWithDot(ext, fileString, UNIT.mm);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("文件格式错误：" + tempItem.Text + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataSource = null;
                    tempItem.BackColor = Color.Red;
                    return;
                }

                if (tempItem.SubItems[3].Text == "Yes")
                {
                    List<double> tl = new List<double>(data);
                    tl.Reverse();
                    data = tl.ToArray();
                }


                if (-1 == rows)
                {
                    rows = data.Length;
                    dataSource = new double[rows + 2, fileList.Items.Count];
                }
                else
                {
                    if (data.Length != rows)
                    {
                        MessageBox.Show("数据维度不相同：" + filePath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempItem.BackColor = Color.Red;
                        dataSource = null;
                        return;
                    }
                }

                foreach (double d in data)
                {
                    dataSource[j, i] = d;
                    j++;
                }

                try
                {
                    dataSource[j, i] = double.Parse(tempItem.SubItems[2].Text);
                }
                catch
                {
                    MessageBox.Show("读取数据错误：" + filePath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempItem.BackColor = Color.Red;
                    dataSource = null;
                    return;
                }
                j++;

                try
                {
                    dataSource[j, i] = double.Parse(tempItem.SubItems[4].Text);
                }
                catch
                {
                    MessageBox.Show("读取数据错误：" + filePath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempItem.BackColor = Color.Red;
                    dataSource = null;
                    return;
                }
                j = 0;
                i++;
            }
        }

        private void CalcMean(double[,] dataSource, out double[] result)
        {
            int i = 0, j = 0;
            int rows = dataSource.GetLength(0) - 2;
            int columns = dataSource.GetLength(1);
            result = new double[rows];

            for (; i < rows; i++)
            {
                for (j = 0; j < columns; j++)
                {
                    result[i] += (dataSource[i, j] + dataSource[dataSource.GetLength(0) - 1, j]) 
                        * dataSource[dataSource.GetLength(0) - 2, j];
                }
                j = 0;
            }
        }

        private void SaveFile(double[] result)
        {
            String tempPath = defaultPath + '\\' + defaultFileName + ".txt";
            int n = result.Length;
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
                n = (int)Math.Ceiling((double)result.Length / colNum);
            }

            saveFileDialog.InitialDirectory = defaultPath;
            saveFileDialog.FileName = defaultFileName + "_Converted";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tempPath = saveFileDialog.FileName;
                String[] tempString = FormatorManager.FormatData(outDataFormat, result, varName, "", colNum);

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

        private bool ExistFile(String line)
        {
            String tempFileName = Path.GetDirectoryName(line) + '\\' + Path.GetFileNameWithoutExtension(line);
            foreach (ListViewItem tempItem in fileList.Items)
            {
                if (tempFileName.Equals(tempItem.SubItems[1].Text + '\\' + tempItem.Text))
                {
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
                System.Diagnostics.Process.Start(tempItem.SubItems[1].Text + '\\' + tempItem.Text + ".txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件错误：" + tempItem.SubItems[1].Text + '\\' + tempItem.Text
                    + ".txt" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    partial class Form2
    {
        private Size[] offset = new Size[2];
        private AutoCompleteStringCollection pathAutoComplete = new AutoCompleteStringCollection();
        private String defaultPath;
        private String defaultFileName;
        private String[] openFileList;
        private String varName;
        private bool saved = false;
        private String savedFilePath;
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