using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class AlumnoBLL
    {
        public List<object> cargarAlumnos()
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumnos();
        }

        public void agregarAlumno(Alumno pAlumno)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            DataTable dtAlumno = new DataTable();

            dtAlumno = cargarAlumno(pAlumno.matricula);

            if (dtAlumno.Rows.Count > 0)
            {
                throw new Exception("La matricula ya existe en la base de datos.");
            }
            else
            {
                int edad = DateTime.Now.Year - pAlumno.fechaNacimiento.Year;
                if (edad > 80)
                {
                    throw new Exception("El alumno es demasiado viejo ingresa otra fecha de nacimiento.");
                }
                else
                {
                    alumno.agregarAlumno(pAlumno);
                }
            }
        }
        public Alumno cargarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumno(matricula);
        }

        public void modificarAlumno(Alumno alumno)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.modificarAlumno(matricula, nombre, fechaNacimiento, semestre, facultad, ciudad);
        }

        public void eliminarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            alumno.eliminarAlumno(matricula);
        }
    }
}
