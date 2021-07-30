using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Escuela_DAL;

namespace Escuela
{
    public class TemaEscuela : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Session["usuario"] = new Usuario();
            if (Session["usuario"] != null)
            {
                Usuario usuarioObject;
                usuarioObject = (Usuario) Session["usuario"];

                string tipo = usuarioObject.tipo;

                if(tipo == "Administrator")
                {
                    Page.Theme = "Theme1";
                }
                else
                {
                    Page.Theme = "Theme2";
                }
            }
        }
    }
}