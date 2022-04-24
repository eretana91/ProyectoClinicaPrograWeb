using System.ComponentModel.DataAnnotations;
using System;

namespace FE.Models
{
    public partial class Expedientes
    {
        public int idExpediente { get; set; }
        public string cedula { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fechaN { get; set; }
        public string ciudad { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        [DataType(DataType.MultilineText)]
        public string diagnostico { get; set; }
        [DataType(DataType.MultilineText)]
        public string antecendente { get; set; }
        [DataType(DataType.MultilineText)]
        public string mediUtilizados { get; set; }
        [DataType(DataType.MultilineText)]
        public string anteQuirurgicos { get; set; }
        [DataType(DataType.MultilineText)]
        public string fracturas { get; set; }
        [DataType(DataType.MultilineText)]
        public string anteFamiliares { get; set; }
    }
}
