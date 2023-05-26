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
    public partial class ConvertAssist : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Initial
        public ConvertAssist(string path, MergeWindow _parentForm)
        {
            InitializeComponent();
            InitializeData(path);
            InitializeControl();
            parentForm = _parentForm;
            FormClosing += ConvertAssist_FormClosing;
        }

        private void ConvertAssist_FormClosing(object sender, FormClosingEventArgs e)
        {
            targetReferenceTB.Focus();
            targetReferenceTB.Text = "0";
        }

        void InitializeControl()
        {
            InitializeCB();
            InitializePath();
            InitializeTB();
            InitializeOthers();
        }

        void InitializeData(string path)
        {
            //Path
            if (Directory.Exists(path))
            {
                SourcePath = path;
                TargetPath = path;
            }
            else
            {
                SourcePath = Program.currentPath;
                TargetPath = Program.currentPath;
            }

            openSourceDialog.InitialDirectory = SourcePath;
            openTargetDialog.InitialDirectory = TargetPath;
        }

        void InitializeCB()
        {
            List<CBDataSource> sources= new List<CBDataSource>
            {
                new CBDataSource(1,"向右"),
                new CBDataSource(-1,"向左"),
            };
            SetCBSource(sourceDirectionCB, new List<CBDataSource>(sources), "SourceDirection");
            SetCBSource(targetDirectionCB, new List<CBDataSource>(sources), "TargetDirection");

            sources = new List<CBDataSource>
            {
                new CBDataSource(1,"+"),
                new CBDataSource(-1,"-"),
            };
            SetCBSource(sourceSignCB, new List<CBDataSource>(sources), "SourceSign");
            SetCBSource(targetSignCB, new List<CBDataSource>(sources), "TargetSign");
        }

        void SetCBSource(ComboBox CB, List<CBDataSource> sources, string dataMember)
        {
            CB.DataSource = sources;
            CB.DisplayMember = "Name";
            CB.ValueMember = "Sign";
            CB.DataBindings.Add("SelectedValue", this, dataMember, 
                true, DataSourceUpdateMode.OnPropertyChanged);
        }

        void InitializePath()
        {
            sourcePathLabel.DataBindings.Add("Text", this, "SourcePath", 
                true, DataSourceUpdateMode.OnPropertyChanged);
            targetPathLabel.DataBindings.Add("Text", this, "TargetPath",
                true, DataSourceUpdateMode.OnPropertyChanged);
        }

        void InitializeTB()
        {
            sourceStartTB.DataBindings.Add("Text", this, "SourceStart", 
                true, DataSourceUpdateMode.OnPropertyChanged).FormatString = "F2";
            sourceEndTB.DataBindings.Add("Text", this, "SourceEnd",
                true, DataSourceUpdateMode.OnPropertyChanged).FormatString = "F2";
            targetStartTB.DataBindings.Add("Text", this, "TargetStart",
                true, DataSourceUpdateMode.OnPropertyChanged).FormatString = "F2";
            targetEndTB.DataBindings.Add("Text", this, "TargetEnd",
                true, DataSourceUpdateMode.OnPropertyChanged).FormatString = "F2";
            targetReferenceTB.DataBindings.Add("Text", this, "TargetReference",
                true, DataSourceUpdateMode.OnPropertyChanged);
            targetReferenceTB.Validating += TargetReferenceTB_Validating;
            calOffsetTB.DataBindings.Add("Text", this, "CalOffset",
                true, DataSourceUpdateMode.OnPropertyChanged).FormatString= "F6";
            calWeightTB.DataBindings.Add("Text", this, "CalWeight",
                true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void TargetReferenceTB_Validating(object sender,
            System.ComponentModel.CancelEventArgs e)
        {
            if (!IsInt(targetReferenceTB.Text))
            {
                BalloonTip b = new BalloonTip("必须是整数", targetReferenceTB);
                e.Cancel = true;
            }
        }

        void InitializeOthers()
        {
            targetCheckBox.DataBindings.Add("Checked", this, "TargetChecked",
                false, DataSourceUpdateMode.OnPropertyChanged);

            targetSelectButton.DataBindings.Add("Visible", this, "TargetChecked",
                false, DataSourceUpdateMode.OnPropertyChanged);

            targetPathLabel.DataBindings.Add("Visible", this, "TargetChecked",
                false, DataSourceUpdateMode.OnPropertyChanged);

            targetFileOpenButton.DataBindings.Add("Visible", this, "TargetChecked",
                false, DataSourceUpdateMode.OnPropertyChanged);

            targetDataOpenButton.DataBindings.Add("Visible", this, "TargetChecked",
                false, DataSourceUpdateMode.OnPropertyChanged);

            flipCheckBox.DataBindings.Add("Checked", this, "Flip",
                false, DataSourceUpdateMode.OnPropertyChanged);
        }
        #endregion

        #region Event
        private void sourceSelectButton_Click(object sender, EventArgs e)
        {
            OpenSourceFileAndGetData();
        }
        #endregion

        private void targetSelectButton_Click(object sender, EventArgs e)
        {
            OpenTargetFileAndGetData();
        }

        private void CalButton_Click(object sender, EventArgs e)
        {
            CalData();
        }

        private void sourceFileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(sourcePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件错误：" + sourcePath + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void targetFileOpenButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(targetPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件错误：" + targetPath + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sourceDataOpenButton_Click(object sender, EventArgs e)
        {
            if (OpenSourceFileAndGetData(false, false))
            {
                DataDisplay dd = new DataDisplay(new double[][] { sourcePos, rawData });
                dd.Show();
            }
        }

        private void targetDataOpenButton_Click(object sender, EventArgs e)
        {
            if (OpenTargetFileAndGetData(false))
            {
                DataDisplay dd = new DataDisplay(new double[][] { rawData });
                dd.Show();
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            string s = "";
            string p = TargetChecked ? TargetPath : SourcePath;
            if (OpenFile(p, ref s))
            {
                parentForm.ExternelAddItem(new[] { p }, CalWeight, Flip, Math.Round(CalOffset, 6));
            }
        }
    }

    public class CBDataSource
    {
        public int Sign { get; set; }
        public string Name { get; set; }

        public CBDataSource(int sign, string name)
        {
            Sign = sign;
            Name = name;
        }
    }
}
