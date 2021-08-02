using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UniversidadDAL
    {
        EscuelaEntities modelo;

        public UniversidadDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Universidad> cargarUnivesidades()
        {

            var universidades = from mUniversidad in modelo.Universidad
                                select mUniversidad;

            return universidades.AsEnumerable<Universidad>().ToList();

        }
    }
}
