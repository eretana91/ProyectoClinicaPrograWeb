using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BE.DAL.DO.Objects
{
    public partial class Pagos
    {
        public int IdPago { get; set; }
        public int? TipoPago { get; set; }
        public double? Monto { get; set; }
        public string Banco { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaPago { get; set; }
        public string Notas { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual TipoPago TipoPagoNavigation { get; set; }
    }
}
