using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Persistencia.Entidades;
using Persistencia.Contratos;


namespace Persistencia.Repositorios
{
    public class MensajesRepo : IObtenerMensajes
    {
        /*select nombre, mensaje from chat
        inner join usuarios on usuarios.id = chat.id_usuario
        where chat.id_diag=1;*/
        public List<MensajeEntidad> GetMensajes(long diag)
        {
            
            List<MensajeEntidad> list = new List<MensajeEntidad>();
            MySqlConnection conexion = null;
            try
            {
                MySqlDataReader reader = null;
                conexion = ConexionDB.GetConexion();
                conexion.Open();                    
                string sql;
                sql = @"select nombre, mensaje from chat
                        inner join usuarios on usuarios.id = chat.id_usuario
                        where chat.id_diag=?diag";
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                //comando.Parameters.AddWithValue("@diag", diag);
                comando.Parameters.Add("?diag", MySqlDbType.Int64).Value= diag;
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nombre = (reader[0] != DBNull.Value) ? reader.GetString(0) : "";
                        string mensaje = (reader[1] != DBNull.Value) ? reader.GetString(1) : "";
                        MensajeEntidad dataMensaje = new MensajeEntidad(nombre, mensaje);
                        list.Add(dataMensaje);
                    }
                }

            }
            catch (MySqlException ex)
            {
                string mensaje = ex.ToString();
                Console.WriteLine("hola" + mensaje);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return list;            
        }
    }
}
