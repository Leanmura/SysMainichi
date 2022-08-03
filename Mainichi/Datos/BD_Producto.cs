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
    public class BD_Producto
    {
        public Producto TraerProducto(int id)
        {
            Producto producto = new Producto();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProducto, Nombre, p.Descripcion, PrecioVenta, PrecioCompra," +
                        " c.IdCategoria, c.Descripcion[Categoria], Imagen FROM PRODUCTO p ");
                    query.AppendLine("inner join CATEGORIA c on c.IdCategoria = p.IdCategoria");
                    query.AppendLine("where p.IdProducto = @id");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                           
                            //Console.WriteLine("{0} {1}", dataReader.GetInt32(0),  dataReader.GetString(1));
                            producto.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                            producto.Nombre = dataReader["Nombre"].ToString();
                            producto.Descripcion = dataReader["Descripcion"].ToString();
                            if (dataReader["PrecioVenta"] != DBNull.Value)
                                producto.PrecioVenta = Convert.ToDecimal(dataReader["PrecioVenta"]);
                            if (dataReader["PrecioCompra"] != DBNull.Value)
                                producto.PrecioCompra = Convert.ToDecimal(dataReader["PrecioCompra"]);
                            if (dataReader["Imagen"] != DBNull.Value)
                                producto.Imagen = (byte[])dataReader["Imagen"];

                            producto.OCategoria = new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dataReader["IdCategoria"]),
                                Descripcion = dataReader["Categoria"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    producto = new Producto();
                }
            }
            return producto;
        }

        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try

                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProducto, Nombre, p.Descripcion, PrecioVenta, PrecioCompra," +
                        " c.IdCategoria, c.Descripcion[Categoria], Imagen FROM PRODUCTO p ");
                    query.AppendLine("inner join CATEGORIA c on c.IdCategoria = p.IdCategoria");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Producto nuevoProducto = new Producto();
                            //Console.WriteLine("{0} {1}", dataReader.GetInt32(0),  dataReader.GetString(1));
                            nuevoProducto.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                            nuevoProducto.Nombre = dataReader["Nombre"].ToString();
                            nuevoProducto.Descripcion = dataReader["Descripcion"].ToString();
                            if(dataReader["PrecioVenta"] != DBNull.Value)
                                 nuevoProducto.PrecioVenta = Convert.ToDecimal(dataReader["PrecioVenta"]);
                            if (dataReader["PrecioCompra"] != DBNull.Value)
                                nuevoProducto.PrecioCompra = Convert.ToDecimal(dataReader["PrecioCompra"]);
                            if (dataReader["Imagen"] != DBNull.Value)
                                nuevoProducto.Imagen = (byte[])dataReader["Imagen"];

                            nuevoProducto.OCategoria = new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dataReader["IdCategoria"]),
                                Descripcion = dataReader["Categoria"].ToString()
                            };

                            lista.Add(nuevoProducto);

                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                }
            }

            return lista;
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            int idProductoGenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarProducto", oConexion);
                    //CREATE PROC SP_RegistrarProducto(
                    //    @Nombre varchar(50),
                    //    @Descripcion varchar(50),
                    //    @IdCategoria int,
                    //    @PrecioVenta decimal,
                    //    @Resultado int output,
                    //    @Mensaje varchar(500) output
                    //) as
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    //cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("idCategoria", obj.OCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Imagen", obj.Imagen);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // indicamos que son parametros de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    idProductoGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                idProductoGenerado = 0;
                mensaje = ex.Message;
            }
            return idProductoGenerado;
        }


        public bool Editar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarProducto", oConexion);
                    //CREATE PROCEDURE SP_EditarProducto(
                    //  @IdProducto int,
                    // @Nombre varchar(50),
                    //  @Descripcion varchar(50),
                    //  @PrecioVenta decimal,
                    //  @IdCategoria int,
                    //  @Resultado bit output,
                    //  @Mensaje varchar(500) output
                    //) as
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("PrecioVenta", obj.PrecioVenta);
                    cmd.Parameters.AddWithValue("PrecioCompra", obj.PrecioCompra);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.OCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Imagen", obj.Imagen);


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


        public bool Eliminar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oConexion);
                    //CREATE PROCEDURE SP_EliminarProducto(
                    //    @IdProducto int,
                    //    @Resultado bit output,
                    //    @Mensaje varchar(500) output
                    //)
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);

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
    }
}
