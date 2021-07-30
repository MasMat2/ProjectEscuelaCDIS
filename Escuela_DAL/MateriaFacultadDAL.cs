using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class MateriaFacultadDAL
    {
        EscuelaEntities modelo;

        public MateriaFacultadDAL()
        {
            modelo = new EscuelaEntities();
        }

        public void agregarMateriaFacultad(MateriaFacultad entidad)
        {
            modelo.MateriaFacultad.Add(entidad);
            modelo.SaveChanges();
        }

        public void eliminarEntidadesPorFacultad(string codigo)
        {
            var entidades = from matFacultad in modelo.MateriaFacultad
                            where matFacultad.Facultad1.codigo == codigo
                            select matFacultad;

            foreach (MateriaFacultad entidad in entidades)
            {
                modelo.MateriaFacultad.Remove(entidad);
                modelo.SaveChanges();
            }
        }
    }
}
