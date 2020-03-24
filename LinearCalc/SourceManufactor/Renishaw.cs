using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace LinearCalc
{
    public class RENISHAW
    {
        string posMatchReg = @"(?<=Targets :)(\d|\D)+(?=Flags:)";
        string dataMatchReg = @"(?<=Run Target Data:)(\d|\D)+(?=ENVIRONMENT::)";

        protected char[] emptyChr = "\r\n\t\b ".ToCharArray();
        protected int measureTimes = 4;

        public string fileExtWithDot = ".rtl";

        public double[] GetPos(string fileString)
        {
            Match matchStr = Regex.Match(fileString, posMatchReg);
            if (matchStr.Success)
            {
                double[] data= matchStr.Value.Split(emptyChr, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => double.Parse(s)).ToArray();
                return data;
            }

            throw new Exception("数据格式错误");
        }

        public double[] GetResult(string fileString)
        {
            double[] rawData = GetRawData(fileString);
            int l = rawData.Length / measureTimes;
            double[] data = new double[l];
            for (int i=0;i< l; i++)
            {
                data[i] = 0;
                for (int j = 0; j < measureTimes; j++)
                {
                    data[i] += -0.001 * data[j * l + i] / measureTimes;
                }
            }

            return data;
        }

        double[] GetRawData(string fileString)
        {
            Match matchStr = Regex.Match(fileString, dataMatchReg);
            if (matchStr.Success)
            {
                double[] data = matchStr.Value.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => double.Parse(s.Split(emptyChr, StringSplitOptions.RemoveEmptyEntries)[2])).ToArray();
                if (Math.IEEERemainder(data.Length, measureTimes) == 0)
                {
                    return data;
                }
            }

            throw new Exception("数据格式错误");

        }

    }
}
