using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    public enum DataFormator { ACS, AeroTech, Vulcan };

    static class FormatorManager
    {
        static List<FormatorTemplate> formators = new List<FormatorTemplate>()
        {
            new ACS(),
            new AreoTech(),
            new Vulcan(),
        };

        public static string[] FormatData(DataFormator formator, double[] data, double[] pos, params object[] exParams)
        {
            string[] s = GetFormator(formator).FormatData(data, pos, exParams);
            return s;
        }

        public static (double[] data, double[] pos) ReadFormatedData(DataFormator formator, string fileString)
        {
            (double[] d, double[] p) = GetFormator(formator).ReadFormatedData(formator, fileString);
            return (d, p);
        }

        static FormatorTemplate GetFormator(DataFormator formator)
        {
            return formators.Find(s => s.formator == formator);
        }
    }
}
