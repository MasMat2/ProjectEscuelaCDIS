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
            Facultad facultad =  facuBLL.cargarFacultad(codigo);

            lblCodigo.Text = facultad.codigo.ToString();
            txtNombre.Text = facultad.nombre;
            txtFechaCreacion.Text = Convert.ToDateTime(facultad.fechaCreacion).ToString("dd-MM-yyyy");
            ddlUniversidad.SelectedValue = facultad.universidad.ToString();
            cargarPaises();
            ddlPais.SelectedValue = facultad.Ciudad1.Estado1.pais.ToString();
            cargarEstados();
            ddlEstado.SelectedValue = facultad.Ciudad1.estado.ToString();
            cargarCiudades();
            ddlCiudad.SelectedValue = facultad.ciudad.ToString();

            cargarMaterias();
            List<MateriaFacultad> listMateriaFacultad;
            listMateriaFacultad = facultad.MateriaFacultad.ToList();

            foreach (MateriaFacultad materiaFacultad in listMateriaFacultad)
            {
                listBoxMaterias.Items.FindByValue(materiaFacultad.materia.ToString()).Selected = true;
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
        
        public void modificarFacultad()
        {
            FacultadBLL facuBLL = new FacultadBLL();
            Facultad facultadObject = new Facultad();

            facultadObject.codigo = lblCodigo.Text;
            facultadObject.nombre = txtNombre.Text;
            facultadObject.fechaCreacion = DateTime.ParseExact(txtFechaCreacion.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);;
            facultadObject.universidad = int.Parse(ddlUniversidad.SelectedValue);
            facultadObject.ciudad = int.Parse(ddlCiudad.SelectedValue);

            MateriaFacultad materiaFacultad;
            List<MateriaFacultad> listMateriaFacultad = new List<MateriaFacultad>();

            foreach (ListItem item in listBoxMaterias.Items)
            {
                if (item.Selected)
                {
                    materiaFacultad = new MateriaFacultad();
                    materiaFacultad.materia = int.Parse(item.Value);
                    listMateriaFacultad.Add(materiaFacultad);
                }
            }


            facuBLL.modificarFacultad(facultadObject, listMateriaFacultad);
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