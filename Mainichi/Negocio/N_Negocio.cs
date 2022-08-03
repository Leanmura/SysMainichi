using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Negocio
    {

        private BD_Negocio objBDNegocio = new BD_Negocio();

        public Negocio ObtenerDatos()
        {
            return objBDNegocio.ObtenerDatos();
        }

        public bool GuardarDatos(Negocio obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool retorno = false;
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del negocio.\n";
            }
            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario el telefono del negocio.\n";
            }
            if (obj.Direccion == "")
            {
                Mensaje += "Es necesaria la direccion del negocio.\n";
            }
            if (obj.Imagen.Length < 1)
            {
                Mensaje += "Es necesaria la foto del negocio.\n";
            }

            if (Mensaje == "")
            {
                retorno = objBDNegocio.GuardarDatos(obj, out Mensaje); // nos devuelve el id de la Negocio registrada
            }


            return retorno;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objBDNegocio.ObtenerLogo(out obtenido);
        }

    }
}
