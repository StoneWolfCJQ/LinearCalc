using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    class FormatorTemplate
    {
        public virtual DataFormator formator { get; }
        protected char[] emptyChr = "\r\n\t\b ".ToCharArray();

        public virtual string[] FormatData(double[] data, params object[] exParams) { throw new NotImplementedException(); }

        public virtual double[] ReadFormatedData(DataFormator formator, string fileString)
        {
            double[] data = fileString.Split("\r\n".ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(s => double.Parse(s.Substring(s.IndexOf('=') + 1))).ToArray();
            return data;
        }
    }
}
