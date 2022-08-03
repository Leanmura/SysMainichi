using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Negocio
    {
        private int idNegocio;
        private string nombre;
        private string telefono;
        private string direccion;
        private byte[] imagen;

        public int IdNegocio { get => idNegocio; set => idNegocio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
