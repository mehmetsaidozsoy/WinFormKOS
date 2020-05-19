using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormKOS.Model;

namespace WinFormKOS
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

            if (IDataBase.DataToDataTable("select * from kullanicilar where aktif = 1").Rows.Count > 0)
            {
                Application.Run(new FormLogin());
            }
            else
            {
                Application.Run(new FormKurulum());
            }
        }
    }
}
