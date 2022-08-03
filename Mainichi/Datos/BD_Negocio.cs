using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class BD_Negocio
    {
        public Negocio ObtenerDatos()
        {
            Negocio obj = new Negocio();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "select IdNegocio,Nombre,Telefono,Direccion from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            obj.IdNegocio = int.Parse(dr["IdNegocio"].ToString());
                            obj.Nombre = dr["Nombre"].ToString();
                            obj.Telefono = dr["Telefono"].ToString();
                            obj.Direccion = dr["Direccion"].ToString();
                        }
                    }
                }
            }
            catch
            {
                obj = new Negocio();
            }
            return obj;
        }

        public bool GuardarDatos(Negocio objeto, out string mensaje)
        {
            mensaje = "No se pudo guardar los datos.";
            bool respuesta = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update NEGOCIO set Nombre=@nombre,");
                    query.AppendLine("Telefono=@telefono,");
                    query.AppendLine("Direccion=@direccion, ");
                    query.AppendLine("Logo=@logo ");

                    query.AppendLine("where IdNegocio =1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("@telefono", objeto.Telefono);
                    cmd.Parameters.AddWithValue("@direccion", objeto.Direccion);
                    cmd.Parameters.AddWithValue("@logo", objeto.Imagen);


                    cmd.CommandType = System.Data.CommandType.Text;
                    if(cmd.ExecuteNonQuery()>=1)
                    {
                        mensaje = "Negocio actualizado con exito.";
                        respuesta = true;
                    }
                }
            }
            catch(Exception e)
            {
                mensaje = e.Message;
            }
            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = false;
            byte[] logoBytes = new byte[0];
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "select Logo from NEGOCIO where IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            logoBytes = (byte[])dr["Logo"];
                        }
                        obtenido = true;

                    }
                }
            }
            catch
            {
                logoBytes = new byte[0];
            }
            return logoBytes;
        }

    }
}
