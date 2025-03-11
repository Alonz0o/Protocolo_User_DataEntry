using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    internal class Simbolo
    {
        public string Caracter { get; set; }
        public string Significado { get; set; }
        public override string ToString()
        {
            return Caracter+" ("+ Significado+")";
        }
    }
}
