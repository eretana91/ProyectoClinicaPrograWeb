using System.ComponentModel.DataAnnotations;
using System;

namespace FE.Models
{
    public partial class Enfermedades
    {
        public int idEnfermedad { get; set; }
        public string cedula { get; set; }
        public string nombreEnfermedad { get; set; }
 
    }
}
