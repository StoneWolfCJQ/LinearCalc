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
    public partial class DataDisplay : Form
    {
        public DataDisplay(double[][] data)
        {
            InitializeComponent();
            InitializeDGV(data);
        }

        void InitializeDGV(double[][] data)
        {
            //DataTable
            double[][] temp = new double[data[0].Length][];
            for (int i = 0; i < data[0].Length; i++)
            {
                temp[i] = new double[data.Length + 1];
                temp[i][0] = i;
                for (int j = 1; j <= data.Length; j++)
                {
                    temp[i][j] = Math.Round(data[j - 1][i], 5);
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.AddRange((from d in data
                                 select new DataColumn("", typeof(double))).ToArray());
            dt.Columns.Add(new DataColumn("", typeof(double)));
            foreach (double[] d in temp)
            {
                DataRow r = dt.NewRow();
                r.ItemArray = d.Select(t => (object)t).ToArray();
                dt.Rows.Add(r);
            }
            dataDGV.DataSource = dt;
        }
    }
}
