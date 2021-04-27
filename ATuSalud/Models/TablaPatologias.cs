using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaPatologias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Id_paciente { get; set; }
        public int TablaCodigoCIAPId { get; set; }
    }
}
