using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Inventarios
    {
        public Inventarios()
        {
            
        }
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
