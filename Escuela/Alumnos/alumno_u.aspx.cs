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
            Alumno alumno = new Alumno();

            alumno = alumBLL.cargarAlumno(matricula);

            lblMatricula.Text = alumno.matricula.ToString();
            txtNombre.Text = alumno.nombre;
            txtFechaNacimiento.Text = alumno.fechaNacimiento.ToString("dd-MM-yyy");
            txtSemestre.Text = alumno.semestre.ToString();
            ddlFacultad.SelectedValue = alumno.facultad.ToString();

            cargarEstados();
            ddlEstado.SelectedValue = alumno.Ciudad1.ToString();

            cargarCiudades();
            ddlCiudad.SelectedValue = alumno.ciudad.ToString();

            cargarMaterias();
            List<MateriaAlumno> listMateriaAlumno;
            listMateriaAlumno = alumno.MateriaAlumno.ToList();

            foreach(MateriaAlumno materiaAlumno in listMateriaAlumno)
            {
                listBoxMaterias.Items.FindByValue(materiaAlumno.materia.ToString()).Selected = true;
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

        public void modificarAlumno()
        {
            AlumnoBLL alumBLL = new AlumnoBLL();
            Alumno alumno = new Alumno();

            alumno.matricula = int.Parse(lblMatricula.Text);
            alumno.nombre = txtNombre.Text;
            alumno.fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            alumno.semestre = int.Parse(txtSemestre.Text);
            alumno.facultad = int.Parse(ddlFacultad.SelectedValue);
            alumno.ciudad = int.Parse(ddlCiudad.SelectedValue);


            MateriaAlumno materiaAlumno;
            List<MateriaAlumno> listMaterias = new List<MateriaAlumno>();

            foreach (ListItem item in listBoxMaterias.Items)
            {
                if (item.Selected)
                {
                    materiaAlumno = new MateriaAlumno();
                    materiaAlumno.materia = int.Parse(item.Value);
                    materiaAlumno.alumno = alumno.matricula;
                    listMaterias.Add(materiaAlumno);
                }
            }


            alumBLL.modificarAlumno(alumno, listMaterias);

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