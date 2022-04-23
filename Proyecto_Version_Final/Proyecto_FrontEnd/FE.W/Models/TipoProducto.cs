using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            Inventarios = new HashSet<Inventarios>();
        }

        public int TipoProducto1 { get; set; }
        public string NombreTipoProducto { get; set; }

        public virtual ICollection<Inventarios> Inventarios { get; set; }
    }
}
