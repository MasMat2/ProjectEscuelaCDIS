using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;

namespace Escuela
{
    public partial class Login : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/Facultades/facultad_s.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('Usuario y/o contraseña incorrectos.')", true);
            }

        }
        #endregion

        #region Methods
        public bool usuarioValido() 
        {
            bool acceso = false;

            UsuarioBLL userBLL = new UsuarioBLL();
            Usuario usuarioObject;

            usuarioObject = userBLL.consultarUsuario(txtUsuario.Text, txtContrasena.Text);

            if(usuarioObject != null)
            {
                Session["usuario"] = usuarioObject;
                acceso = true;
            }

            return acceso;
        }
        #endregion
    }
}