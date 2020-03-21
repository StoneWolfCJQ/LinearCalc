using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Dialogs;
using Utilities;

namespace LinearCalc
{
    public partial class Form1
    {
        #region Init      
        private void InitializeCustomComponent()
        {
            this.DragDrop += new DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new DragEventHandler(this.Form1_DragEnter);
            this.extDropList.SelectedIndexChanged += new EventHandler(this.extDropList_SelectedIndexChanged);
            this.suffixTextBox.KeyPress += SuffixTextBox_KeyPress;
            this.savePathText.MouseHover += new EventHandler(this.savePathText_MouseHover);
            this.openPathText.MouseHover += new EventHandler(this.openPathText_MouseHover);
            this.menuChildFolder.Select += new EventHandler(this.menuChildFolder_Select);
            this.menuRootFile.Popup += new EventHandler(this.menuRootFile_Popup);
            GetOrSetReg();
            this.infoTextLabel.Text = "";
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.extDropList.SelectedIndex = (int)manufactoryList.RENISHAW;
            //this.Text += UtilityParameters.version;
            this.openFileNameBox.KeyPress += OpenFileNameBox_KeyPress;
            this.saveFileNameBox.KeyPress += SaveFileNameBox_KeyPress;

            //this.openFileNameBox.AutoCompleteCustomSource = this.openFileAutoCompleteList;

            FunctionAdder();
            MasterSLP();
            StartArgHandler();                      
        }

        #endregion

        #region StartFunc

        private void StartArgHandler()
        {
            String[] tempArg = Program.startArg;
            String ext;
            String fileName;
            FileAttributes attr;
            bool isFile;
            int index = -1;

            if (tempArg.Length != 1)
            {
                return;
            }

            fileName = tempArg[0];
            try
            {
                attr = File.GetAttributes(fileName);
            }
            catch (Exception ex)
            {
                return;
            }
            isFile = !attr.HasFlag(FileAttributes.Directory);
            if (isFile)
            {
                ext = Path.GetExtension(fileName);
                index = Array.IndexOf(UtilityParameters.manuExtList, ext);

                if (-1 != index)
                {
                    this.openFileReturn = true;
                    this.usrInputOpenFileName = false;

                    this.openFileExt = Path.GetExtension(fileName);
                    this.manufactory = (manufactoryList)index;

                    this.openFileName = Path.GetFileNameWithoutExtension(fileName);
                    this.openFileExt = Path.GetExtension(fileName);
                    this.openFullPath = Path.GetDirectoryName(fileName);

                    FileStreamHandler();
                }
            }
            else
            {
                Program.currentPath = fileName;
                this.openFullPath = fileName;
                if (this.autoSaveFileName)
                {
                    this.saveFullPath = this.openFullPath;
                }
                MasterSLP();
            }
        }

        private void GetOrSetReg()
        {
            String keyValue;
            UtilityFunctions.GetReg(out keyValue);
            if (("" == keyValue) || (null == keyValue))
            {
                this.openFullPath = Program.currentPath;
                this.saveFullPath = Program.currentPath;
                UtilityFunctions.SetReg(Program.currentPath);
            }
            else
            {                
                this.openFullPath = keyValue;
                this.saveFullPath = keyValue;
                Program.currentPath = this.openFullPath;
            }
        }
        #endregion

