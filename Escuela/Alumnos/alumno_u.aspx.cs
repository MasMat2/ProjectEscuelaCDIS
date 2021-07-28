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
    public partial class alumno_u : TemaEscuela, IAcceso
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sessionIniciada()) 
                { 
                    int matricula = int.Parse(Request.QueryString["pMatricula"]);
                    cargarFacultades();
                    cargarAlumno(matricula);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            modificarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Datos del alumno modificados exitosamente.')", true);
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCiudad.Items.Clear();
            if(ddlEstado.SelectedIndex != 0)
            {
                cargarCiudades();
            }
        }
        #endregion

        #region Methods
        #region AccessBLL
        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            DataTable dtAlumno = new DataTable();

            dtAlumno = alumBLL.cargarAlumno(matricula);

            lblMatricula.Text = dtAlumno.Rows[0]["matricula"].ToString();
            txtNombre.Text = dtAlumno.Rows[0]["nombre"].ToString();
            txtFechaNacimiento.Text = dtAlumno.Rows[0]["fechaNacimiento"].ToString().Substring(0,10);
            txtSemestre.Text = dtAlumno.Rows[0]["semestre"].ToString();
            ddlFacultad.SelectedValue = dtAlumno.Rows[0]["facultad"].ToString();

            cargarEstados();
            ddlEstado.SelectedValue = dtAlumno.Rows[0]["estado"].ToString();

            cargarCiudades();
            ddlCiudad.SelectedValue = dtAlumno.Rows[0]["ciudad"].ToString();
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

        public void modificarAlumno()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();

            int matricula = int.Parse(lblMatricula.Text);
            string nombre = txtNombre.Text;
            DateTime fecha = Convert.ToDateTime(txtFechaNacimiento.Text);
            int semestre = int.Parse(txtSemestre.Text);
            int facultad = int.Parse(ddlFacultad.SelectedValue);
            int ciudad = int.Parse(ddlCiudad.SelectedValue);

            alumBLL.modificarAlumno(matricula, nombre, fecha, semestre, facultad, ciudad);

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