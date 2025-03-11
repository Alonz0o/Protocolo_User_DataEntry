using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    internal class Paquete
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Legajo { get; set; }
        public int Cantidad { get; set; }
        public override string ToString()
        {
            return Numero+"";
        }
    }
}
