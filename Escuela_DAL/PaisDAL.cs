using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class PaisDAL
    {
        EscuelaEntities modelo;

        public PaisDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Pais> cargarPaises()
        {

            var paises = from mPais in modelo.Pais
                          select mPais;

            return paises.AsEnumerable<Pais>().ToList();


            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarPaises";
            //command.Connection = connection;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtPaises = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtPaises);

            //connection.Close();

            //return dtPaises;
        }
    }
}
