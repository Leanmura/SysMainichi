using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class BD_Venta
    {

        public bool Registrar(Venta obj, DataTable DetalleVenta, DataTable DetalleCompra, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarVenta", oConexion);

                    cmd.Parameters.AddWithValue("Gastos", obj.Gastos);
                    cmd.Parameters.AddWithValue("CambioAntiguo", obj.CambioAntiguo);
                    cmd.Parameters.AddWithValue("CambioNuevo", obj.CambioNuevo);
                    cmd.Parameters.AddWithValue("Total", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("Efectivo", obj.Efectivo);
                    cmd.Parameters.AddWithValue("TMercadoPago", obj.MercadoPago);
                    cmd.Parameters.AddWithValue("TOtro", obj.Otro);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);

                    cmd.Parameters.AddWithValue("Fecha", obj.Fecha);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // indicamos que son parametros de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta= Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }
            return respuesta;
        }

        public bool Editar(Venta obj, DataTable DetalleVenta, DataTable DetalleCompra, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarVenta", oConexion);
                    //create PROCEDURE SP_EditarVenta(
                    //   @Gastos decimal(10, 2),
                    //   @CambioAntiguo  decimal(10, 2),
                    //   @CambioNuevo    decimal(10, 2),
                    //   @Total  decimal(10, 2),
                    //   @Efectivo   decimal(10, 2),
                    //   @TMercadoPago decimal(10, 2),
                    //   @TOtro decimal(10, 2),
                    //   @DetalleVenta[EDetalle_Venta] READONLY,
                    //   @DetalleCompra[EDetalle_Compra] READONLY,
                    //   @Fecha datetime,
                    //   @Resultado bit output,
                    //   @Mensaje varchar(500) output
                    //) as

                    cmd.Parameters.AddWithValue("Gastos", obj.Gastos);
                    cmd.Parameters.AddWithValue("CambioAntiguo", obj.CambioAntiguo);
                    cmd.Parameters.AddWithValue("CambioNuevo", obj.CambioNuevo);
                    cmd.Parameters.AddWithValue("Total", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("Efectivo", obj.Efectivo);
                    cmd.Parameters.AddWithValue("TMercadoPago", obj.MercadoPago);
                    cmd.Parameters.AddWithValue("TOtro", obj.Otro);
                    cmd.Parameters.AddWithValue("DetalleVenta", DetalleVenta);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
                    cmd.Parameters.AddWithValue("Fecha", obj.Fecha);


                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // indicamos que son parametros de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }
            return respuesta;
        }


        public Venta TraerVenta(DateTime fecha)
        {
            Venta obj = new Venta();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT * FROM VENTA v");
                    query.AppendLine("where CONVERT(char(10), v.Fecha,105) = @fecha");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@fecha", fecha.ToString("dd-MM-yyyy"));
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Venta();
                            obj.IdVenta = Convert.ToInt32(dr["IdVenta"].ToString());
                            obj.CambioAntiguo = Convert.ToDecimal(dr["CambioAntiguo"].ToString());
                            obj.CambioNuevo = Convert.ToDecimal(dr["CambioNuevo"].ToString());
                            obj.Efectivo = Convert.ToDecimal(dr["Efectivo"].ToString());
                            obj.Gastos = Convert.ToDecimal(dr["Gastos"].ToString());
                            obj.MontoTotal = Convert.ToDecimal(dr["Total"].ToString());
                            obj.MercadoPago = Convert.ToDecimal(dr["TMercadoPago"].ToString());
                            obj.Otro = Convert.ToDecimal(dr["TOtro"].ToString());

                        }
                    }
                }
                catch (Exception e)
                {
                    obj = new Venta();
                }
            }

            return obj;

        }

        public List<DetalleVenta> TraerDetalleVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT p.IdProducto, p.Nombre, dv.PrecioVenta, dv.Cantidad, dv.Total, dv.FormaDePago FROM DETALLE_VENTA dv");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dv.IdProducto");
                    query.AppendLine("where dv.IdVenta = @idVenta");


                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DetalleVenta dv = new DetalleVenta();
                            dv.OProducto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            };
                            dv.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString());
                            dv.Cantidad = Convert.ToInt32(dr["Cantidad"].ToString());
                            dv.Total = Convert.ToDecimal(dr["Total"].ToString());
                            dv.FormaDePago = dr["FormaDePago"].ToString();

                            lista.Add(dv);
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<DetalleVenta>();
                }
            }

            return lista;

        }

        public List<DetalleCompra> TraerDetalleCompra(int idVenta)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT p.IdProducto, p.Nombre, dc.PrecioCompra, dc.Cantidad, dc.Total, dc.FormaDePago FROM DETALLE_COMPRA dc");
                    query.AppendLine("inner join PRODUCTO p on p.IdProducto = dc.IdProducto");
                    query.AppendLine("where dc.IdVenta = @idVenta");


                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DetalleCompra dc = new DetalleCompra();
                            dc.OProducto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            };
                            dc.PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString());
                            dc.Cantidad = Convert.ToInt32(dr["Cantidad"].ToString());
                            dc.FormaDePago = dr["FormaDePago"].ToString();

                            lista.Add(dc);
                        }
                    }
                }
                catch (Exception e)
                {
                    lista = new List<DetalleCompra>();
                }
            }

            return lista;

        }
    }
}
