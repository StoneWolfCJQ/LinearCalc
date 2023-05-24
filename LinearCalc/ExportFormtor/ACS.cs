using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    class ACS : FormatorTemplate
    {
        public override DataFormator formator { get { return DataFormator.ACS; } }

        public override string[] FormatData(double[] data, double[] pos, params object[] exParams)
        {
            List<string> s = new List<string>();
            string prefix = (string)exParams[0];
            string suffix = (string)exParams[1];
            for (int i = 0; i < data.Length; i++) 
            {
                s.Add(prefix + suffix + '(' + i + ")=" + (-data[i]).ToString("F6"));
            }
            return s.ToArray();
        }
    }
}
