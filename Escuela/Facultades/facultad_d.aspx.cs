using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;

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
            Facultad facultad = facuBLL.cargarFacultad(codigo);

            lblCodigo.Text = facultad.codigo.ToString();
            lblNombre.Text = facultad.nombre;
            lblFechaCreacion.Text = Convert.ToDateTime(facultad.fechaCreacion).ToString("dd/MM/yyyy");
            ddlUniversidad.SelectedValue = facultad.universidad.ToString();

            ddlCiudad.Items.Insert(0, new ListItem(facultad.Ciudad1.nombre));
            ddlCiudad.SelectedValue = "0";

            cargarMaterias();
            List<MateriaFacultad> listMateriaFacultad;
            listMateriaFacultad = facultad.MateriaFacultad.ToList();

            foreach (MateriaFacultad materiaFacultad in listMateriaFacultad)
            {
                listBoxMaterias.Items.FindByValue(materiaFacultad.materia.ToString()).Selected = true;
            }
            listBoxMaterias.Attributes.Add("disabled", "");
        }

        public void cargarUniversidades()
        {
            UniversidadBLL uniBLL = new UniversidadBLL();
            List<Universidad> listUniversidad;

            listUniversidad = uniBLL.cargarUniversidades();

            ddlUniversidad.DataSource = listUniversidad;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Universidad {0}", new String('-', 4)), "0"));
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

        public void eliminarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            /*move to class state*/
            string codigo = Request.QueryString["pCodigo"];
            

            try
            {
                facuBLL.eliminarFacultad(codigo);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", String.Format("alert('{0}')", ex.Message), true);
            }

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