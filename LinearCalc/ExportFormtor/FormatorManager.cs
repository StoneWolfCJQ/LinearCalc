using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    public enum DataFormator { ACS, AeroTech };

    static class FormatorManager
    {
        static List<FormatorTemplate> formators = new List<FormatorTemplate>()
        {
            new ACS(),
            new AreoTech(),
        };

        public static string[] FormatData(DataFormator formator, double[] data, params object[] exParams)
        {
            string[] s = GetFormator(formator).FormatData(data, exParams);
            return s;
        }

        public static double[] ReadFormatedData(DataFormator formator, string fileString)
        {
            double[] d = GetFormator(formator).ReadFormatedData(formator, fileString);
            return d;
        }

        static FormatorTemplate GetFormator(DataFormator formator)
        {
            return formators.Find(s => s.formator == formator);
        }
    }
}
