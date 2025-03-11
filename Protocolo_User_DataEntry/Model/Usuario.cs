using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    internal class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Area { get; set; }
        public int Legajo { get; set; }
        public override string ToString()
        {
            return Legajo+" "+Apellido+" "+Nombre;
        }
    }
}
