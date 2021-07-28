using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;

namespace Escuela.Facultades
{
    public partial class facultad_i : TemaEscuela, IAcceso
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    cargarUniversidades();
                    cargarPaises();
                    cargarTabla();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Universidad agregada exitosamente.')", true);
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEstado.Items.Clear();
            if (ddlPais.SelectedIndex != 0)
            {
                cargarEstados();
                cargarCiudades();
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCiudad.Items.Clear();
            if (ddlEstado.SelectedIndex != 0)
            {
                cargarCiudades();
            }
        }
        #endregion
        #region Methods
        #region AccessBLL
        public void agregarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtFacultades = new DataTable();

            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            DateTime fecha = DateTime.ParseExact(txtFechaCreacion.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int universidad = int.Parse(ddlUniversidad.SelectedValue);
            int ciudad = int.Parse(ddlCiudad.SelectedValue);

            try
            {
                facuBLL.agregarFacultad(codigo, nombre, fecha, universidad, ciudad);
                limpiarCampos();

                DataTable dtAlumnos = new DataTable();
                dtAlumnos = (DataTable)ViewState["tablaFacultades"];
                dtAlumnos.Rows.Add(codigo, nombre);
                grd_facultades.DataSource = dtAlumnos;
                grd_facultades.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", String.Format("alert('{0}')", ex.Message), true);
            }

        }

        public void cargarUniversidades()
        {
            UniversidadBLL facuBLL = new UniversidadBLL();
            DataTable dtUniversidades = new DataTable();

            dtUniversidades = facuBLL.cargarUniversidades();

            ddlUniversidad.DataSource = dtUniversidades;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Universidad {0}", new String('-', 4)), "0"));
        }

        public void cargarPaises()
        {
            PaisBLL paisBLL = new PaisBLL();
            DataTable dtPaises = new DataTable();

            dtPaises = paisBLL.cargarPaises();

            ddlPais.DataSource = dtPaises;
            ddlPais.DataTextField = "nombre";
            ddlPais.DataValueField = "ID_Pais";
            ddlPais.DataBind();

            ddlPais.Items.Insert(0, new ListItem(String.Format("{0} Selecione Pais {0}", new String('-', 4)), "0"));
        }
        public void cargarEstados()
        {
            EstadoBLL estadoBLL = new EstadoBLL();
            DataTable dtEstados = new DataTable();

            dtEstados = estadoBLL.cargarEstadosPorPais(int.Parse(ddlPais.SelectedValue));

            ddlEstado.DataSource = dtEstados;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();

            ddlEstado.Items.Insert(0, new ListItem(String.Format("{0} Selecione Estado {0}", new String('-', 4)), "0"));
        }

        public void cargarCiudades()
        {
            CiudadBLL ciudadBLL = new CiudadBLL();
            DataTable dtCiudades = new DataTable();

            dtCiudades = ciudadBLL.cargarCiudadesPorEstado(int.Parse(ddlEstado.SelectedValue));

            ddlCiudad.DataSource = dtCiudades;
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Ciudad {0}", new String('-', 4)), "0"));

        }
        #endregion

        public void limpiarCampos()
        {

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtFechaCreacion.Text = "";
            ddlUniversidad.SelectedValue = "0";
            ddlPais.SelectedValue = "0";
            ddlEstado.SelectedValue = "0";
            ddlCiudad.SelectedValue = "0";

        }

        public void cargarTabla()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("codigo");
            dt.Columns.Add("nombre");

            ViewState["tablaFacultades"] = dt;
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