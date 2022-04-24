using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Biblioteca
    {
        public Biblioteca()
        {

        }

        public int IdVideo { get; set; }
        public string TituloVideo { get; set; }
        public string UrlVideo { get; set; }
        public string DescripcionVideo { get; set; }


    }
}
