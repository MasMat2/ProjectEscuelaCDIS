using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escuela_DAL;
using System.Transactions;

namespace Escuela_BLL
{
    public class FacultadBLL
    {
        public List<object> cargarFacultades()
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultades();
        }
        public void agregarFacultad(Facultad pFacultad, List<MateriaFacultad> listMateriaFacultad)
        {
            FacultadDAL facultadDAL = new FacultadDAL();
            Facultad facultadCargada;
            MateriaFacultadBLL materiaFacultadBLL = new MateriaFacultadBLL();

            facultadCargada = cargarFacultad(pFacultad.codigo);
            if (facultadCargada != null)
            {
                throw new Exception("El código de la facultad ya existe, introduce un código diferente");
            }
            else
            {
                int ano = pFacultad.fechaCreacion.Year;
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

                    using (TransactionScope ts = new TransactionScope())
                    {
                        facultadDAL.agregarFacultad(pFacultad);
                        int facultad_id = facultadDAL.cargarFacultad(pFacultad.codigo).ID_Facultad;
                        foreach (MateriaFacultad entity in listMateriaFacultad)
                        {

                            entity.facultad = facultad_id;
                            materiaFacultadBLL.agregarMateriaFacultad(entity);
                        }

                        ts.Complete();
                    }
                }
            }
        }

        public Facultad cargarFacultad(string codigo)
        {
            FacultadDAL facultad = new FacultadDAL();
            return facultad.cargarFacultad(codigo);
        }

        public void modificarFacultad(Facultad pFacultad)
        {
            FacultadDAL facultad = new FacultadDAL();
            facultad.modificarFacultad(pFacultad);
        }

        public void eliminarFacultad(string codigo)
        {
            FacultadDAL facultadDAL = new FacultadDAL();
            MateriaFacultadBLL materiaFacultadBLL = new MateriaFacultadBLL();

            using (TransactionScope ts = new TransactionScope())
            {
                materiaFacultadBLL.eliminarEntidadesPorFacultad(codigo);
                facultadDAL.eliminarFacultad(codigo);
                ts.Complete();

            }
        }
    }

}
