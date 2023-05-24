using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LinearCalc
{
    static class Program
    {
        static public string currentPath;
        static public string[] startArg;
        static public bool mergeThreadStart = false;
        static public bool scriptThreadStart = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            startArg = args;
            currentPath = Directory.GetCurrentDirectory();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form mergeForm = new Form2();
            Thread mainFormThread = new Thread(MainFormThread);
            
            mainFormThread.SetApartmentState(ApartmentState.STA);
            
            mainFormThread.Start();
            
            mainFormThread.Join();
            
        }

        [STAThread]
        static void MainFormThread()
        {
            Application.Run(new Form1());
        }

       
    }
}
