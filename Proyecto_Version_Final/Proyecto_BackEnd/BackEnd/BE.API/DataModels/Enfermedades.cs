using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Enfermedades
    {
        public Enfermedades()
        {
            
        }
        public int IdEnfermedad { get; set; }
        public string NombreEnfermedad { get; set; }
        public string Cedula { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }


    }
}
