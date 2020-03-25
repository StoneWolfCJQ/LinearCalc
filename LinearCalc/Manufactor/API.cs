using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace LinearCalc
{
    public class API : ManuTemplate
    {
        string commonMatchReg = @"(?<=Position   	Bidirectional Avg Error)(\d|\D)+(?=Position   	Forward Directional Avg Error)";

        public override string FileExtWithDot { get { return ".pos"; } }
        protected override UNIT FileDataUnit { get { return UNIT.mm; } }

        public override double[] GetPosMM(string fileString)
        {
            return GetRawData(fileString, 0);
        }

        public override double[] GetResult(string fileString, UNIT unit)
        {
            int targetUnit = (int)unit;
            int sourceUnit = (int)FileDataUnit;
            double ratio = (targetUnit * 1.0 / sourceUnit);
            return GetRawData(fileString, 1).Select(s=> -1.0 * ratio * s).ToArray ();
        }

        double[] GetRawData(string fileString, int index)
        {
            Match matchStr = Regex.Match(fileString, commonMatchReg);
            if (matchStr.Success)
            {
                double[] data = matchStr.Value.Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => double.Parse(s.Split(emptyChr, StringSplitOptions.RemoveEmptyEntries)[index])).ToArray();
                return data;
            }

            throw new Exception("数据格式错误");
        }

    }
}
