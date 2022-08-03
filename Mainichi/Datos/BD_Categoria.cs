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
    public class BD_Categoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using(SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT * from CATEGORIA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            Categoria nuevaCategoria = new Categoria();
                            //Console.WriteLine("{0} {1}", dataReader.GetInt32(0),  dataReader.GetString(1));
                            nuevaCategoria.IdCategoria = Convert.ToInt32(dataReader["IdCategoria"]);
                            nuevaCategoria.Descripcion = dataReader["Descripcion"].ToString();
                            lista.Add(nuevaCategoria);

                        }
                    }
                }
                catch(Exception ex)
                {
                    lista = new List<Categoria>();
                }
            }

            return lista;
        }

        public int Registrar(Categoria obj, out string mensaje)
        {
            int idCategoriaGenerada = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCategoria", oConexion);
                    //CREATE PROC SP_RegistrarCategoria(
                    // @Descripcion varchar(50),
                    //@Resultado int output,
                    // @Mensaje varchar(500) output
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; // indicamos que son parametros de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    idCategoriaGenerada = Convert.ToInt32(cmd.Parameters["Resultado"].Value); 
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                idCategoriaGenerada = 0;
                mensaje = ex.Message;
            }
            return idCategoriaGenerada;
        }


        public bool Editar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarCategoria", oConexion);
                //CREATE PROCEDURE SP_EditarCategoria(
                //@IdCategoria int,
                //@Descripcion varchar(50),
                //@Resultado bit output,
                //@Mensaje varchar(500) output
                //)
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // indicamos que son parametros de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

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


        public bool Eliminar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarCategoria", oConexion);
                    //CREATE PROCEDURE SP_EliminarCategoria(
                    //    @IdCategoria int,
                    //    @Resultado bit output,
                    //    @Mensaje varchar(500) output
                    //)
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output; // indicamos que son parametros de salida
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

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
