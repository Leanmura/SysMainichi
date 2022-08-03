using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compra
    {
        private int idCompra;
        private decimal montoTotal;
        private string formaPago;
        private List<DetalleCompra> oDetalleCompra;
        private DateTime fecha;

        public int IdCompra { get => idCompra; set => idCompra = value; }
        public decimal MontoTotal { get => montoTotal; set => montoTotal = value; }
        public string FormaPago { get => formaPago; set => formaPago = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public List<DetalleCompra> ODetalleCompra { get => oDetalleCompra; set => oDetalleCompra = value; }
    }
}
