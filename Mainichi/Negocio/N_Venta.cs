using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_Venta
    {
        private BD_Venta objcd_venta = new BD_Venta();

        /*public int ObtenerCorrelativo()
        {
            return objcd_venta.ObtenerCorrelativo();
        }*/
        
        public bool Registrar(Venta obj, DataTable DetalleVenta, DataTable DetalleCompra, out string Mensaje)
        {
            return objcd_venta.Registrar(obj, DetalleVenta, DetalleCompra, out Mensaje);

        }

        public bool Editar(Venta obj, DataTable DetalleVenta, DataTable DetalleCompra, out string mensaje)
        {
            return objcd_venta.Editar(obj, DetalleVenta, DetalleCompra, out mensaje);
        }

        public Venta TraerVenta(DateTime fecha)
        {
            Venta oVenta = objcd_venta.TraerVenta(fecha);
            if(oVenta.IdVenta != 0)
            {
                oVenta.ODetalleCompra = objcd_venta.TraerDetalleCompra(oVenta.IdVenta);
                oVenta.ODetalleVenta = objcd_venta.TraerDetalleVenta(oVenta.IdVenta);
            }

            return oVenta;
        }
    }
}

