using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        private int idCategoria;
        private string descripcion;

        public int IdCategoria
        {
            get
            {
                return this.idCategoria;
            }
            set
            {
                this.idCategoria = value;
            }
        }
        public string Descripcion 
        { 
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
                }

    }
}
