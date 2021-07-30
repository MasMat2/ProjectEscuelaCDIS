using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class AlumnoDAL
    {
        EscuelaEntities modelo;

        public AlumnoDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<object> cargarAlumnos()
        {
            var alumnos = from mAlumnos in modelo.Alumno
                          select new
                          {
                              matricula = mAlumnos.matricula,
                              nombre = mAlumnos.nombre,
                              fechaNacimiento = mAlumnos.fechaNacimiento,
                              semestre = mAlumnos.semestre,
                              nombreFacultad = mAlumnos.Facultad1.nombre,
                              nombreCiudad = mAlumnos.Ciudad1.nombre
                          };

            return alumnos.AsEnumerable<object>().ToList();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarAlumnos";
            //command.Connection = connection;

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtAlumnos = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtAlumnos);

            //connection.Close();

            //return dtAlumnos;
        }

        public void agregarAlumno(Alumno pAlumno)
        {
            modelo.Alumno.Add(pAlumno);
            modelo.SaveChanges();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_agregarAlumno";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pMatricula", matricula);
            //command.Parameters.AddWithValue("pNombre", nombre);
            //command.Parameters.AddWithValue("pFecha", fechaNacimiento);
            //command.Parameters.AddWithValue("pSemestre", semestre);
            //command.Parameters.AddWithValue("pFacultad", facultad);
            //command.Parameters.AddWithValue("pCiudad", ciudad);

            //connection.Open();

            //command.ExecuteNonQuery();

            //connection.Close();

        }

        public Alumno cargarAlumno(int matricula)
        {
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == matricula
                          select mAlumno).FirstOrDefault();

            return alumno;
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_cargarAlumnoPorMatricula";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pMatricula", matricula);

            //SqlDataAdapter adapter = new SqlDataAdapter();
            //DataTable dtAlumno = new DataTable();

            //connection.Open();

            //adapter.SelectCommand = command;
            //adapter.Fill(dtAlumno);

            //connection.Close();

            //return dtAlumno;
        }

        public void modificarAlumno(Alumno pAlumno)
        {
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == pAlumno.matricula
                          select mAlumno).FirstOrDefault();

            alumno.nombre = pAlumno.nombre;
            alumno.fechaNacimiento = pAlumno.fechaNacimiento;
            alumno.semestre = pAlumno.semestre;
            alumno.facultad = pAlumno.facultad;
            alumno.ciudad = pAlumno.ciudad;

            modelo.SaveChanges();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_modificarAlumno";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pMatricula", matricula);
            //command.Parameters.AddWithValue("pNombre", nombre);
            //command.Parameters.AddWithValue("pFecha", fechaNacimiento);
            //command.Parameters.AddWithValue("pSemestre", semestre);
            //command.Parameters.AddWithValue("pFacultad", facultad);
            //command.Parameters.AddWithValue("pCiudad", ciudad);

            //connection.Open();

            //command.ExecuteNonQuery();

            //connection.Close();
        }

        public void eliminarAlumno(int matricula)
        {
            var alumno = (from mAlumno in modelo.Alumno
                          where mAlumno.matricula == matricula
                          select mAlumno).FirstOrDefault();

            modelo.Alumno.Remove(alumno);
            modelo.SaveChanges();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = @"Server=DESKTOP-98VGB3G;Database=Escuela;Trusted_connection=true";

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "sp_eliminarAlumno";
            //command.Connection = connection;

            //command.Parameters.AddWithValue("pMatricula", matricula);

            //connection.Open();

            //command.ExecuteNonQuery();

            //connection.Close();
        }
    }


}
