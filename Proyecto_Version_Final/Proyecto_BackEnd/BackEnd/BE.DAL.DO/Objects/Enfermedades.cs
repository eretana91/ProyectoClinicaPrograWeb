using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BE.DAL.DO.Objects
{
    public partial class Enfermedades
    {
        public int IdEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public string Cedula { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
    }
}
