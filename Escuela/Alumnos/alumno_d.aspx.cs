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

namespace Escuela.Alumnos
{
    public partial class alumno_d : TemaEscuela, IAcceso
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarAlumno();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Alumno eliminado exitosamente.')", true);
        }
        #endregion

        #region Methods
        public void cargarAlumno(int matricula)
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();

            alumno = alumBLL.cargarAlumno(matricula);

            lblMatricula.Text = alumno.matricula.ToString();
            lblNombre.Text = alumno.nombre.ToString();
            lblFechaNacimiento.Text = alumno.fechaNacimiento.ToString().Substring(0, 10);
            lblSemestre.Text = alumno.semestre.ToString();
            ddlFacultad.SelectedValue = alumno.facultad.ToString();

            cargarMaterias();
            List<MateriaAlumno> listMateriaAlumno;
            listMateriaAlumno = alumno.MateriaAlumno.ToList();

            foreach (MateriaAlumno materiaAlumno in listMateriaAlumno)
            {
                listBoxMaterias.Items.FindByValue(materiaAlumno.materia.ToString()).Selected = true;
            }
            listBoxMaterias.Attributes.Add("disabled", "");
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

        public void eliminarAlumno()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            int matricula = int.Parse(lblMatricula.Text);

            alumBLL.eliminarAlumno(matricula);
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