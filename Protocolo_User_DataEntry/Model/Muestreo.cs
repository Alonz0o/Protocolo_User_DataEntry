using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    internal class Muestreo
    {
        public int Id { get; set; }
        public int Requeridas { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }
        public int PedirCada { get; set; }
        public int Realizadas { get; set; }


    }
}
