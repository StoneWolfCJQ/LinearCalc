using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace LinearCalc
{
    public class API : RENISHAW
    {
        string posMatchReg = @"(?<=Targets\s\:)(\d|\D)+(?=Flags\:)";
        string dataMatchReg = @"(?<=Position   	Bidirectional Avg Error)(\d|\D)+(?=ENVIRONMENT\:\:)";

        public new string fileExtWithDot = ".pos";

        public new double[] GetPos(string fileString)
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

        public new double[] GetResult(string fileString)
        {
            Match matchStr = Regex.Match(fileString, dataMatchReg);
            if (matchStr.Success)
            {
                double[] data = matchStr.Value.Split(emptyChr, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => -1.0 * double.Parse(s)).ToArray();
                return data;
            }

            throw new Exception("数据格式错误");
        }

    }
}
