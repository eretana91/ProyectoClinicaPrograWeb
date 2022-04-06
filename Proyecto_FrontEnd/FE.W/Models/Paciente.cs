using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            CitasProgramadas = new HashSet<CitasProgramadas>();
        }

        public long CodigoPaciente { get; set; }
        public long? CodigoPersonaFk { get; set; }
        public bool? Estado { get; set; }

        public virtual Persona CodigoPersonaFkNavigation { get; set; }
        public virtual ICollection<CitasProgramadas> CitasProgramadas { get; set; }
    }
}
