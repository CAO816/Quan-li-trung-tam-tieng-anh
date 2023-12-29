using Project_group5.GV;
using Project_group5.HV;
using Project_group5.QTV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormDangNhap());
            //Application.Run(new FrmHV("HV-0001"));
            //Application.Run(new FrmGV("GV-02"));
            //Application.Run(new FrmQTV());
        }
    }
}
