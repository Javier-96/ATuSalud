using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaMedicamentos
    {
        public int Id { get; set; }
        public string Nombre_medicamento { get; set; }
        public string Forma_farmaceutica { get; set; }

        [Column("id_efectoSec")]
        public int EfectoSecId { get; set; }
        public TablaEfectos_secundarios EfectosSec { get; set; }
    }
}
