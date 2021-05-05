using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.ViewData
{
    public class ProfesionalViewData
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int? num_colegiado { get; set; }

    }
}
