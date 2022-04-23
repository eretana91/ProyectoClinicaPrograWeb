using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Inventarios
    {
        public int IdProducto { get; set; }
        public int? TipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarras { get; set; }
        public string Precio { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string Notas { get; set; }

        public virtual TipoProducto TipoProductoNavigation { get; set; }
    }
}
