using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Tawfiq_Bakery
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static  void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Home());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ عام",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
