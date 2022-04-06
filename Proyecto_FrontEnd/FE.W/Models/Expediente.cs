using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Expediente
    {
        public Expediente()
        {
            ReporteCitas = new HashSet<ReporteCitas>();
        }

        public long CodigoExpediente { get; set; }
        public long? CodigoCitaProgramadasFk { get; set; }

        public virtual CitasProgramadas CodigoCitaProgramadasFkNavigation { get; set; }
        public virtual ICollection<ReporteCitas> ReporteCitas { get; set; }
    }
}
