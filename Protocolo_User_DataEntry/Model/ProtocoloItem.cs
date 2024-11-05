﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocolo_User_DataEntry.Model
{
    public class ProtocoloItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }
        public string Medida { get; set; }
        public string Simbolo { get; set; }
        public int Orden { get; set; }
        public double EspecificacionMin { get; set; }
        public double Especificacion { get; set; }
        public double EspecificacionMax { get; set; }
        public bool EsCertificado { get; set; }
        public bool EsConstante { get; set; }
        public string EsCertificadoSiNo { get; set; }
        public int IdProtocolo { get; set; }
        public int IdProtocoloItem { get; set; }
        public string EspecificacionDato { get; set; }
        public bool Seleccionar { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}