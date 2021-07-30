using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Transactions;

namespace Escuela_BLL
{
    public class AlumnoBLL
    {
        public List<object> cargarAlumnos()
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumnos();
        }

        public void agregarAlumno(Alumno pAlumno, List<MateriaAlumno> listMaterias)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            Alumno alumnoCargado;
            MateriaAlumnoBLL materiaAlumnoBLL = new MateriaAlumnoBLL();


            alumnoCargado = cargarAlumno(pAlumno.matricula);

            if (alumnoCargado != null)
            {
                throw new Exception("La matricula ya existe en la base de datos.");
            }
            else
            {
                using(TransactionScope ts = new TransactionScope())
                {
                    alumno.agregarAlumno(pAlumno);
                    
                    foreach(MateriaAlumno entity in listMaterias)
                    {
                        materiaAlumnoBLL.agregarMateriaAlumno(entity);
                    }

                    ts.Complete();
                }
                //int edad = DateTime.Now.Year - pAlumno.fechaNacimiento.Year;
                //if (edad > 80)
                //{
                //    throw new Exception("El alumno es demasiado viejo ingresa otra fecha de nacimiento.");
                //}
                //else
                //{
                //    alumno.agregarAlumno(pAlumno);
                //}
            }
        }
        public Alumno cargarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            return alumno.cargarAlumno(matricula);
        }

        public void modificarAlumno(Alumno pAlumno, List<MateriaAlumno> listMateriaAlumno)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            MateriaAlumnoBLL materiaAlumnoBLL = new MateriaAlumnoBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                alumno.modificarAlumno(pAlumno);
                materiaAlumnoBLL.eliminarEntidadesPorAlumno(pAlumno.matricula);

                foreach (MateriaAlumno entity in listMateriaAlumno)
                {
                    materiaAlumnoBLL.agregarMateriaAlumno(entity);
                }

                ts.Complete();

            }
        }

        public void eliminarAlumno(int matricula)
        {
            AlumnoDAL alumno = new AlumnoDAL();
            MateriaAlumnoBLL materiaAlumnoBLL = new MateriaAlumnoBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                materiaAlumnoBLL.eliminarEntidadesPorAlumno(matricula);
                alumno.eliminarAlumno(matricula);
                ts.Complete();

            }
        }
    }
}
