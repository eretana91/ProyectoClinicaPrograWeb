using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Biblioteca
    {
        public int IdVideo { get; set; }
        public string TituloVideo { get; set; }
        public string UrlVideo { get; set; }
        public string DescripcionVideo { get; set; }
    }
}
