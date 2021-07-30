﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UniversidadDAL
    {
        EscuelaEntities modelo;

        public UniversidadDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Universidad> cargarUnivesidades()
        {

            var universidades = from mUniversidad in modelo.Universidad
                                select mUniversidad;

            return universidades.AsEnumerable<Universidad>().ToList();

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarUniversidades";
            //command.Connection = connection;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtFacultades = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtFacultades);

            //connection.Close();

            //return dtFacultades;

        }
    }
}
