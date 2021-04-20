using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaMedicamentos
    {
        public int Id { get; set; }
        public string Nombre_medicamento { get; set; }
        public string Forma_farmaceutica { get; set; }
        public string Efectos_secundarios { get; set; }
    }
}
