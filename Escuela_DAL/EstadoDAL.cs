using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class EstadoDAL
    {
        EscuelaEntities modelo;

        public EstadoDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Estado> cargarEstados()
        {
            var estados = from mEstado in modelo.Estado
                            select mEstado;

            return estados.AsEnumerable<Estado>().ToList();

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarEstados";
            //command.Connection = connection;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtEstados = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtEstados);

            //connection.Close();

            //return dtEstados;
        }

        public List<Estado> cargarEstadosPorPais(int pais)
        {
            var estados = from mEstado in modelo.Estado
                          where mEstado.pais == pais
                          select mEstado;

            return estados.AsEnumerable<Estado>().ToList();

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarEstadosPorPais";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pPais", pais);

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtCiudades = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtCiudades);

            //connection.Close();

            //return dtCiudades;
        }
    }
}
