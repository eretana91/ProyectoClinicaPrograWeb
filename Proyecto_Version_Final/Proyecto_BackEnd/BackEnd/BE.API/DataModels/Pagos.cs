using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Pagos
    {
        public Pagos()
        {
            
        }

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
