using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.API.DataModels
{
    public class Expedientes
    {
        public Expedientes()
        {
            
        }

        public int IdExpediente { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaN { get; set; }
        public string Ciudad { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Diagnostico { get; set; }
        public string Antecendente { get; set; }
        public string MediUtilizados { get; set; }
        public string AnteQuirurgicos { get; set; }
        public string Fracturas { get; set; }
        public string AnteFamiliares { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }


    }
}
