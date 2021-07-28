using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public DataTable cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }
        public void agregarFacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad, int ciudad)
        {
            FacultadDAL facultad = new FacultadDAL();
            DataTable dtFacultad = new DataTable();

            dtFacultad = cargarFacultad(codigo);
            if (dtFacultad.Rows.Count > 0)
            {
                throw new Exception("El código de la facultad ya existe, introduce un código diferente");
            }
            else
            {
                int ano = fechaCreacion.Year;
                if (ano < 1900)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha mayor a 1900.");
                }
                else if (ano > 2010)
                {
                    throw new Exception("Fecha no permitida, introduce una fecha menor a 2010.");
                }
                else
                {
                    facultad.agregarFacultad(codigo, nombre, fechaCreacion, universidad, ciudad);
                }
                
            }
        }

        public DataTable cargarFacultad(string codigo)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(codigo);
        }

        public void modificarFacultad(string codigo, string nombre, DateTime fechaCreacion, int universidad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.modificarFacultad(codigo, nombre, fechaCreacion, universidad);
        }

        public void eliminarFacultad(string codigo)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.eliminarFacultad(codigo);
        }
    }
 
}
