using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleCompra
    {
        private int idDetalleCompra;
        private Producto oProducto;
        private decimal precioCompra;
        private int cantidad;
        private decimal total;
        private string formaDePago;

        public int IdDetalleCompra { get => idDetalleCompra; set => idDetalleCompra = value; }
        public Producto OProducto { get => oProducto; set => oProducto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public decimal Total { get => total; set => total = value; }
        public string FormaDePago { get => formaDePago; set => formaDePago = value; }
    }
}
