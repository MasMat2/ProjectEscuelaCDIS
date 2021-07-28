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
    public partial class facultad_u : TemaEscuela, IAcceso
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    string codigo = Request.QueryString["pcodigo"];
                    cargarUniversidades();
                    cargarFacultad(codigo);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            modificarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Datos de la facultad modificados exitosamente.')", true);
        }

        #region Methods
        #region AccessBLL
        public void cargarFacultad(string codigo)
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtFacultad =  facuBLL.cargarFacultad(codigo);

            lblCodigo.Text = dtFacultad.Rows[0]["codigo"].ToString();
            txtNombre.Text = dtFacultad.Rows[0]["nombre"].ToString();
            txtFechaCreacion.Text = Convert.ToDateTime(dtFacultad.Rows[0]["fechaCreacion"]).ToString("dd/MM/yyyy");
            ddlUniversidad.SelectedValue = dtFacultad.Rows[0]["universidad"].ToString();
            cargarPaises();
            ddlPais.SelectedValue = dtFacultad.Rows[0]["pais"].ToString();
            cargarEstados();
            ddlEstado.SelectedValue = dtFacultad.Rows[0]["estado"].ToString();
            cargarCiudades();
            ddlCiudad.SelectedValue = dtFacultad.Rows[0]["ciudad"].ToString();

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
        
        public void modificarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();

            string codigo = lblCodigo.Text;
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaCreacion.Text);
            int universidad = int.Parse(ddlUniversidad.SelectedValue);


            facuBLL.modificarFacultad(codigo, nombre, fecha, universidad);
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