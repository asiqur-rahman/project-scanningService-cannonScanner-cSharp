using System;
using System.Windows.Forms;

namespace ScannerService
{
    public partial class ScanningStart : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
            base.OnLoad(e);
        }
    }
}
