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
    public partial class MainUI
    {
        #region Init      
        private void InitializeCustomComponent()
        {
            DragDrop += new DragEventHandler(Form1_DragDrop);
            DragEnter += new DragEventHandler(Form1_DragEnter);
            extDropList.SelectedIndexChanged += new EventHandler(extDropList_SelectedIndexChanged);
            suffixTextBox.KeyPress += SuffixTextBox_KeyPress;
            savePathText.MouseHover += new EventHandler(savePathText_MouseHover);
            openPathText.MouseHover += new EventHandler(openPathText_MouseHover);
            menuChildFolder.Select += new EventHandler(menuChildFolder_Select);
            menuRootFile.Popup += new EventHandler(menuRootFile_Popup);
            GetOrSetLastPath();
            infoTextLabel.Text = "";
            KeyPreview = true;
            extDropList.SelectedIndex = (int)manufactoryList.RENISHAW;
            openFileNameBox.KeyPress += OpenFileNameBox_KeyPress;
            saveFileNameBox.KeyPress += SaveFileNameBox_KeyPress;

            MasterSLP();
            StartArgHandler();
        }

        #endregion

        #region StartFunc

        private void StartArgHandler()
        {
            string[] tempArg = Program.startArg;
            string ext;
            string fileName;
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
                    openFileReturn = true;
                    usrInputOpenFileName = false;

                    openFileExt = Path.GetExtension(fileName);
                    manufactory = (manufactoryList)index;

                    openFileName = Path.GetFileNameWithoutExtension(fileName);
                    openFileExt = Path.GetExtension(fileName);
                    openFullPath = Path.GetDirectoryName(fileName);

                    FileStreamHandler();
                }
            }
            else
            {
                Program.currentPath = fileName;
                openFullPath = fileName;
                if (autoSaveFileName)
                {
                    saveFullPath = openFullPath;
                }
                MasterSLP();
            }
        }

        private void GetOrSetLastPath()
        {
            string keyValue;
            UtilityFunctions.GetLastPath(out keyValue);
            if (("" == keyValue) || (null == keyValue))
            {
                openFullPath = Program.currentPath;
                saveFullPath = Program.currentPath;
                UtilityFunctions.SetLastPath(Program.currentPath);
            }
            else
            {
                openFullPath = keyValue;
                saveFullPath = keyValue;
                Program.currentPath = openFullPath;
            }
        }
        #endregion

        #region EventHandler

        private void OpenFile()
        {
            openFileDialog.FileName = openFileName;
            openFileDialog.InitialDirectory = openFullPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileReturn = true;
                usrInputOpenFileName = false;
                openStream = openFileDialog.OpenFile();
                if (null != openStream)
                {
                    openFileStream = openStream as FileStream;
                    using (openFileStream)
                    {
                        openFileName = Path.GetFileNameWithoutExtension(openFileStream.Name);
                        openFileExt = Path.GetExtension(openFileStream.Name);
                        openFullPath = Path.GetDirectoryName(openFileStream.Name);
                        UtilityFunctions.SetLastPath(openFullPath);
                    }
                    openStream.Close();
                    openFileAutoCompleteList.Add(openFileName);
                    FileStreamHandler();
                }
                else
                {
                    MessageBox.Show("文件无法打开或错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return;
        }

        private void SelectSavePath()
        {
            saveDiagResult = false;
            saveFileDialog.FileName = saveFileName;
            saveFileDialog.InitialDirectory = saveFullPath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveDiagResult = true;
                saveFileReturn = true;
                usrInputSaveFileName = false;
                saveFileName = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
                saveFullPath = Path.GetDirectoryName(saveFileDialog.FileName);

                saveFileNameBox.Text = saveFileName;

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
                openFullPath = Program.currentPath;
                saveFullPath = Program.currentPath;
                openPathText.Text = Program.currentPath;
                savePathText.Text = Program.currentPath;
                UtilityFunctions.SetLastPath(Program.currentPath);

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
            OptionsForm OptionsForm1 = new OptionsForm(autoOpen, autoOverWrite, prefix);
            OptionsForm1.ShowDialog();
            autoOpen = OptionsForm1.autoOpen;
            autoOverWrite = OptionsForm1.autoOverwrite;
            prefix = OptionsForm1.prefix;
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
                Close();
            }
        }
        #endregion

        #region FilePathSim
        private void MasterSLP()
        {
            //openPathText.Visible = false;
            //savePathText.Visible = false;

            openPathText.Text = openFullPath;
            savePathText.Text = saveFullPath;

            SimplifyLongPath(ref openPathText);
            SimplifyLongPath(ref savePathText);

            openPathText.Location = new System.Drawing.Point(openFileNameBox.Location.X -
                openPathText.Size.Width, openPathText.Location.Y);
            savePathText.Location = new System.Drawing.Point(saveFileNameBox.Location.X -
                savePathText.Size.Width, savePathText.Location.Y);

            openFileSPath = openPathText.Text;
            saveFileSPath = savePathText.Text;

            openPathText.Visible = true;
            savePathText.Visible = true;
        }

        private void SPSimplify()
        {
            //savePathText.Visible = false;

            savePathText.Text = saveFullPath;

            SimplifyLongPath(ref savePathText);

            savePathText.Location = new System.Drawing.Point(saveFileNameBox.Location.X - savePathText.Size.Width, 
                savePathText.Location.Y);

            saveFileSPath = savePathText.Text;

            savePathText.Visible = true;
        }

        private void SimplifyLongPath(ref Label textLabel, int startIndex = 0,
           bool isFirstIndex = false, bool isTrimed = false)
        {
            char[] temp = textLabel.Text.ToCharArray();
            textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, 
                System.Drawing.GraphicsUnit.Point, 134);
            while (textLabel.Size.Width <= UtilityParameters.MAX_PATH_WIDTH * UtilityParameters.MAX_PATH_WIDTH_RATIO)
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
                    textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", textLabel.Font.Size - 0.005F,
                        System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                }
            }

            int midPathLeng;
            int firstRIndex, lastRIndex;
            string pathText;

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
                pathText = pathText.Remove(firstRIndex + 1, 0 == startIndex ? 
                    lastRIndex - firstRIndex - 1 : lastRIndex - firstRIndex);
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
                SimplifyLongPath(ref textLabel, isFirstIndex ? firstRIndex - 5 : 
                    firstRIndex + 5, isFirstIndex ? false : true);
            }

            return;
        }
        #endregion

        private void ResetDefault()
        {
            string tempPath;
            Program.currentPath = @"C\USERS\Desktop";// Directory.GetCurrentDirectory();
            tempPath = Program.currentPath;
            openFullPath = tempPath;
            saveFullPath = tempPath;
            openFileName = "";
            saveFileName = "";
            openFileExt = ".rtl";
            manufactory = manufactoryList.RENISHAW;
            MessageBox.Show("文件名或路径名非法！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ReadFileAndGetData()
        {            
            string fileString = "";
            try
            {
                fileString = File.ReadAllText(openFullPath + '\\' + openFileName + openFileExt,
                    Encoding.Default);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件错误：" + openFileName + openFileExt + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetInfoText(infoText.FILE_OPEN_ERROR);
                return;
            }

            try
            {
                calcData = ManuManager.GetDataByExtWithDot(openFileExt, fileString, UNIT.mm);
                posData = ManuManager.GetPosMMByExtWithDot(openFileExt, fileString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件格式错误：" + openFileName + openFileExt + "\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetInfoText(infoText.DATA_FORMAT_ERROR);
                return;
            }

            Save2File();
            openFileAutoCompleteList.Add(openFileName);
        }       

        private void Save2File()
        {
            int n = calcData.Length;
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

            string tempSavePath;
            suffix = suffixTextBox.Text;

            if (string.Empty == saveFileNameBox.Text)
            {
                SelectSavePath();
                if (!saveDiagResult)
                {
                    return;
                }
                if (1 == autoAppRule)
                {
                    suffixTextBox.Text = saveFileName;
                    ChangeSuffixBoxTextToValid();
                }
            }

            tempSavePath = saveFullPath + '\\' + saveFileName + ".txt";

            while (File.Exists(tempSavePath) && (!autoOverWrite) && (usrInputSaveFileName))
            {
                DialogResult result = MessageBox.Show(saveFileName + ".txt文件已存在，是否覆盖？", "提示", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                if (DialogResult.Yes == result)
                {
                    break;
                }
                else if (DialogResult.No == result)
                {
                    SelectSavePath();
                    if (!saveDiagResult)
                    {
                        return;
                    }
                    if (1 == autoAppRule)
                    {
                        suffixTextBox.Text = saveFileName;
                        ChangeSuffixBoxTextToValid();
                    }
                    tempSavePath = saveFullPath + '\\' + saveFileName + ".txt";
                }
                else
                {
                    return;
                }
            }
            usrInputSaveFileName = true;
            string[] writeString = FormatorManager.FormatData(outDataFormat, calcData, posData, prefix, suffix, colNum);

            try
            {
                File.WriteAllLines(tempSavePath, writeString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存文件错误：" + saveFileName + ".txt\n" + ex.Message, "保存错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetInfoText(infoText.FILE_SAVE_ERROR);
                return;
            }

            SetInfoText(infoText.FILE_SAVE_COMPLETE);
            saved = true;
            savedFilePath = tempSavePath;

            if (autoOpen)
            {
                try
                {
                    System.Diagnostics.Process.Start(tempSavePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件错误：" + saveFileName + ".txt\n" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return;
        }

        private void SetInfoText(infoText info)
        {
            infoTextLabel.Visible = false;
            infoTextLabel.ForeColor = System.Drawing.Color.Red;
            switch (info)
            {
                case infoText.FILE_FORMAT_ERROR:
                    MessageBox.Show("文件格式错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    infoTextLabel.Text = "文件格式有错误！";
                    break;
                case infoText.FILE_CONTENT_ERROR:
                    MessageBox.Show("文件内容错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    infoTextLabel.Text = "文件内容有错误！";
                    break;
                case infoText.DATA_OVERSIZE_ERROR:
                    MessageBox.Show("文件数据太多！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    infoTextLabel.Text = "文件数据太多！";
                    break;
                case infoText.DATA_FORMAT_ERROR:
                    MessageBox.Show("文件数据错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    infoTextLabel.Text = "数据不全，无法生成！";
                    break;
                case infoText.FILE_SAVE_ERROR:
                    infoTextLabel.Text = "无法保存txt文件";
                    break;
                case infoText.FILE_OPEN_ERROR:
                    infoTextLabel.Text = "无法打开干涉仪文件";
                    break;
                case infoText.FILE_SAVE_COMPLETE:
                    System.Media.SystemSounds.Asterisk.Play();
                    infoTextLabel.Text = "生成完毕！";
                    infoTextLabel.ForeColor = System.Drawing.Color.Green;
                    break;
                default:
                    infoTextLabel.Text = "";
                    break;
            }
            infoTextLabel.Location = new System.Drawing.Point(fileGenerateButton.Location.X - infoTextLabel.Width,
                infoTextLabel.Location.Y);
            infoTextLabel.Visible = true;
            return;
        }

        private void FileStreamHandler()
        {
            if (autoSaveFileName)
            {
                saveFileName = openFileName;
                saveFullPath = openFullPath;
            }

            Program.currentPath = openFullPath;
            manufactory = (manufactoryList)Array.FindIndex(UtilityParameters.manuExtList,
                s => s.Equals(openFileExt));

            openFileNameBox.Text = openFileName;
            extDropList.SelectedIndex = (int)manufactory;

            if (autoSaveFileName)
            {
                saveFileNameBox.Text = saveFileName;
            }

            MasterSLP();

            if (quickGen && fileGenerateButton.Enabled)
            {
                ReadFileAndGetData();
            }
        }

        private bool CheckFileNameValid(Control control)
        {
            if (control.Text.LastIndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                fileGenEnByte &= 0xFE;
                control.BackColor = System.Drawing.Color.Red;
                BalloonTip ballon = new BalloonTip("文件名不能包含有\n" + UtilityParameters.invalidFileName, control);
                fileGenerateButton.Enabled = (0xFF == fileGenEnByte);
                return false;
            }
            else
            {
                fileGenEnByte |= 0x01;
                control.BackColor = System.Drawing.SystemColors.Window;
                fileGenerateButton.Enabled = (0xFF == fileGenEnByte);
                return true;
            }
        }

        private void CheckSuffixValid(Control control)
        {
            string tempVarName = prefix + control.Text;
            if (UtilityFunctions.CheckVariableName(control, tempVarName, true, true))
            {
                if (autoApp)
                {
                    suffixTextBox.BackColor = System.Drawing.SystemColors.Control;
                }
                fileGenEnByte |= 0x02;
                suffix = control.Text;
            }
            else
            {
                fileGenEnByte &= 0xFD;
            }
            fileGenerateButton.Enabled = (0xFF == fileGenEnByte);
        }

        private void ChangeSuffixBoxTextToValid()
        {
            int rule = 0;

            if (autoApp)
            {
                suffixTextBox.BackColor = System.Drawing.SystemColors.Control;
            }

            UtilityFunctions.ChangeVarNameToValid(suffixTextBox, rule, prefix, true);

            suffix = suffixTextBox.Text;
        }

        private bool CheckFileNameEmpty()
        {
            if ((string.Empty != openFileNameBox.Text) && (string.Empty != saveFileNameBox.Text))
            {
                return false;
            }
            else
            {
                if (string.Empty == openFileNameBox.Text)
                {
                    bool tempGen = quickGen;
                    quickGen = true;
                    OpenFile();
                    quickGen = tempGen;
                    /*openFileNameBox.BackColor = System.Drawing.Color.Yellow;
                    BalloonTip ballon = new BalloonTip("请输入文件名", openFileNameBox);*/
                }
                else if (string.Empty == saveFileNameBox.Text)
                {
                    ReadFileAndGetData();
                    /*saveFileNameBox.BackColor = System.Drawing.Color.Yellow;
                    BalloonTip ballon = new BalloonTip("请输入文件名", saveFileNameBox);*/
                }
                return true;
            }
        }

        private void MergeFormRun()
        {
            TopMost = false;

            if (!Program.mergeThreadStart)
            {
                onTopInt++;
                mergeForm.outDataColNum = OutDataColNum.Value;
                mergeForm.outDataFormat = outDataFormat;
                mergeForm.SetDefault(saveFullPath, saveFileName);
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

        void ChangeOutDataFormat(DataFormator odf)
        {
            foreach (MenuItem m in menuOutDataFormat.MenuItems)
            {
                string s1 = odf.ToString();
                string s2 = m.Text.Substring(0, m.Text.IndexOf('('));
                if (string.Compare(s1, s2) == 0)
                {
                    m.Checked = true;
                }
                else
                {
                    m.Checked = false;
                }
            }
            outDataFormat = odf;
            if (odf == DataFormator.AeroTech)
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
            TopMost = false;

            if (!Program.scriptThreadStart)
            {
                onTopInt++;
                scriptForm = new ScriptGenWindow();
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
            onTopInt--;
            if (0 == onTopInt)
            {
                Invoke((MethodInvoker)delegate () { TopMost = true; });
            }
        }

        [STAThread]
        private void MergeDataThread()
        {
            Application.Run(mergeForm);
            Program.mergeThreadStart = false;
            onTopInt--;
            if (0 == onTopInt)
            {
                Invoke((MethodInvoker)delegate () { TopMost = true; });
            }
            mergeForm = new MergeWindow();
        }
    }

    #region Parameters
    public partial class MainUI
    {
        private bool openFileReturn = false;
        private bool saveFileReturn = false;
        private bool usrInputOpenFileName = false;
        private bool usrInputSaveFileName = false;
        private string openFileName, saveFileName;
        private string openFileExt = ".rtl";
        private string openFileSPath, saveFileSPath;
        private Stream openStream;
        private FileStream openFileStream;
        private string openFullPath, saveFullPath;
        private int onTopInt = 0;

        private bool quickGen = true;
        private bool autoApp = true;
        private int autoAppRule = 0;
        private bool autoOpen = true;
        private bool autoOverWrite = true;
        private bool autoSaveFileName = true;
        private bool saved = false;
        private string savedFilePath;
        private byte fileGenEnByte = 0xFF;
        private string suffix;
        private string prefix = UtilityParameters.defaultPrefix;

        private double[] calcData = new double[200];
        private double[] posData = new double[200];
        private bool saveDiagResult = false;

        private MergeWindow mergeForm = new MergeWindow();
        private ScriptGenWindow scriptForm;

        private AutoCompleteStringCollection openFileAutoCompleteList = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection saveFileAutoCompleteList = new AutoCompleteStringCollection();

        delegate void voidFunction();
        List<voidFunction> functionList = new List<voidFunction>();
        manufactoryList manufactory = manufactoryList.RENISHAW;
        DataFormator outDataFormat = DataFormator.ACS;

    }
    #endregion
}