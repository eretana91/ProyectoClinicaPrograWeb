using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class ReporteCitas
    {
        public long CodigoreporteCitas { get; set; }
        public long? CodigoExpedienteFk { get; set; }

        public virtual Expediente CodigoExpedienteFkNavigation { get; set; }
    }
}
