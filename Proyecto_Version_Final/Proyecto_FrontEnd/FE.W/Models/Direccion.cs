using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            Persona = new HashSet<Persona>();
        }

        public long CodigoDireccion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Resena { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
