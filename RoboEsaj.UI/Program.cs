using RoboEsaj.Domain.Helpers;
using RoboEsaj.UI.Forms;
using System;
using System.Windows.Forms;

namespace UI_RoboEsaj.Forms
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmEsaj());
        }
    }
}
