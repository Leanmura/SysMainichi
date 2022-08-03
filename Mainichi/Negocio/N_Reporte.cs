using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace CapaNegocio
{
    public class N_Reporte
    {
        BD_Reporte oReporte = new BD_Reporte();
        
        public decimal totalPorCategoria(string categoria, DateTime fecha)
        {
            return oReporte.totalPorCategoria(categoria, fecha);
        }

    }
}
