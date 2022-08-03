using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Venta
    {
        private int idVenta;
        private decimal gastos;
        private decimal cambioAntiguo;
        private decimal cambioNuevo;
        private decimal montoTotal;
        private decimal efectivo;
        private decimal mercadoPago;
        private decimal otro;
        private List<DetalleVenta> oDetalleVenta;
        private List<DetalleCompra> oDetalleCompra;
        private DateTime fecha;
        
        public int IdVenta { get => idVenta; set => idVenta = value; }
        public decimal MontoTotal { get => montoTotal; set => montoTotal = value; }
        public decimal Efectivo { get => efectivo; set => efectivo = value; }
        public decimal Gastos { get => gastos; set => gastos = value; }
        public decimal CambioAntiguo { get => cambioAntiguo; set => cambioAntiguo = value; }
        public decimal CambioNuevo { get => cambioNuevo; set => cambioNuevo = value; }
        public List<DetalleVenta> ODetalleVenta { get => oDetalleVenta; set => oDetalleVenta = value; }
        public List<DetalleCompra> ODetalleCompra { get => oDetalleCompra; set => oDetalleCompra = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal MercadoPago { get => mercadoPago; set => mercadoPago = value; }
        public decimal Otro { get => otro; set => otro = value; }
    }
}
