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

        }
        public void agregarFacultad(Facultad Facultad)
        {

            modelo.Facultad.Add(Facultad);
            modelo.SaveChanges();
        }

        public Facultad cargarFacultad(string codigo)
        {
            var facultad = (from mFacultad in modelo.Facultad
                           where mFacultad.codigo == codigo
                           select mFacultad).FirstOrDefault();

            return facultad;
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
        }

        public void eliminarFacultad(string codigo)
        {

            var facultad = (from mFacultad in modelo.Facultad
                            where mFacultad.codigo == codigo
                            select mFacultad).FirstOrDefault();

            modelo.Facultad.Remove(facultad);
            modelo.SaveChanges();
        }
    }
}
