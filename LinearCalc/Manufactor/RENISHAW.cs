using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace LinearCalc
{
    public class RENISHAW : ManuTemplate
    {
        string posMatchReg = @"(?<=Targets :)(\d|\D)+(?=Flags:)";
        string dataMatchReg = @"(?<=Run Target Data:)(\d|\D)+?(?=E)";

        public override string FileExtWithDot { get { return ".rtl"; } }
        protected override UNIT FileDataUnit { get { return UNIT.um; } }

        public override double[] GetPosMM(string fileString)
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

        public override double[] GetResult(string fileString, UNIT unit)
        {
            double[] rawData = GetRawDataUM(fileString);
            int l = rawData.Length / measureTimes;
            double[] data = new double[l];
            int targetUnit = (int)unit;
            int sourceUnit = (int)FileDataUnit;
            double ratio = (targetUnit * 1.0 / sourceUnit);
            for (int i=0;i< l; i++)
            {
                data[i] = 0;
                for (int j = 0; j < measureTimes; j++)
                {
                    if (j % 2 == 0)
                    {
                        data[i] += ratio * rawData[j * l + i] / measureTimes;
                    }
                    else
                    {
                        data[i] += ratio * rawData[(j + 1) * l - i - 1] / measureTimes;
                    }
                }
            }

            return data;
        }

        double[] GetRawDataUM(string fileString)
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
