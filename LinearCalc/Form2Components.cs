using System;
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
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.fileList.Scrollable = false;
            FileListFill();
            this.fileList.LabelEdit = false;
            this.offset[0] = this.Size - this.fileList.Size;
            this.SizeChanged += new EventHandler(this.FormSize_Change);
            this.openSavedFileButton.Enabled = false;
            this.fileList.MouseDoubleClick += new MouseEventHandler(fileList_MouseDoubleClick);
            this.fileList.ItemSelectionChanged+=new ListViewItemSelectionChangedEventHandler(fileList_ItemSelectChanged);
            this.fileList.DragEnter += FileList_DragEnter;
            this.fileList.DragDrop += FileList_DragDrop;
            this.fileFlipCheckBox.Click += FileFlipCheckBox_Click;
            this.KeyDown += Form2_KeyDown;
            FunctionAdder();
            this.Activate();
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
            this.functionList.AddRange(new List<voidFunction>
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
                    System.Diagnostics.Process.Start(this.savedFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件错误：" + this.savedFilePath + ex.Message, "错误",
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
            ListViewItem tempTop = this.fileList.TopItem;
            if (null != tempTop)
            {
                emptyTop = false;
                this.defaultPath = this.fileList.Items[this.fileList.Items.Count - 1].SubItems[1].Text;
                this.defaultFileName = this.fileList.Items[this.fileList.Items.Count - 1].Text;
                this.addFileDialog.InitialDirectory = this.defaultPath;
                this.addFileDialog.FileName = this.defaultFileName;
            }
            else
            {
                emptyTop = true;
                this.addFileDialog.InitialDirectory = this.defaultPath;
                this.addFileDialog.FileName = this.defaultFileName;
            }

            OpenFileDialogProcess(emptyTop);
        }

        private void GenerateFile()
        {
            if (this.fileList.Items.Count < 1)
            {
                OpenFolder();
            }

            if (this.fileList.Items.Count < 1)
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
                this.Close();
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
            ListView.SelectedListViewItemCollection tempItems = this.fileList.SelectedItems;

            foreach (ListViewItem tempItem in tempItems)
            {
                try
                {
                    tempItem.SubItems[3].Text = this.fileFlipCheckBox.Checked ? "Yes" : "No";
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
            if (this.addFileDialog.ShowDialog() == DialogResult.OK)
            {                
                this.openFileList = this.addFileDialog.FileNames;
                AddItem(emptyTop);
            }
        }

        private void AddItem(bool emptyTop)
        {
            this.fileList.Scrollable = true;
            ListViewItem tempItem;
            foreach (String line in this.openFileList)
            {
                if (ExistFile(line))
                {
                    continue;
                }
                tempItem = new ListViewItem(Path.GetFileNameWithoutExtension(line));
                tempItem.SubItems.Add(Path.GetDirectoryName(line));
                tempItem.SubItems.Add("1.0");
                tempItem.SubItems.Add("No");
                tempItem.SubItems.Add("0.0");
                this.fileList.Items.Add(tempItem);
                if (emptyTop)
                {
                    this.defaultPath = this.fileList.Items[this.fileList.Items.Count - 1].SubItems[1].Text;
                    this.defaultFileName = this.fileList.Items[this.fileList.Items.Count - 1].Text;
                    ChangeVarName();
                    emptyTop = false;
                }
            }
            this.fileList.AutoResizeColumn(0,ColumnHeaderAutoResizeStyle.ColumnContent);
            this.fileList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.fileList.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
            this.fileList.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void FileGenButtonUpdate()
        {
            if (this.fileList.Items.Count >= 2)
            {
                this.genFileButton.Enabled = true;
            }
            else
            {
                this.genFileButton.Enabled = false;
            }
        }

        private void ChangeVarName()
        {
            String tempString;
            String tempFilePath;
            StreamReader tempStreamReader;
            int rule = 0;

            tempFilePath = this.fileList.TopItem.SubItems[1].Text + 
                '\\' + this.fileList.TopItem.Text + ".txt";
            try
            {
                tempStreamReader = new StreamReader(tempFilePath);
                tempString = tempStreamReader.ReadLine();
                tempStreamReader.Close();
                this.varName = tempString.Substring(0, tempString.IndexOf('('));
                if (this.varName.Contains(UtilityParameters.defaultPrefix))
                {
                    tempString = this.varName;                    
                    UtilityFunctions.ChangeVarNameToValid(ref this.varName, rule);
                    if (!tempString.Equals(this.varName))
                    {
                        this.varNameBox.BackColor = Color.Yellow;
                    }
                    else
                    {
                        this.varNameBox.BackColor = Color.LightGreen;
                    }
                    this.varNameBoxAutoChange = !this.varName.Equals(this.varNameBox.Text);
                    this.varNameBox.Text = this.varName;                                                     
                    return;
                }
               /* MessageBox.Show("变量名不正确：" + tempString.Substring(0, tempString.IndexOf('(')) + '@' + 
                    this.fileList.TopItem.Text + ".txt", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);*/
            }
            catch(Exception ex)
            {
                if (outDataFormatList.AeroTech == outDataFormat) return;
                MessageBox.Show("读取文件错误：" + this.fileList.TopItem.Text + ".txt" + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
            this.varNameBox.BackColor = Color.Yellow;
            this.varName = UtilityParameters.defaultPrefix;
            this.varNameBox.Text = this.varName;
            BalloonTip ballon = new BalloonTip("请手动输入变量名", this.varNameBox);
            this.fileList.TopItem.BackColor = Color.Red;
            this.genFileButton.Enabled = true;
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
            string tempString1;
            String[] tempString;
            String filePath;

            foreach (ListViewItem tempItem in this.fileList.Items)
            {
                filePath = tempItem.SubItems[1].Text + '\\' + tempItem.Text + ".txt";
                try
                {
                    tempString1 = File.ReadAllText(filePath);
                    tempString = tempString1.Split(new[] { '\r', '\n', '\t' },
                        StringSplitOptions.RemoveEmptyEntries);
                }
                catch(Exception ex)
                {                    
                    MessageBox.Show("打开文件错误：" + tempItem.Text + ".txt" + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataSource = null;
                    tempItem.BackColor = Color.Red;
                    return;
                }

                if (tempItem.SubItems[3].Text == "Yes")
                {
                    List<String> tl = new List<string>(tempString);
                    tl.Reverse();
                    tempString = tl.ToArray();
                }
               

                if (-1 == rows)
                {
                    rows = tempString.Length;
                    dataSource = new double[rows + 2, this.fileList.Items.Count];
                }
                else
                {
                    if (tempString.Length != rows)
                    {
                        MessageBox.Show("数据维度不相同：" + filePath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempItem.BackColor = Color.Red;
                        dataSource = null;
                        return;
                    }
                }
                double result;
                bool tryResult;

                foreach (String line in tempString)
                {
                    int index = line.IndexOf('=');
                    tryResult = double.TryParse(line.Substring(index + 1, line.Length - index - 1), out result);
                    if (tryResult)
                    {
                        dataSource[j, i] = result;
                    }
                    else
                    {                       
                        MessageBox.Show("数据有错误：" + filePath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tempItem.BackColor = Color.Red;
                        dataSource = null;
                        return;
                    }                    
                    j++;
                }

                tryResult = double.TryParse(tempItem.SubItems[2].Text, out result);
                if (tryResult)
                {
                    dataSource[j, i] = result;
                }
                else
                {
                    MessageBox.Show("读取数据错误：" + filePath, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tempItem.BackColor = Color.Red;
                    dataSource = null;
                    return;
                }
                j++;

                tryResult = double.TryParse(tempItem.SubItems[4].Text, out result);
                if (tryResult)
                {
                    dataSource[j, i] = result;
                }
                else
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
                    result[i] += (dataSource[i, j] + dataSource[dataSource.GetLength(0) - 1, j]) * dataSource[dataSource.GetLength(0) - 2, j];
                }
                j = 0;                
            }
        }

        private void SaveFile(double[] result)
        {
            String tempPath = this.defaultPath + '\\' + this.defaultFileName + ".txt";
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

            if (outDataFormat == outDataFormatList.AeroTech)
            {
                n = (int)Math.Ceiling((double)result.Length / colNum);
            }
            String[] tempString = new String[n];
            int i = 0;

            this.saveFileDialog.InitialDirectory = this.defaultPath;
            this.saveFileDialog.FileName = this.defaultFileName + "_Converted";

            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                tempPath = this.saveFileDialog.FileName;
                foreach (String line in tempString)
                {
                    tempString[i] = OutDataFormator(i, result);
                    i++;
                }                

                try
                {
                    File.WriteAllLines(tempPath, tempString);
                    this.savedFilePath = tempPath;
                    this.saved = true;
                    this.openSavedFileButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存文件错误：" + this.defaultFileName + ".txt\n" +
                        ex.Message, "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }            
        }

        string OutDataFormator(int lineNum, double[] result)
        {
            switch (outDataFormat)
            {
                case outDataFormatList.ACS:
                    return this.varName + '(' +
                        lineNum + ")=" + result[lineNum].ToString();
                case outDataFormatList.AeroTech:
                    return AeroTechDataPrint(lineNum,result);
                default: throw new NotImplementedException();
            }
        }

        string AeroTechDataPrint(int lineNum, double[] result)
        {
            int colNum;
            colNum = Convert.ToInt16(outDataColNum);
            string s = "";
            for (int i = lineNum * colNum; i < result.Length && i < lineNum * colNum + colNum; i++)
            {
                s += String.Format("{0:0.#####}\t", result[i] );
            }
            return s.TrimEnd();
        }

        private bool ExistFile(String line)
        {
            String tempFileName = Path.GetDirectoryName(line) + '\\' + Path.GetFileNameWithoutExtension(line);
            foreach (ListViewItem tempItem in this.fileList.Items)
            {
                if (tempFileName.Equals(tempItem.SubItems[1].Text+'\\'+tempItem.Text))
                {
                    return true;
                }
            }
            return false;
        }

        private void OpenSelectedItem()
        {
            ListViewItem tempItem;

            if (this.fileList.SelectedItems.Count == 0)
            {
                OpenFolder();
                return;
            }

            tempItem = this.fileList.SelectedItems[0];
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
            ListView.SelectedListViewItemCollection tempItem = this.fileList.SelectedItems;
            int index;
            foreach (ListViewItem selectedItem in tempItem)
            {
                index = tempItem.IndexOf(selectedItem);
                selectedItem.Remove();
            }

            ListViewItem tempTop = this.fileList.TopItem;
            if (null != tempTop)
            {
                ChangeVarName();
            }
            else
            {
                this.fileList.Scrollable = false;
                FileListFill();
            }
        }

        private void ClearList()
        {
            this.fileList.Items.Clear();
            this.fileList.Scrollable = false;
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

        public outDataFormatList outDataFormat;
        public decimal outDataColNum;

        private delegate void voidFunction();
        List<voidFunction> functionList = new List<voidFunction>();
        int ColumnCount
        { get {return fileList.Columns.Count; } }

        int AverageWidth
        { get { return fileList.Width / ColumnCount; } }
    }
}