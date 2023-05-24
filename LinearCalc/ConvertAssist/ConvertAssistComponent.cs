using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LinearCalc
{
    public partial class ConvertAssist : Form
    {
        bool OpenFile(OpenFileDialog dialog, ref string _path, ref string fileString)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _path = dialog.FileName;
                return OpenFile(_path, ref fileString);
            }
            return false;
        }

        bool OpenFile(string _path, ref string fileString)
        {
            try
            {
                fileString = File.ReadAllText(_path);
            }
            catch (Exception e)
            {
                MessageBox.Show($"无法读取文件{_path}\r\n{e.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        bool OpenSourceFileAndGetData(bool usingDialog = true, bool checkInt = true)
        {
            string s = "";
            bool result = usingDialog ? OpenFile(openSourceDialog, ref sourcePath, ref s) :
                OpenFile(sourcePath, ref s);
            SourcePath = sourcePath;
            if (result)
            {
                return GetSourceData(s, checkInt);
            }
            return false;
        }

        bool GetSourceData(string fileString, bool checkInt = true)
        {
            string ext = Path.GetExtension(sourcePath);
            try
            {
                sourcePos = ManuManager.GetPosMMByExtWithDot(ext, fileString);
                if (checkInt)
                {
                    foreach (double d in sourcePos)
                    {
                        if (!IsInt(d))
                        {
                            sourcePos = new double[sourcePos.Length];
                            SourceStart = 0;
                            SourceEnd = 0;
                            throw new Exception($"存在不是整数的位置：{d}");
                        }
                    }                    
                }
                SourceStart = (int)sourcePos[0];
                SourceEnd = (int)sourcePos[sourcePos.Length - 1];
                SourceSign = SourceStart <= sourceEnd ? 1 : -1;
                rawData = ManuManager.GetDataByExtWithDot(ext, fileString, UNIT.mm);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"干涉仪文件格式错误！\r\n{e.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        bool OpenTargetFileAndGetData(bool usingDialog = true)
        {
            string s = "";
            bool result = usingDialog ? OpenFile(openTargetDialog, ref targetPath, ref s) :
                OpenFile(targetPath, ref s);
            TargetPath = targetPath;
            if (result)
            {
                return GetTargetData(s);
            }
            return false;
        }

        bool GetTargetData(string fileString)
        {
            try
            {
                rawData = FormatorManager.ReadFormatedData(DataFormator.ACS, fileString);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"数据文件格式错误！\r\n{e.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void CalData()
        {
            if (!OpenSourceFileAndGetData(false))
            {
                return;
            }
            if (targetChecked)
            {
                if (!OpenTargetFileAndGetData(false))
                {
                    return;
                }
            }
            try
            {
                CalOffset = -1 * CalUtils.CalInterpolPos(sourcePos, rawData, targetReference);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CalWeight = SourceDirection * TargetDirection * TargetSign * SourceSign;
            Flip = (CalWeight * SourceSign) < 0 ? true : false;
            TargetStart = (int)(CalWeight) * (SourceStart - TargetReference);
            TargetEnd = (int)(CalWeight) * (SourceEnd - TargetReference);
            if (Flip)
            {
                int temp = TargetStart;
                TargetStart = TargetEnd;
                TargetEnd = temp;
            }
        }

        bool IsInt(string s)
        {
            if (double.TryParse(targetReferenceTB.Text, out double d))
            {
                return IsInt(d);
            }
            return false;
        }

        bool IsInt(double d)
        {
            int i = (int)d;
            if (d > i)
            {
                return false;
            }
            return true;
        }
    }

    public partial class ConvertAssist : Form
    {
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public string SourcePath
        {
            get { return sourcePath; }
            set
            {
                sourcePath = value;
                NotifyPropertyChanged("SourcePath");
            }
        }
        public string TargetPath
        {
            get { return targetPath; }
            set
            {
                targetPath = value;
                NotifyPropertyChanged("TargetPath");
            }
        }
        public int SourceDirection
        {
            get { return sourceDirection; }
            set
            {
                sourceDirection = value;
                NotifyPropertyChanged("SourceDirection");
            }
        }
        public int SourceSign
        {
            get { return sourceSign; }
            set
            {
                sourceSign = value;
                NotifyPropertyChanged("SourceSign");
            }
        }
        public int TargetDirection 
        {
            get { return targetDirection; }
            set
            {
                targetDirection = value;
                NotifyPropertyChanged("TargetDirection");
            }
        }
        public int TargetSign
        {
            get { return targetSign; }
            set
            {
                targetSign = value;
                NotifyPropertyChanged("TargetSign");
            }
        }
        public int SourceStart
        {
            get { return sourceStart; }
            set
            {
                sourceStart = value;
                NotifyPropertyChanged("SourceStart");
            }
        }
        public int SourceEnd
        {
            get { return sourceEnd; }
            set
            {
                sourceEnd = value;
                NotifyPropertyChanged("SourceEnd");
            }
        }
        public int TargetStart
        {
            get { return targetStart; }
            set
            {
                targetStart = value;
                NotifyPropertyChanged("TargetStart");
            }
        }
        public int TargetEnd
        {
            get { return targetEnd; }
            set
            {
                targetEnd = value;
                NotifyPropertyChanged("TargetEnd");
            }
        }
        public int TargetReference
        {
            get { return targetReference; }
            set
            {
                targetReference = value;
                NotifyPropertyChanged("TargetReference");
            }
        }
        public double CalOffset
        {
            get { return calOffset; }
            set
            {
                calOffset = value;
                NotifyPropertyChanged("CalOffset");
            }
        }
        public double CalWeight
        {
            get { return calWeight; }
            set
            {
                calWeight = value;
                NotifyPropertyChanged("CalWeight");
            }
        }
        public bool TargetChecked
        {
            get { return targetChecked; }
            set
            {
                targetChecked = value;
                NotifyPropertyChanged("TargetChecked");
            }
        }
        public bool Flip
        {
            get { return flip; }
            set
            {
                flip = value;
                NotifyPropertyChanged("Flip");
            }
        }

        string sourcePath;
        string targetPath;
        int sourceDirection=1;
        int sourceSign;
        int targetDirection = 1;
        int targetSign = 1;
        int sourceStart, sourceEnd;
        int targetStart, targetEnd;
        int targetReference;
        double calOffset, calWeight;
        double[] sourcePos;
        double[] rawData;
        bool targetChecked;
        bool flip;
        Form2 parentForm;
    }
}
