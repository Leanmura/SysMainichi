using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Datos;
using Entidades;

namespace CapaNegocio
{
    public class N_Categoria
    {
        private BD_Categoria objBDCatgoria = new BD_Categoria();

        public List<Categoria> Listar()
        {
            return objBDCatgoria.Listar();
        }

        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int retorno = 0;
            if(obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la descripcion del la cateogria.\n";
            }
            else
            {
                retorno = objBDCatgoria.Registrar(obj, out Mensaje); // nos devuelve el id de la categoria registrada
            }

            return retorno;
        }

        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool retorno = false;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesaria la descripcion del la cateogria.\n";
            }
            else
            {
                retorno = objBDCatgoria.Editar(obj, out Mensaje); // nos devuelve el id de la categoria registrada
            }

            return retorno;
        }

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool retorno = false;
            if (obj.IdCategoria <=0)
            {
                Mensaje += "Es necesario el ID del la cateogria.\n";
            }
            else
            {
                retorno = objBDCatgoria.Eliminar(obj, out Mensaje); // nos devuelve el id de la categoria registrada
            }
            return retorno;
        }


    }
}
