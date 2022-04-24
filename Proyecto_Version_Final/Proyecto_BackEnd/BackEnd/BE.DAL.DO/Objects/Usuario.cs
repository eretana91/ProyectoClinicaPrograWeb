using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BE.DAL.DO.Objects
{
    public partial class Usuario
    {
        public Usuario()
        {
            Enfermedades = new HashSet<Enfermedades>();
            Expedientes = new HashSet<Expedientes>();
            Pagos = new HashSet<Pagos>();
        }

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contrasenna { get; set; }
        public int? IdTipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Enfermedades> Enfermedades { get; set; }
        public virtual ICollection<Expedientes> Expedientes { get; set; }
        public virtual ICollection<Pagos> Pagos { get; set; }
    }
}
