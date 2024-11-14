using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    internal class OrdenCodigo
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public int Codigo { get; set; }
        public string O_P { get; set; }
        public override string ToString()
        {
            return O_P;
        }
    }
}
