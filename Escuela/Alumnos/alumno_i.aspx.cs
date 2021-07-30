using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;
using System.Globalization;

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
                    cargarCiudades();
                    cargarMaterias();
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

            Alumno alumno = new Alumno();
            alumno.matricula = int.Parse(txtMatricula.Text);
            alumno.nombre = txtNombre.Text;
            alumno.fechaNacimiento = DateTime.ParseExact(txtFechaNacimiento.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);;
            alumno.semestre = int.Parse(txtSemestre.Text);
            alumno.facultad = int.Parse(ddlFacultad.SelectedValue);
            alumno.ciudad = int.Parse(ddlCiudad.SelectedValue);

            try
            {

                MateriaAlumno materiaAlumno;
                List<MateriaAlumno> listMaterias = new List<MateriaAlumno>();

                foreach(ListItem item in listBoxMaterias.Items)
                {
                    if (item.Selected)
                    {
                        materiaAlumno = new MateriaAlumno();
                        materiaAlumno.materia = int.Parse(item.Value);
                        materiaAlumno.alumno = alumno.matricula;
                        listMaterias.Add(materiaAlumno);
                    }
                }

                alumBLL.agregarAlumno(alumno, listMaterias);
                limpiarCampos();

                DataTable dtAlumnos = new DataTable();
                dtAlumnos = (DataTable) ViewState["tablaAlumnos"];
                dtAlumnos.Rows.Add(alumno.matricula, alumno.nombre);
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
            List<object> listFacultades;

            listFacultades = facuBLL.cargarFacultades();

            ddlFacultad.DataSource = listFacultades;
            ddlFacultad.DataTextField = "nombre";
            ddlFacultad.DataValueField = "ID_Facultad";
            ddlFacultad.DataBind();

            ddlFacultad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Facultad {0}", new String('-', 4)), "0"));
        }

        public void cargarEstados()
        {
            EstadoBLL estadoBLL = new EstadoBLL();
            List<Estado> listEstados;

            listEstados = estadoBLL.cargarEstados();

            ddlEstado.DataSource = listEstados;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();

            ddlEstado.Items.Insert(0, new ListItem(String.Format("{0} Selecione Estado {0}", new String('-', 4)), "0"));
        }

        public void cargarCiudades()
        {
            CiudadBLL ciudadBLL = new CiudadBLL();
            List<Ciudad> listCiudades;

            listCiudades = ciudadBLL.cargarCiudadesPorEstado(int.Parse(ddlEstado.SelectedValue));

            ddlCiudad.DataSource = listCiudades;
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Ciudad {0}", new String('-', 4)), "0"));

        }

        public void cargarMaterias()
        {
            MateriaBLL materia = new MateriaBLL();
            List<Materia> listMaterias;

            listMaterias = materia.cargarMaterias();

            listBoxMaterias.DataSource = listMaterias;
            listBoxMaterias.DataTextField = "nombre";
            listBoxMaterias.DataValueField = "ID_Materia";
            listBoxMaterias.DataBind();
        }
        #endregion

        public void limpiarCampos()
        {

            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtFechaNacimiento.Text = "";
            txtSemestre.Text = "";
            ddlFacultad.SelectedValue = "0";
            cargarEstados();
            cargarCiudades();
            cargarMaterias();

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