using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela_DAL
{
    public class UsuarioDAL
    {
        EscuelaEntities modelo;

        public UsuarioDAL()
        {
            modelo = new EscuelaEntities();
        }
        public Usuario consultarUsuario(string nombre, string contrasena)
        {
            var usuario = (from mUsuario in modelo.Usuario
                          where mUsuario.nombre == nombre && mUsuario.contrasena == contrasena
                          select mUsuario).FirstOrDefault();

            return usuario;
        }
    }
}
