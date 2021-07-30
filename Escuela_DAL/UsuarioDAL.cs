﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UsuarioDAL
    {
        EscuelaEntities modelo;

        public UsuarioDAL()
        {
            modelo = new EscuelaEntities();
        }
        public Usuario consultarUsuario(string nombre, string contrasena)
        {
            var usuario = (from mUsuario in modelo.Usuario
                          where mUsuario.nombre == nombre && mUsuario.contrasena == contrasena
                          select mUsuario).FirstOrDefault();

            return usuario;
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_consultarUsuario";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pNombre", nombre);
            //command.Parameters.AddWithValue("pContrasena", contrasena);

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtUsuario = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtUsuario);

            //connection.Close();

            //return dtUsuario;
        }
    }
}
