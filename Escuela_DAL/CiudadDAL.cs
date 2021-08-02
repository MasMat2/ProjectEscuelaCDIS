using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class CiudadDAL
    {

        EscuelaEntities modelo;

        public CiudadDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Ciudad> cargarCiudadesPorEstado(int estado)
        {
            var ciudades = from mCiudad in modelo.Ciudad
                            where mCiudad.estado == estado
                            select mCiudad;

            return ciudades.AsEnumerable<Ciudad>().ToList();
        }
    }
}
