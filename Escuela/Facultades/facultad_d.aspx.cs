using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Facultades
{
    public partial class facultad_d : TemaEscuela, IAcceso
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    string codigo = Request.QueryString["pCodigo"];
                    cargarUniversidades();
                    cargarFacultad(codigo);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad eliminada exitosamente.')", true);
        }
        #endregion

        #region Methods
        public void cargarFacultad(string codigo)
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtFacultad = facuBLL.cargarFacultad(codigo);

            lblCodigo.Text = dtFacultad.Rows[0]["codigo"].ToString();
            lblNombre.Text = dtFacultad.Rows[0]["nombre"].ToString();
            lblFechaCreacion.Text = Convert.ToDateTime(dtFacultad.Rows[0]["fechaCreacion"]).ToString("dd/MM/yyyy");
            ddlUniversidad.SelectedValue = dtFacultad.Rows[0]["universidad"].ToString();

            ddlCiudad.Items.Insert(0, new ListItem(dtFacultad.Rows[0]["nombreCiudad"].ToString()));
            ddlCiudad.SelectedValue = "0";
        }

        public void cargarUniversidades()
        {
            UniversidadBLL uniBLL = new UniversidadBLL();
            DataTable dtUniversidades = new DataTable();

            dtUniversidades = uniBLL.cargarUniversidades();

            ddlUniversidad.DataSource = dtUniversidades;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Universidad {0}", new String('-', 4)), "0"));
        }

        public void eliminarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            /*move to class state*/
            string codigo = Request.QueryString["pCodigo"];
            facuBLL.eliminarFacultad(codigo);
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