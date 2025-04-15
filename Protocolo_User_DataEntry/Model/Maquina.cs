using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Protocolo_User_DataEntry.Model
{
    internal class Maquina
    {
        public string Sector { get; set; }
        public string Nombre { get; set; }
        public CheckState Seleccionado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

    }

}
