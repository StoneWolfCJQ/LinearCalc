using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearCalc
{
    public partial class ConvertAssist : Form
    {
        public ConvertAssist()
        {
            InitializeComponent();
            InitializeCustom();
        }

        void InitializeCustom()
        {
            InitializeCB();
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

        private void button1_Click(object sender, EventArgs e)
        {
            TargetDirection = 1;
            //sourceDirectionCB.SelectedValue = -1;
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
