using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escuela_BLL;
using Escuela_DAL;

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
            
            Facultad facultadObject = new Facultad();
            facultadObject.codigo = txtCodigo.Text;
            facultadObject.nombre = txtNombre.Text;
            facultadObject.fechaCreacion = DateTime.ParseExact(txtFechaCreacion.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            facultadObject.universidad = int.Parse(ddlUniversidad.SelectedValue);
            facultadObject.ciudad = int.Parse(ddlCiudad.SelectedValue);

            try
            {

                MateriaFacultad materiaFacultad;
                List<MateriaFacultad> listMateriaFacultad = new List<MateriaFacultad>();

                foreach (ListItem item in listBoxMaterias.Items)
                {
                    if (item.Selected)
                    {
                        materiaFacultad = new MateriaFacultad();
                        materiaFacultad.materia = int.Parse(item.Value);
                        //obtener id de facultad
                        //materiaFacultad.facultad = int.Parse(facultad.codigo);
                        listMateriaFacultad.Add(materiaFacultad);
                    }
                }

                facuBLL.agregarFacultad(facultadObject, listMateriaFacultad);
                limpiarCampos();

                DataTable dtAlumnos = new DataTable();
                dtAlumnos = (DataTable)ViewState["tablaFacultades"];
                dtAlumnos.Rows.Add(facultadObject.codigo, facultadObject.nombre);
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
            UniversidadBLL uniBLL = new UniversidadBLL();
            List<Universidad> listUniversidad;

            listUniversidad = uniBLL.cargarUniversidades();

            ddlUniversidad.DataSource = listUniversidad;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem(String.Format("{0} Selecione Universidad {0}", new String('-', 4)), "0"));
        }

        public void cargarPaises()
        {
            PaisBLL paisBLL = new PaisBLL();
            List<Pais> listPais;

            listPais = paisBLL.cargarPaises();

            ddlPais.DataSource = listPais;
            ddlPais.DataTextField = "nombre";
            ddlPais.DataValueField = "ID_Pais";
            ddlPais.DataBind();

            ddlPais.Items.Insert(0, new ListItem(String.Format("{0} Selecione Pais {0}", new String('-', 4)), "0"));
        }
        public void cargarEstados()
        {
            EstadoBLL estadoBLL = new EstadoBLL();
            List<Estado> listEstado;

            listEstado = estadoBLL.cargarEstadosPorPais(int.Parse(ddlPais.SelectedValue));

            ddlEstado.DataSource = listEstado;
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