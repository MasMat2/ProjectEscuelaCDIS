using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escuela
{
    public class TemaEscuela : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if(Session["usuario"] != null)
            {
                DataTable dtUsuario = new DataTable();
                dtUsuario = (DataTable)Session["usuario"];

                string tipo = dtUsuario.Rows[0]["tipo"].ToString();

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