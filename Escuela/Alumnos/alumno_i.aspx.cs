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
    public partial class alumno_i : TemaEscuela, IAcceso
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada())
                {
                    cargarFacultades();
                    cargarEstados();
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
            agregarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno agregado exitosamente.')", true);
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
        public void agregarAlumno()
        {

            AlumnoBLL alumBLL = new AlumnoBLL();

            int matricula = int.Parse(txtMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaNacimiento.Text);
            int semestre = int.Parse(txtSemestre.Text);
            int facultad = int.Parse(ddlFacultad.SelectedValue);
            int ciudad = int.Parse(ddlCiudad.SelectedValue);

            try
            {
                alumBLL.agregarAlumno(matricula, nombre, fecha, semestre, facultad, ciudad);
                limpiarCampos();

                DataTable dtAlumnos = new DataTable();
                dtAlumnos = (DataTable) ViewState["tablaAlumnos"];
                dtAlumnos.Rows.Add(matricula, nombre);
                grd_alumnos.DataSource = dtAlumnos;
                grd_alumnos.DataBind();

            }catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", String.Format("alert('{0}')", ex.Message), true);
            }

        }

        public void cargarFacultades()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            DataTable dtFacultades = new DataTable();

            dtFacultades = facuBLL.cargarFacultades();

            ddlFacultad.DataSource = dtFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Facultad {0}", new String('-', 4)), "0"));
        }

        public void cargarEstados()
        {
            EstadoBLL estadoBLL = new EstadoBLL();
            DataTable dtEstados = new DataTable();

            dtEstados = estadoBLL.cargarEstados();

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

            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtFechaNacimiento.Text = "";
            txtSemestre.Text = "";
            ddlFacultad.SelectedValue = "0";

        }

        public void cargarTabla()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("matricula");
            dt.Columns.Add("nombre");

            ViewState["tablaAlumnos"] = dt;
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