using System.ComponentModel.DataAnnotations;
using System;

namespace FE.Models
{
    public partial class Inventario
    {
        public int? idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string codigoBarras { get; set; }
        public string precio { get; set; }
        public int? cantidad { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fechaExpiracion { get; set; }
        public string notas { get; set; }
        //public int? tipoProducto { get; set; }
    }
}
