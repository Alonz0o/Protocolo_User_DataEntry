using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocolo_User_DataEntry
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static List<string> argumentos = new List<string>();

        [STAThread]
        static void Main(string[] args)
        {
            argumentos.AddRange(args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormVistaAuditor());
        }
    }
}
