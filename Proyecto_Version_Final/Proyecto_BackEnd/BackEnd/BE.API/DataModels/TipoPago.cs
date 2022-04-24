using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class TipoPago
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
