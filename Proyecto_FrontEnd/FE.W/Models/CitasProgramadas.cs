using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class CitasProgramadas
    {
        public CitasProgramadas()
        {
            Expediente = new HashSet<Expediente>();
        }

        public long CodigoCitaProgramadas { get; set; }
        public long CodigoCitasFk { get; set; }
        public long CodigoPacienteFk { get; set; }
        public long CodigoDoctorFk { get; set; }
        public string Padecimiento { get; set; }
        public string Tratamiento { get; set; }
        public bool? Estado { get; set; }

        public virtual Citas CodigoCitasFkNavigation { get; set; }
        public virtual Doctor CodigoDoctorFkNavigation { get; set; }
        public virtual Paciente CodigoPacienteFkNavigation { get; set; }
        public virtual ICollection<Expediente> Expediente { get; set; }
    }
}
