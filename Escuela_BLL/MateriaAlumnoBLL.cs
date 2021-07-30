using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class MateriaAlumnoBLL
    {
        public void agregarMateriaAlumno(MateriaAlumno entidad)
        {
            MateriaAlumnoDAL materiaAlumnoDAL = new MateriaAlumnoDAL();
            materiaAlumnoDAL.agregarMateriaAlumno(entidad);

        }

        public void eliminarEntidadesPorAlumno(int matricula)
        {
            MateriaAlumnoDAL materiaAlumnoDAL = new MateriaAlumnoDAL();
            materiaAlumnoDAL.eliminarEntidadesPorAlumno(matricula);
        }
    }
}
