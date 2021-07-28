using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class CiudadDAL
    {
        public DataTable cargarCiudadesPorEstado(int estado)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_cargarCiudadesPorEstado";
            command.Connection = connection;

            command.Parameters.AddWithValue("pEstado", estado);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtCiudades = new DataTable();

            connection.Open();

            adapter.SelectCommand = command;
            adapter.Fill(dtCiudades);

            connection.Close();

            return dtCiudades;
        }
    }
}
