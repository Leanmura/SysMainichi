using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        #region Atributos
        private int idProducto;
        private string nombre;
        private string descripcion;
        private decimal precioVenta;
        private decimal precioCompra;
        private Categoria oCategoria;
        private byte[] imagen;


        #endregion

        #region Propiedades

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public decimal PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public Categoria OCategoria { get => oCategoria; set =>oCategoria = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }

        #endregion

        #region Constructor


        #endregion
    }
}
