//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Escuela_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ciudad
    {
        public Ciudad()
        {
            this.Alumno = new HashSet<Alumno>();
            this.Facultad = new HashSet<Facultad>();
        }
    
        public int ID_Ciudad { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
    
        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual Estado Estado1 { get; set; }
        public virtual ICollection<Facultad> Facultad { get; set; }
    }
}
