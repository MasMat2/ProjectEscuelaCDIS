using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class FacultadDAL
    {
        EscuelaEntities modelo;

        public FacultadDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<object> cargarFacultades()
        {
            var facultades = from mFacultades in modelo.Facultad
                             select new
                             {
                                 ID_Facultad = mFacultades.ID_Facultad,
                                 codigo = mFacultades.codigo,
                                 nombre = mFacultades.nombre,
                                 fechaCreacion = mFacultades.fechaCreacion,
                                 universidad = mFacultades.universidad,
                                 ciudad = mFacultades.ciudad,
                                 nombreUniversidad = mFacultades.Universidad1.nombre,
                                 nombreCiudad = mFacultades.Ciudad1.nombre
                             };

            return facultades.AsEnumerable<object>().ToList();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarFacultades";
            //command.Connection = connection;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtFacultades = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtFacultades);

            //connection.Close();

            //return dtFacultades;

        }
        public void agregarFacultad(Facultad Facultad)
        {

            modelo.Facultad.Add(Facultad);
            modelo.SaveChanges();

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_agregarFacultad";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pCodigo", codigo);
            //command.Parameters.AddWithValue("pNombre", nombre);
            //command.Parameters.AddWithValue("pFecha", fechaCreacion);
            //command.Parameters.AddWithValue("pUniversidad", universidad);
            //command.Parameters.AddWithValue("pCiudad", ciudad);

            //connection.Open();

            //command.ExecuteNonQuery();

            //connection.Close();

        }

        public Facultad cargarFacultad(string codigo)
        {
            var facultad = (from mFacultad in modelo.Facultad
                           where mFacultad.codigo == codigo
                           select mFacultad).FirstOrDefault();

            return facultad;

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarFacultad";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pCodigo", codigo);

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtFacultad = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtFacultad);

            //connection.Close();

            //return dtFacultad;
        }

        public void modificarFacultad(Facultad pFacultad)
        {

           var facultad = (from mFacultad in modelo.Facultad
                          where mFacultad.codigo == pFacultad.codigo
                          select mFacultad).FirstOrDefault();

            facultad.codigo = facultad.codigo;
            facultad.nombre = facultad.nombre;
            facultad.fechaCreacion = facultad.fechaCreacion;
            facultad.universidad = facultad.universidad;
            facultad.ciudad = facultad.ciudad;

            modelo.SaveChanges();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_modificarFacultad";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pCodigo", codigo);
            //command.Parameters.AddWithValue("pNombre", nombre);
            //command.Parameters.AddWithValue("pFechaCreacion", fechaCreacion);
            //command.Parameters.AddWithValue("pUniversidad", universidad);

            //connection.Open();

            //command.ExecuteNonQuery();

            //connection.Close();
        }

        public void eliminarFacultad(string codigo)
        {

            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.codigo == codigo
                            select mFacultad).FirstOrDefault();

            modelo.Facultad.Remove(facultad);
            modelo.SaveChanges();

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_eliminarFacultad";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pCodigo", codigo);

            //connection.Open();

            //command.ExecuteNonQuery();

            //connection.Close();
        }
    }
}
