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

        bool OpenSourceFileAndGetData(bool usingDialog = true)
        {
            string s = "";
            bool result = usingDialog ? OpenFile(openSourceDialog, ref sourcePath, ref s) :
                OpenFile(sourcePath, ref s);
            SourcePath = sourcePath;
            if (result)
            {
                return GetSourceData(s);
            }
            return false;
        }

        bool GetSourceData(string fileString)
        {
            string ext = Path.GetExtension(sourcePath);
            try
            {
                sourcePos = ManuManager.GetPosMMByExtWithDot(ext, fileString);
                SourceStart = sourcePos[0];
                SourceEnd = sourcePos[sourcePos.Length - 1];
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
            CalWeight = sourceSign * sourceDirection * targetDirection * targetSign;
            Flip = sourceDirection * targetDirection < 0 ? true : false;
        }
    }

    public partial class ConvertAssist : Form
    {
        private void NotifyPropertyChanged(String info)
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
        public double SourceStart
        {
            get { return sourceStart; }
            set
            {
                sourceStart = value;
            }
        }
        public double SourceEnd
        {
            get { return sourceEnd; }
            set
            {
                sourceEnd = value;
            }
        }
        public double TargetReference
        {
            get { return targetReference; }
            set
            {
                targetReference = value;
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
        double sourceStart, sourceEnd;
        double targetReference;
        double calOffset, calWeight;
        double[] sourcePos;
        double[] rawData;
        bool targetChecked;
        bool flip;
        Form2 parentForm;
    }
}
