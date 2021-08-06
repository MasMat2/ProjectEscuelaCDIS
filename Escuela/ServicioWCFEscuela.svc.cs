﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Escuela_DAL;


namespace Escuela
{

    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoWCFEscuela
    {
        EscuelaEntities modelo;

        public ServicoWCFEscuela()
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
            var facultades = from mFacultade in modelo.Facultad
                             select new
                             {
                                 matricula = mFacultade.codigo,
                                 nombre = mFacultade.nombre,
                                 fechaCreacion = mFacultade.fechaCreacion,
                                 universidad = mFacultade.universidad,
                                 nombreCiudad = mFacultade.Ciudad1.nombre
                             };

            return (new JavaScriptSerializer().Serialize(facultades.AsEnumerable<object>().ToList()));
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
