using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Expedientes
    {
        public int IdExpediente { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaN { get; set; }
        public string Ciudad { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Diagnostico { get; set; }
        public string Antecendente { get; set; }
        public string MediUtilizados { get; set; }
        public string AnteQuirurgicos { get; set; }
        public string Fracturas { get; set; }
        public string AnteFamiliares { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
    }
}
