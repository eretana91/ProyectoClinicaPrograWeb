using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            Pagos = new HashSet<Pagos>();
        }

        public int TipoPago1 { get; set; }
        public string NombrePago { get; set; }

        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}
