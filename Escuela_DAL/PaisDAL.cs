using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class PaisDAL
    {
        EscuelaEntities modelo;

        public PaisDAL()
        {
            modelo = new EscuelaEntities();
        }

        public List<Pais> cargarPaises()
        {

            var paises = from mPais in modelo.Pais
                          select mPais;

            return paises.AsEnumerable<Pais>().ToList();
        }
    }
}
