using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    static class ManuManager
    {
        static List<ManuTemplate> manufactors = new List<ManuTemplate>()
        {
            new API(),
            new RENISHAW(),
        };

        public static double[] GetDataByExtWithDot(string extWithDot, string fileString, UNIT unit)
        {
            double[] data = GetManuByExtWithDot(extWithDot).GetResult(fileString, unit);
            return data;
        }

        public static double[] GetPosMMByExtWithDot(string extWithDot, string fileString)
        {
            double[] data = GetManuByExtWithDot(extWithDot).GetPosMM(fileString);
            return data;
        }

        static ManuTemplate GetManuByExtWithDot(string extWithDot)
        {
            return manufactors.Find(s => s.FileExtWithDot == extWithDot);
        }
    }
}
