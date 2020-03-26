using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    static class CalUtils
    {
        public static double CalInterpolPos(double[] posArray, double[] calData, double pos)
        {
            if (posArray.Length != calData.Length)
            {
                throw new Exception("数据维度不同");
            }

            if (posArray.Length < 2)
            {
                throw new Exception("数据太少");
            }

            double x1, x2, x;
            double a;
            double y1, y2, y;
            for (int i =0; i< posArray.Length - 1; i++)
            {
                x1 = posArray[i];
                x2 = posArray[i + 1];
                x = pos;
                if ((x1 <= x && x <= x2) || (x2 <= x && x <= x1))
                {
                    y1 = calData[i];
                    y2 = calData[i + 1];
                    a = (x - x1) / (x2 - x1);
                    y = (y2 - y1) * a + y1;
                    return y;
                }
            }
            throw new Exception("位置超出给定上下限");
        }
    }
}
