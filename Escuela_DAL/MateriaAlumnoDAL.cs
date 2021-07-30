using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class MateriaAlumnoDAL
    {
        EscuelaEntities modelo;

        public MateriaAlumnoDAL()
        {
            modelo = new EscuelaEntities();
        }

        public void agregarMateriaAlumno(MateriaAlumno entidad)
        {
            modelo.MateriaAlumno.Add(entidad);
            modelo.SaveChanges();
        }

        public void eliminarEntidadesPorAlumno(int matricula)
        {
            var entidades = from matAlumno in modelo.MateriaAlumno
                           where matAlumno.alumno == matricula
                           select matAlumno;

            foreach(MateriaAlumno entidad in entidades)
            {
                modelo.MateriaAlumno.Remove(entidad);
                modelo.SaveChanges();
            }
        }
    }
}
