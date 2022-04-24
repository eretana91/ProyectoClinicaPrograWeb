using System;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class Pagos
    {
        public int? idPago { get; set; }
        public int? monto { get; set; }
        public string banco { get; set; }
        public string cedula { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fechaPago { get; set; }
        [DataType(DataType.MultilineText)]
        public string notas { get; set; }
        public int? tipoPago { get; set; }
    }
}