        #region HotKey
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                String pressedKeyS = e.KeyCode.ToString();
                if (pressedKeyS.Length == 1)
                {
                    Char pressedKey = pressedKeyS[0];
                    HotKeyHandle(pressedKey);
                }
            }
        }

        private void FunctionAdder()
        {
            functionList.AddRange(new List<voidFunction>{ OpenFile,
                SaveFile,
                OpenFolder,
                MergeTool,
                ScriptFileTool,
                GenerateFile,
                OptionsPage,
                HelpPage,
                AboutPage,
                Quit });
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
            this.openFileDialog.FileName = this.openFileName;
            this.openFileDialog.InitialDirectory = this.openFullPath;
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.openFileReturn = true;
                this.usrInputOpenFileName = false;
                this.openStream = this.openFileDialog.OpenFile();
                if (null != this.openStream)
                {
                    this.openFileStream = this.openStream as FileStream;
                    using (this.openFileStream)
                    {
                        this.openFileName = Path.GetFileNameWithoutExtension(this.openFileStream.Name);
                        this.openFileExt = Path.GetExtension(this.openFileStream.Name);
                        this.openFullPath = Path.GetDirectoryName(this.openFileStream.Name);
                    }
                    this.openStream.Close();
                    this.openFileAutoCompleteList.Add(this.openFileName);
                    FileStreamHandler();
                }
                else
                {
                    MessageBox.Show("文件无法打开或错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return;
        }

        private void SaveFile()
        {
            this.saveDiagResult = false;
            this.saveFileDialog.FileName = this.saveFileName;
            this.saveFileDialog.InitialDirectory = this.saveFullPath;
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.saveDiagResult = true;
                this.saveFileReturn = true;
                this.usrInputSaveFileName = false;
                this.saveFileName = Path.GetFileNameWithoutExtension(this.saveFileDialog.FileName);
                this.saveFullPath = Path.GetDirectoryName(this.saveFileDialog.FileName);

                this.saveFileNameBox.Text = this.saveFileName;

                SPSimplify();
            }

            return;
        }

        private void OpenFolder()
        {
            CommonOpenFileDialog openFlg = new CommonOpenFileDialog();
            openFlg.InitialDirectory = Program.currentPath;
            openFlg.IsFolderPicker = true;
            if (openFlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Program.currentPath = openFlg.FileName;
                this.openFullPath = Program.currentPath;
                this.saveFullPath = Program.currentPath;
                this.openPathText.Text = Program.currentPath;
                this.savePathText.Text = Program.currentPath;

                MasterSLP();
            }
        }

        private void MergeTool()
        {
            MergeFormRun();
        }

        private void ScriptFileTool()
        {
            ScriptFormRun(task.MEASURE);
        }

        private void GenerateFile()
        {
            if (CheckFileNameEmpty())
            {
                return;
            }

            ReadFileAndGetData();
        }

        private void OptionsPage()
        {
            OptionsForm OptionsForm1 = new OptionsForm(this.autoOpen, this.autoOverWrite, this.prefix);
            OptionsForm1.ShowDialog();
            this.autoOpen = OptionsForm1.autoOpen;
            this.autoOverWrite = OptionsForm1.autoOverwrite;
            this.prefix = OptionsForm1.prefix;
        }

        private void HelpPage()
        {
            MessageBox.Show("施工中，请等待！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AboutPage()
        {
            AboutForm AboutForm1 = new AboutForm();
            AboutForm1.ShowDialog();
        }

        private void Quit()
        {
            DialogResult result = MessageBox.Show("是否退出软件", "提示", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (DialogResult.OK == result)
            {
                this.Close();
            }            
        }
#endregion

        #region FilePathSim
        private void MasterSLP()
        {
            //this.openPathText.Visible = false;
            //this.savePathText.Visible = false;

            this.openPathText.Text = this.openFullPath;
            this.savePathText.Text = this.saveFullPath;

            SimplifyLongPath(ref this.openPathText);
            SimplifyLongPath(ref this.savePathText);

            this.openPathText.Location = new System.Drawing.Point(this.openFileNameBox.Location.X - 
                this.openPathText.Size.Width, this.openPathText.Location.Y);
            this.savePathText.Location = new System.Drawing.Point(this.saveFileNameBox.Location.X - 
                this.savePathText.Size.Width, this.savePathText.Location.Y);

            this.openFileSPath = this.openPathText.Text;
            this.saveFileSPath = this.savePathText.Text;

            this.openPathText.Visible = true;
            this.savePathText.Visible = true;
        }

        private void SPSimplify()
        {
            //this.savePathText.Visible = false;

            this.savePathText.Text = this.saveFullPath;

            SimplifyLongPath(ref this.savePathText);

            this.savePathText.Location = new System.Drawing.Point(this.saveFileNameBox.Location.X - this.savePathText.Size.Width, this.savePathText.Location.Y);

            this.saveFileSPath = this.savePathText.Text;

            this.savePathText.Visible = true;
        }

        private void SimplifyLongPath(ref Label textLabel, int startIndex = 0,
           bool isFirstIndex = false, bool isTrimed = false)
        {
            char[] temp = textLabel.Text.ToCharArray();
            textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            while (textLabel.Size.Width <= (int)UtilityParameters.MAX_PATH_WIDTH * UtilityParameters.MAX_PATH_WIDTH_RATIO)
            {
                if (textLabel.Size.Width <= UtilityParameters.MAX_PATH_WIDTH)
                {
                    if (!textLabel.Text.EndsWith(":\\"))
                    {
                        textLabel.Text += '\\';
                    }
                    return;
                }
                else
                {
                    textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", textLabel.Font.Size - 0.005F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
            }

            int midPathLeng;
            int firstRIndex, lastRIndex;
            String pathText;

            pathText = textLabel.Text;
            if (0 == startIndex)
            {
                midPathLeng = pathText.Length / 2;
                midPathLeng = '\\' == temp[midPathLeng] ? midPathLeng - 1 : midPathLeng;
            }
            else
            {
                midPathLeng = startIndex;
                if (':' == pathText[midPathLeng])
                {
                    midPathLeng += 6;
                }
            }
            firstRIndex = pathText.LastIndexOf('\\', midPathLeng);
            lastRIndex = pathText.IndexOf('\\', midPathLeng);

            if (-1 == lastRIndex)
            {
                lastRIndex = pathText.Length - 1;
                if (pathText.Length <= 3 * (lastRIndex - firstRIndex))
                {
                    isTrimed = pathText.Substring(lastRIndex - 2, 3).Equals("...");
                    pathText = pathText.Remove(isTrimed ? lastRIndex - 3 : lastRIndex);
                    pathText += "...";
                    textLabel.Text = pathText;
                    SimplifyLongPath(ref textLabel, firstRIndex + 1, false);
                    return;
                }
                else
                {
                    firstRIndex--;
                    isTrimed = pathText.Substring(firstRIndex - 2, 3).Equals("...");
                    SimplifyLongPath(ref textLabel, isTrimed ? firstRIndex - 4 : firstRIndex, true);
                    return;
                }
            }

            if (':' == pathText[firstRIndex - 1])
            {
                if (pathText.Length <= 3 * (lastRIndex - firstRIndex))
                {
                    lastRIndex--;
                    isTrimed = pathText.Substring(lastRIndex - 2, 3).Equals("...");
                    pathText = pathText.Remove(isTrimed ? lastRIndex - 3 : lastRIndex, isTrimed ? 4 : 1);
                    pathText = pathText.Insert(isTrimed ? lastRIndex - 3 : lastRIndex, "...");
                    textLabel.Text = pathText;
                    SimplifyLongPath(ref textLabel, firstRIndex + 1, false);
                    return;
                }
                else
                {
                    lastRIndex++;
                    isTrimed = pathText.Substring(lastRIndex, 3).Equals("...");
                    SimplifyLongPath(ref textLabel, isTrimed ? lastRIndex + 4 : lastRIndex, false);
                    return;
                }
            }

            try
            {
                pathText = pathText.Remove(firstRIndex + 1, 0 == startIndex ? lastRIndex - firstRIndex - 1 : lastRIndex - firstRIndex);
            }
            catch (Exception ex)
            {
                pathText = @"C\USERS\Desktop";// Directory.GetCurrentDirectory();
                ResetDefault();
                textLabel.Text = pathText;
                return;
            }

            if (0 == startIndex)
            {
                pathText = pathText.Insert(firstRIndex + 1, "...");
            }
            textLabel.Text = pathText;
            if (0 == startIndex)
            {
                SimplifyLongPath(ref textLabel, firstRIndex - 1, false);
            }
            else
            {
                SimplifyLongPath(ref textLabel, isFirstIndex ? firstRIndex - 5 : firstRIndex + 5, isFirstIndex ? false : true);
            }

            return;
        }
        #endregion

        private void ResetDefault()
        {
            String tempPath;
            Program.currentPath = @"C\USERS\Desktop";// Directory.GetCurrentDirectory();
            tempPath = Program.currentPath;
            this.openFullPath = tempPath;
            this.saveFullPath = tempPath;
            this.openFileName = "";
            this.saveFileName = "";
            this.openFileExt = ".rtl";
            this.manufactory = manufactoryList.RENISHAW;
            MessageBox.Show("文件名或路径名非法！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ReadFileAndGetData()
        {
            this.manufactory = (manufactoryList)Array.FindIndex(UtilityParameters.manuExtList,
                            s => s.Equals(this.openFileExt));
            try
            {
                this.openFileContent = File.ReadAllLines(this.openFullPath +'\\' +this.openFileName+ this.openFileExt,
                    Encoding.Default);
            }
            catch(Exception ex)
            {
                MessageBox.Show("打开文件错误：" + this.openFileName + this.openFileExt +"\n"+ ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetInfoText(infoText.FILE_OPEN_ERROR);
                return;
            }
            
            if (!FindTargetText())
            {
                return;
            }

            if (!GetData())
            {
                return;
            }

            Save2File();
            this.openFileAutoCompleteList.Add(this.openFileName);
        }

        private bool FindTargetText()
        {
            foreach (String line in this.openFileContent)
            {
                this.targetLineNum++;
                if (line.Equals(UtilityParameters.targetStringList[(int)this.manufactory]))
                {
                    return true;
                }               
            }

            this.targetLineNum = 0;
            SetInfoText(infoText.FILE_CONTENT_ERROR);
            
            return false;
        }

        private bool GetData()
        {
            bool noErrorRead = true;
            switch (this.manufactory)
            {
                case manufactoryList.RENISHAW: RenDataCalc(out noErrorRead); break;
                case manufactoryList.API: APIDataCalc(out noErrorRead); break;
                default: break;
            };

            return noErrorRead;
        }

        private void RenDataCalc(out bool noErrorRead)
        {
            noErrorRead = true;
            int tempLineNum = 0;
            int tempDataIndex;
            int masterIndex;
            int maxNum = 0;
            double tempFloat;
            double[,] reniMeasureData = new double[200, 4];
            
            foreach (String line in this.openFileContent)
            {
                tempLineNum++;
                if (tempLineNum > this.targetLineNum)
                {          
                    if (line.Equals(""))
                    {
                        break;
                    }

                    noErrorRead &= int.TryParse(line.Substring(0, 1), out masterIndex);
                    noErrorRead &= int.TryParse(line.Substring(4, 3), out tempDataIndex);
                    noErrorRead &= double.TryParse(line.Substring(7, line.Length - 8), out tempFloat);     

                    if (!noErrorRead)
                    {
                        SetInfoText(infoText.FILE_FORMAT_ERROR);
                        return;
                    }

                    if (maxNum < tempDataIndex)
                    {
                        maxNum = tempDataIndex;
                    }

                    if ((maxNum > 200) || (masterIndex > 4))
                    {
                        SetInfoText(infoText.DATA_OVERSIZE_ERROR);
                        noErrorRead = false;
                        return;
                    }

                    if ((tempFloat > 1e4) || (tempFloat < -1e4))
                    {
                        SetInfoText(infoText.DATA_FORMAT_ERROR);
                        noErrorRead = false;
                        return;
                    }
                    reniMeasureData[tempDataIndex - 1,masterIndex - 1] = tempFloat;
                }
            }

            this.maxDataNum = maxNum;
            this.targetLineNum = 0;

            while (0 < maxNum)
            {
                this.calcData[maxNum - 1] = -0.001 * ((reniMeasureData[maxNum - 1, 0] + reniMeasureData[maxNum - 1, 1] +
                                            reniMeasureData[maxNum - 1, 2] + reniMeasureData[maxNum - 1, 3]) / 4);
                maxNum--;
            }

            return;
        }

        private void APIDataCalc(out bool noErrorRead)
        {
            noErrorRead = true;
            char[] indexChar = { ' ', '\t' };
            double tempDouble;
            double[] tempDoubleArray = new double[200];
            int maxNum = 0;
            int tempLineNum = 0;
            int charIndex = -1;

            foreach (String line in this.openFileContent)
            {                
                tempLineNum++;
                if (tempLineNum > this.targetLineNum)
                {                    
                    if (line.Equals(""))
                    {
                        break;
                    }

                    maxNum++;
                    charIndex = line.LastIndexOfAny(indexChar);
                    if (-1==charIndex)
                    {
                        SetInfoText(infoText.DATA_FORMAT_ERROR);
                        noErrorRead = false;
                        return;
                    }

                    noErrorRead &= double.TryParse(line.Substring(charIndex), out tempDouble);
                    tempDoubleArray[maxNum - 1] = -tempDouble;      
                    
                    if (maxNum > 200)
                    {
                        SetInfoText(infoText.DATA_OVERSIZE_ERROR);
                        noErrorRead = false;
                        return;
                    }
                }
            }

            this.maxDataNum = maxNum;
            this.targetLineNum = 0;
            tempDoubleArray.CopyTo(this.calcData, 0);
            return;          
        }

        private void Save2File()
        {
            int i = 0;
            int n = maxDataNum;
            int colNum;
            try
            {
                colNum = Convert.ToInt16(OutDataColNum.Value);
                if (colNum <= 0 || colNum > 50)
                {
                    throw new Exception();
                }
            }
            catch
            {
                colNum = 7;
                OutDataColNum.Value = 7;
            }

            if (outDataFormat == outDataFormatList.AeroTech)
            {
                n = (int)Math.Ceiling((double)maxDataNum/colNum);
            }
            String[] writeString = new String[n];
            String tempSavePath;
            this.suffix = this.suffixTextBox.Text;         
            
            if (String.Empty == this.saveFileNameBox.Text)
            {
                SaveFile();
                if (!this.saveDiagResult)
                {
                    return;
                }
                if (1 == this.autoAppRule)
                {
                    this.suffixTextBox.Text = this.saveFileName;
                    ChangeSuffixBoxTextToValid();
                }                
            }

            tempSavePath = this.saveFullPath + '\\' + this.saveFileName + ".txt";

            while (File.Exists(tempSavePath) && (!autoOverWrite) && (this.usrInputSaveFileName))
            {
                DialogResult result = MessageBox.Show(this.saveFileName+".txt文件已存在，是否覆盖？", "提示", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                if (DialogResult.Yes == result)
                {                    
                    break;
                }
                else if (DialogResult.No == result)
                {
                    SaveFile();
                    if (!this.saveDiagResult)
                    {
                        return;
                    }
                    if (1 == this.autoAppRule)
                    {
                        this.suffixTextBox.Text = this.saveFileName;
                        ChangeSuffixBoxTextToValid();
                    }                    
                    tempSavePath = this.saveFullPath + '\\' + this.saveFileName + ".txt";
                }
                else
                {
                    return;
                }                            
            }
            this.usrInputSaveFileName = true;
            foreach (String line in writeString)
            {
                writeString[i] = OutDataFormator(i);
                i++;
            }

            try
            {
                File.WriteAllLines(tempSavePath, writeString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存文件错误："+this.saveFileName+".txt\n"+ex.Message, "保存错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetInfoText(infoText.FILE_SAVE_ERROR);
                return;
            }

            SetInfoText(infoText.FILE_SAVE_COMPLETE);
            this.saved = true;
            this.savedFilePath = tempSavePath;

            if (this.autoOpen)
            {
                try
                {
                    System.Diagnostics.Process.Start(tempSavePath);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("打开文件错误：" + this.saveFileName + ".txt\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return;
        }
        
        string OutDataFormator(int lineNum)
        {
            switch (outDataFormat)
            {
                case outDataFormatList.ACS:
                    return this.prefix + this.suffix + '(' + 
                        lineNum + ")=" + this.calcData[lineNum].ToString();
                case outDataFormatList.AeroTech:
                    return AeroTechDataPrint(lineNum);
                default:throw new NotImplementedException();
            }
        }

        string AeroTechDataPrint(int lineNum)
        {
            int colNum;
            colNum = Convert.ToInt16(OutDataColNum.Value);
            string s="";
            for (int i = lineNum * colNum; i < maxDataNum && i< lineNum * colNum + colNum; i++)
            {
                s += String.Format("{0:0.#####}\t",calcData[i]*1000);
            }
             return s.TrimEnd();
        }

        private void SetInfoText(infoText info)
        {
            this.infoTextLabel.Visible = false;
            this.infoTextLabel.ForeColor = System.Drawing.Color.Red;
            switch (info)
            {
                case infoText.FILE_FORMAT_ERROR:
                    MessageBox.Show("文件格式错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.infoTextLabel.Text = "文件格式有错误！";
                    break;
                case infoText.FILE_CONTENT_ERROR:
                    MessageBox.Show("文件内容错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.infoTextLabel.Text = "文件内容有错误！";
                    break;
                case infoText.DATA_OVERSIZE_ERROR:
                    MessageBox.Show("文件数据太多！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.infoTextLabel.Text = "文件数据太多！";
                    break;
                case infoText.DATA_FORMAT_ERROR:
                    MessageBox.Show("文件数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.infoTextLabel.Text = "数据不全，无法生成！";
                    break;
                case infoText.FILE_SAVE_ERROR:
                    this.infoTextLabel.Text = "无法保存txt文件";
                    break;
                case infoText.FILE_OPEN_ERROR:
                    this.infoTextLabel.Text = "无法打开干涉仪文件";
                    break;
                case infoText.FILE_SAVE_COMPLETE:
                    System.Media.SystemSounds.Asterisk.Play();
                    this.infoTextLabel.Text = "生成完毕！";
                    this.infoTextLabel.ForeColor = System.Drawing.Color.Green;
                    break;
                default:
                    this.infoTextLabel.Text = "";
                    break;
            }
            this.infoTextLabel.Location = new System.Drawing.Point(this.fileGenerateButton.Location.X - this.infoTextLabel.Width, this.infoTextLabel.Location.Y);
            this.infoTextLabel.Visible = true;
            return;
        }

        private void FileStreamHandler()
        {
            if (this.autoSaveFileName)
            {
                this.saveFileName = this.openFileName;
                this.saveFullPath = this.openFullPath;
            }

            Program.currentPath = this.openFullPath;
            this.manufactory = (manufactoryList)Array.FindIndex(UtilityParameters.manuExtList,
                s => s.Equals(this.openFileExt));

            this.openFileNameBox.Text = this.openFileName;
            this.extDropList.SelectedIndex = (int)this.manufactory;

            if (this.autoSaveFileName)
            {
                this.saveFileNameBox.Text = this.saveFileName;
            }

            MasterSLP();

            if (this.quickGen && this.fileGenerateButton.Enabled)
            {
                ReadFileAndGetData();
            }
        }

        private bool CheckFileNameValid(Control control)
        {
            if (control.Text.LastIndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                this.fileGenEnByte &= 0xFE;
                control.BackColor = System.Drawing.Color.Red;
                BalloonTip ballon = new BalloonTip("文件名不能包含有\n" + UtilityParameters.invalidFileName, control);
                this.fileGenerateButton.Enabled = (0xFF == this.fileGenEnByte);
                return false;
            }
            else
            {
                this.fileGenEnByte |= 0x01;
                control.BackColor = System.Drawing.SystemColors.Window;
                this.fileGenerateButton.Enabled = (0xFF == this.fileGenEnByte);
                return true;
            }            
        }        

        private void CheckSuffixValid(Control control)
        {
            String tempVarName = this.prefix + control.Text;
            if (UtilityFunctions.CheckVariableName(control, tempVarName,true,true))
            {
                if (this.autoApp)
                {
                    this.suffixTextBox.BackColor = System.Drawing.SystemColors.Control;
                }                
                this.fileGenEnByte |= 0x02;
                this.suffix = control.Text;
            }
            else
            {
                this.fileGenEnByte &= 0xFD;
            }
            this.fileGenerateButton.Enabled = (0xFF == this.fileGenEnByte);
        }

        private void ChangeSuffixBoxTextToValid()
        {
            int rule = 0;

            if (this.autoApp)
            {
                this.suffixTextBox.BackColor = System.Drawing.SystemColors.Control;
            }

            UtilityFunctions.ChangeVarNameToValid(this.suffixTextBox, rule, this.prefix, true);

            this.suffix = this.suffixTextBox.Text;
        }

        private bool CheckFileNameEmpty()
        {
            if ((String.Empty != this.openFileNameBox.Text) && (String.Empty != this.saveFileNameBox.Text))
            {
                return false;
            }
            else
            {
                if (String.Empty == this.openFileNameBox.Text)
                {
                    bool tempGen = this.quickGen;
                    this.quickGen = true;
                    OpenFile();
                    this.quickGen = tempGen;
                    /*this.openFileNameBox.BackColor = System.Drawing.Color.Yellow;
                    BalloonTip ballon = new BalloonTip("请输入文件名", this.openFileNameBox);*/
                }
                else if (String.Empty == this.saveFileNameBox.Text)
                {
                    ReadFileAndGetData();
                    /*this.saveFileNameBox.BackColor = System.Drawing.Color.Yellow;
                    BalloonTip ballon = new BalloonTip("请输入文件名", this.saveFileNameBox);*/
                }
                return true;
            }
        }

        private void MergeFormRun()
        {
            this.TopMost = false;

            if (!Program.mergeThreadStart)
            {
                this.onTopInt++;
                mergeForm.outDataColNum = OutDataColNum.Value;
                mergeForm.outDataFormat = outDataFormat;
                mergeForm.SetDefault(this.saveFullPath, this.saveFileName);
                Program.mergeThreadStart = true;
                Thread mergeDataThread = new Thread(MergeDataThread);
                mergeDataThread.IsBackground = true;
                mergeDataThread.SetApartmentState(ApartmentState.STA);
                mergeDataThread.Start();
            }
            else
            {
                mergeForm.Invoke((MethodInvoker)delegate () {
                    mergeForm.Activate();
                });
            }
        }

        void ChangeOutDataFormat(outDataFormatList odf)
        {
            foreach (MenuItem m in menuOutDataFormat.MenuItems)
            {
                string s1 = odf.ToString();
                string s2= m.Text.Substring(0, m.Text.IndexOf('('));
                if (string.Compare(s1,s2) == 0)
                {
                    m.Checked = true;
                }
                else
                {
                    m.Checked = false;
                }
            }
            outDataFormat = odf;
            if (odf == outDataFormatList.AeroTech)
            {
                OutDataColNumLabel.Visible = true;
                OutDataColNum.Visible = true;
            }
            else
            {
                OutDataColNumLabel.Visible = false;
                OutDataColNum.Visible = false;
            }

            mergeForm.outDataFormat = odf;
        }

        private void ScriptFormRun(task taskNum)
        {
            this.TopMost = false;

            if (!Program.scriptThreadStart)
            {
                this.onTopInt++;
                scriptForm = new Form3();
                scriptForm.SetTask(taskNum);
                Program.scriptThreadStart = true;
                Thread scriptThread = new Thread(ScriptThread);
                scriptThread.IsBackground = true;
                scriptThread.SetApartmentState(ApartmentState.STA);
                scriptThread.Start();
            }
            else
            {
                scriptForm.Invoke((MethodInvoker)delegate () {
                    scriptForm.ChangeTask(taskNum);
                });
                scriptForm.Invoke((MethodInvoker)delegate () {
                    scriptForm.Activate();
                });
            }
        }

        [STAThread]
        private void ScriptThread()
        {
            Application.Run(scriptForm);
            Program.scriptThreadStart = false;
            this.onTopInt--;
            if (0 == this.onTopInt)
            {
                this.Invoke((MethodInvoker)delegate () { this.TopMost=true; });
            }
        }

        [STAThread]
        private void MergeDataThread()
        {
            Application.Run(mergeForm);
            Program.mergeThreadStart = false;
            this.onTopInt--;
            if (0 == this.onTopInt)
            {
                this.Invoke((MethodInvoker)delegate () { this.TopMost = true; });
            }
            mergeForm = new Form2();
        }
    }

    #region Parameters
    public partial class Form1
    {
        private bool openFileReturn = false;
        private bool saveFileReturn = false;
        private bool usrInputOpenFileName = false;
        private bool usrInputSaveFileName = false;
        private String openFileName, saveFileName;
        private String openFileExt = ".rtl";
        private String openFileSPath, saveFileSPath;
        private Stream openStream, saveStream;
        private FileStream openFileStream, saveFileStream;
        private String openFullPath, saveFullPath;
        private String[] openFileContent;
        private String[] saveFileContent;
        private int onTopInt = 0;

        private bool quickGen = true;
        private bool autoApp = true;
        private int autoAppRule = 0;
        private bool autoOpen = true;
        private bool autoOverWrite = true;
        private bool autoSaveFileName = true;
        private bool saved = false;
        private String savedFilePath;
        private byte fileGenEnByte = 0xFF;
        private String suffix;
        private String prefix = UtilityParameters.defaultPrefix;

        private int targetLineNum = 0;
        private int maxDataNum;
        private double[] calcData=new double[200];
        private bool saveDiagResult = false;

        private Form2 mergeForm = new Form2();
        private Form3 scriptForm;

        private AutoCompleteStringCollection openFileAutoCompleteList = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection saveFileAutoCompleteList = new AutoCompleteStringCollection();        

        delegate void voidFunction();
        List<voidFunction> functionList = new List<voidFunction>();
        manufactoryList manufactory = manufactoryList.RENISHAW;
        outDataFormatList outDataFormat = outDataFormatList.ACS;
        
    }
    #endregion
}