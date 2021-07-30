using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class EstadoBLL
    {
        public List<Estado> cargarEstados()
        {
            EstadoDAL estado = new EstadoDAL();
            return estado.cargarEstados();
        }

        public List<Estado> cargarEstadosPorPais(int pais)
        {
            EstadoDAL estado = new EstadoDAL();
            return estado.cargarEstadosPorPais(pais);
        }
    }
}
