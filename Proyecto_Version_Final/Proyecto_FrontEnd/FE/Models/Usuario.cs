using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class Usuario
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Contrasenna { get; set; }
        public int? IdTipoUsuario { get; set; }
    }
}
