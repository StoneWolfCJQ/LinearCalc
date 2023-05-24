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

        public virtual string[] FormatData(double[] data, double[] pos, params object[] exParams) { throw new NotImplementedException(); }

        public virtual (double[] data, double[] pos) ReadFormatedData(DataFormator formator, string fileString)
        {
            throw new NotImplementedException();
        }
    }
}
