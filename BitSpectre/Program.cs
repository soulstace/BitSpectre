using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BitSpectre
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string name = "BitSpectre";
            using (Mutex m = new Mutex(false, name))
            {
                if (!m.WaitOne(0, false))
                {
                    MessageBox.Show(name + " is already running. Check your Windows taskbar.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmSpectre());
                }
            }
        }
    }
}
