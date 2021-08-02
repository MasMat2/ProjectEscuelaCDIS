using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class EstadoDAL
    {
        EscuelaEntities modelo;

        public EstadoDAL()
        {
            modelo = new EscuelaEntities();
        }
        public List<Estado> cargarEstados()
        {
            var estados = from mEstado in modelo.Estado
                            select mEstado;

            return estados.AsEnumerable<Estado>().ToList();
        }

        public List<Estado> cargarEstadosPorPais(int pais)
        {
            var estados = from mEstado in modelo.Estado
                          where mEstado.pais == pais
                          select mEstado;

            return estados.AsEnumerable<Estado>().ToList();
        }
    }
}
