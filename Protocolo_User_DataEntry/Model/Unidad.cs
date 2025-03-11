using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    internal class Unidad
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
