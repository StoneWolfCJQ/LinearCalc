using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    class Vulcan : FormatorTemplate
    {
        public override DataFormator formator { get { return DataFormator.Vulcan; } }

        public override string[] FormatData(double[] data, double[] pos, params object[] exParams)
        {
            string[] s = new string[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                s[i] = string.Format("{0:0},{1:0.###}", pos[i], -data[i] * 1000);
            }

            return s;
        }

        public override (double[] data, double[] pos) ReadFormatedData(DataFormator formator, string fileString)
        {
            var dp = fileString.Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new { data = double.Parse(s.Substring(s.IndexOf(',') + 1)), pos = double.Parse(s.Substring(0, s.IndexOf(','))) });
            double[] data = dp.Select(d=>d.data).ToArray();
            double[] p = dp.Select(d=>d.pos).ToArray();
            return (data, p);
        }
    }
}
