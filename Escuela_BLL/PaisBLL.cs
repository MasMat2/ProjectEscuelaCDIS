using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class PaisBLL
    {
        public DataTable cargarPaises()
        {
            PaisDAL pais = new PaisDAL();
            return pais.cargarPaises();
        }
    }
}
