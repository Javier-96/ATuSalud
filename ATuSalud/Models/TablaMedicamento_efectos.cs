using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaMedicamento_efectos
    {
        public int? id { get; set; }
        [Column("id_medicamento")]
        public int MedicamentoId { get; set; }
        public TablaMedicamentos Medicamento { get; set; }
        [Column("id_efectoSec")]
        public int EfectoId { get; set; }
        public TablaEfectos_secundarios Efecto { get; set; }
    }
}
