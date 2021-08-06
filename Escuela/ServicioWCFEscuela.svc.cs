using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Escuela_DAL;
using System.Data.Objects.SqlClient;

namespace Escuela
{

    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicioWCFEscuela
    {
        EscuelaEntities modelo;

        public ServicioWCFEscuela()
        {
            modelo = new EscuelaEntities();
        }
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "/consultaAlumnosJSON")]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string consultaAlumnosJSON()
        {
            var alumnos = from mAlumno in modelo.Alumno
                          select new
                          {
                              matricula = mAlumno.matricula,
                              nombre = mAlumno.nombre,
                              fechaNacimiento = mAlumno.fechaNacimiento,
                              semestre = mAlumno.semestre,
                              nombreFacultad = mAlumno.Facultad1.nombre,
                              nombreCiudad = mAlumno.Ciudad1.nombre
                          };

            return (new JavaScriptSerializer().Serialize(alumnos.AsEnumerable<object>().ToList()));
        }

        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        public string consultaFacultadesJSON()
        {
            var alumnos = from mFacultad in modelo.Facultad
                          select new
                          {
                              codigo = mFacultad.codigo,
                              nombre = mFacultad.nombre,
                              fechaCreacion = SqlFunctions.DateName("day", mFacultad.fechaCreacion) + "/" + SqlFunctions.StringConvert((double)SqlFunctions.DatePart("mm", mFacultad.fechaCreacion)).Trim() + "/" + SqlFunctions.DateName("year", mFacultad.fechaCreacion),
                              nombreUniversidad = mFacultad.Universidad1.nombre,
                              nombreCiudad = mFacultad.Ciudad1.nombre
                          };

            return (new JavaScriptSerializer().Serialize(alumnos.AsEnumerable<object>().ToList()));
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
