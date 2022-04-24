using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class TipoProducto
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
