using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Alumnos
{
    public partial class alumno_s : TemaEscuela, IAcceso
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada()) 
                { 
                    grd_alumnos.DataSource = cargarAlumnos();
                    //grd_alumnos.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void grd_alumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Editar")
            {
                Response.Redirect(String.Format("~/Alumnos/alumno_u.aspx?pMatricula={0}", e.CommandArgument));
            }
            else
            {
                Response.Redirect(String.Format("~/Alumnos/alumno_d.aspx?pMatricula={0}", e.CommandArgument));
            }
        }
        #endregion

        #region Methods
        public List<object> cargarAlumnos()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            List<object> listAlumnos; 

            listAlumnos = alumBLL.cargarAlumnos();

            return listAlumnos;
        }

        public bool sessionIniciada()
        {
            if(Session["usuario"] != null)
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}