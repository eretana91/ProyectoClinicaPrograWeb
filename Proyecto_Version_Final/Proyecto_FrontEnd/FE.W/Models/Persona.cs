using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Doctor = new HashSet<Doctor>();
            Paciente = new HashSet<Paciente>();
            Usuarios = new HashSet<Usuarios>();
        }

        public long CodigoPersona { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public long? CodigoDireccionFk { get; set; }
        public bool? Estado { get; set; }
        public string Sexo { get; set; }
        public int? Edad { get; set; }

        public virtual Direccion CodigoDireccionFkNavigation { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Paciente> Paciente { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
