using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    public class Codigo
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public int IdProtocolo { get; set; }
        public string ProtocoloNombre { get; set; }
        public int Disposicion { get; set; }

    }
}

