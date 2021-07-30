using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class MateriaFacultadBLL
    {
        public void agregarMateriaFacultad(MateriaFacultad entidad)
        {
            MateriaFacultadDAL materiaFacultadDAL = new MateriaFacultadDAL();
            materiaFacultadDAL.agregarMateriaFacultad(entidad);
        }

        public void eliminarEntidadesPorFacultad(string codigo)
        {
            MateriaFacultadDAL materiaFacultadDAL = new MateriaFacultadDAL();
            materiaFacultadDAL.eliminarEntidadesPorFacultad(codigo);
        }
    }
}
