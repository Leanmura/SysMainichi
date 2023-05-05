using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class BD_Reporte
    {
        //		CREATE PROCEDURE SP_TotalPorCategoria(
        //	@Categoria varchar(50) ,
        //	@Fecha dateTime
        //)AS
        //begin

        //	SELECT SUM(dv.Total)[TOTAL] FROM VENTA v
        //	inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
        //	inner join PRODUCTO p on p.IdProducto = dv.IdProducto
        //	inner join CATEGORIA c on c.IdCategoria = p.IdCategoria
        //	WHERE  c.Descripcion = @Categoria and
        //	CONVERT(char(10), v.Fecha, 105) = CONVERT(char(10), @Fecha, 105)
        //end

        public decimal totalPorCategoria(string categoria, DateTime fecha)
        {
            decimal respuesta = 0;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_TotalPorCategoria", oConexion);
                    cmd.Parameters.AddWithValue("Categoria", categoria);
                    cmd.Parameters.AddWithValue("Fecha", fecha);

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader["TOTAL"] != DBNull.Value)
                                respuesta = Convert.ToDecimal(dataReader["TOTAL"]);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                respuesta = -1;
            }

            return respuesta;
        }

        public decimal totalEntradaPorCategoriaFormaDePago(string categoria, string formaDePago, DateTime fecha)
        {
            decimal respuesta = 0;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_TotalEntradaPorCategoriaFormaDePago", oConexion);
                    cmd.Parameters.AddWithValue("Categoria", categoria);
                    cmd.Parameters.AddWithValue("FormaDePago", formaDePago);
                    cmd.Parameters.AddWithValue("Fecha", fecha);

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader["TOTAL"] != DBNull.Value)
                                respuesta = Convert.ToDecimal(dataReader["TOTAL"]);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                respuesta = -1;
            }

            return respuesta;
        }
    }
}
