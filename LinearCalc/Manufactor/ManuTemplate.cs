using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCalc
{
    public enum UNIT
    {
        um = 1000,
        mm = 1
    }
    public class ManuTemplate
    {
        public virtual string FileExtWithDot { get; }

        protected virtual UNIT FileDataUnit { get; }
        protected char[] emptyChr = "\r\n\t\b ".ToCharArray();
        protected int measureTimes = 4;

        public virtual double[] GetPosMM(string fileString) { throw new NotImplementedException(); }
        public virtual double[] GetResult(string fileString, UNIT unit) { throw new NotImplementedException(); }
    }
}
