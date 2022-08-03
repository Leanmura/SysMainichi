using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Producto
    {
        private BD_Producto objBDProducto = new BD_Producto();

        public Producto TraerProducto(int id)
        {
            return objBDProducto.TraerProducto(id);
        }

        public List<Producto> Listar()
        {
            return objBDProducto.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int retorno = 0;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la descripcion del producto.\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesaria el nombre del producto.\n";
            }

            if (Mensaje == string.Empty)
            {
                retorno = objBDProducto.Registrar(obj, out Mensaje); // nos devuelve el id de la Producto registrada
            }

            return retorno;
        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool retorno = false;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la descripcion del producto.\n";
            }
            if (obj.Nombre == "")
            {
                Mensaje += "Es necesaria el nombre del producto.\n";
            }

            if (Mensaje == string.Empty)
            { 
                retorno = objBDProducto.Editar(obj, out Mensaje); // nos devuelve el id de la Producto registrada
            }

            return retorno;
        }

        public bool Eliminar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool retorno = false;
            if (obj.IdProducto <= 0)
            {
                Mensaje += "Es necesario el ID del producto.\n";
            }
            else
            {
                retorno = objBDProducto.Eliminar(obj, out Mensaje); // nos devuelve el id de la Producto registrada
            }
            return retorno;
        }

    }
}
