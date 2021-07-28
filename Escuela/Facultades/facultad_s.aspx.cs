using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;


namespace Escuela.Facultades
{
    public partial class facultad_s : TemaEscuela, IAcceso
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    grd_facultades.DataSource = cargarFacultades();
                    grd_facultades.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected void grd_facultades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Response.Redirect(String.Format("~/Facultades/facultad_u.aspx?pCodigo={0}", e.CommandArgument));
            }
            else
            {
                Response.Redirect(String.Format("~/Facultades/facultad_d.aspx?pCodigo={0}", e.CommandArgument));
            }
        }
        #endregion

        #region Methods
        public DataTable cargarFacultades()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtFacultades = new DataTable();

            dtFacultades = facuBLL.cargarFacultades();

            return dtFacultades;
        }
        public bool sessionIniciada()
        {
            if (Session["usuario"] != null)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}