using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum FormaDePago
    {
        Efectivo,
        MercadoPago,
        Otro
    }
    public class DetalleVenta
    {
        private int idDetalleVenta;
        private Producto oProducto;
        private decimal precioVenta;
        private int cantidad;
        private decimal total;
        private string formaDePago;

        public int IdDetalleVenta { get => idDetalleVenta; set => idDetalleVenta = value; }
        public Producto OProducto { get => oProducto; set => oProducto = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Total { get => total; set => total = value; }
        public string FormaDePago { get => formaDePago; set => formaDePago = value; }
    }
}
