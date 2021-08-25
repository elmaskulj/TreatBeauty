using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreatBeauty.WinUI.SalonForms;
using TreatBeauty.WinUI.EmployeeForms;
using TreatBeauty.WinUI.ServiceForms;
using TreatBeauty.WinUI.TermForms;
using TreatBeauty.WinUI.NewsForms;
using TreatBeauty.WinUI.Report;

namespace TreatBeauty.WinUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmServiceReport());
        }
    }
}
