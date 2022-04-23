using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Citas
    {
        public Citas()
        {
            CitasProgramadas = new HashSet<CitasProgramadas>();
        }

        public long CodigoCitas { get; set; }
        public string Asunto { get; set; }
        public string Descripsion { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? Horafin { get; set; }
        public string TemaColor { get; set; }
        public bool? EsTodoElDia { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<CitasProgramadas> CitasProgramadas { get; set; }
    }
}
