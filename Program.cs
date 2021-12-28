using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;

namespace ScannerService
{
    internal class Program
    {
        private static ServiceHost Host;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Host = new ServiceHost(typeof(ScanningService));
            Host.Open();
            Application.Run(new ScanningStart());
            Host.Close();
        }
    }
}
