using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    class AreoTech : FormatorTemplate
    {
        public override DataFormator formator { get { return DataFormator.AeroTech; } }

        public override string[] FormatData(double[] data, double[] pos, params object[] exParams)
        {
            int colNum = (int)exParams[2];
            int lineTotal= (int)Math.Ceiling(data.Length * 1.0 / colNum);
            string[] s = new string[lineTotal];

            for (int i = 0; i < data.Length; i++)
            {
                int j = i / colNum;
                if (i % colNum == 0)
                {
                    s[j] = "";
                }

                s[j] += string.Format("{0:0.#####}\t", data[i] * 1000);
            }

            return s;
        }
    }
}
