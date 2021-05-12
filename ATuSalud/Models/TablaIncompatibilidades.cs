using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaIncompatibilidades
    {
        public int Id { get; set; }

        [Column("id_medicamento")]
        public int? MedicamentoID { get; set; }
        public TablaMedicamentos Medicamento { get; set; }
        
        [Column("id_medicamento_incompatible")]
        public int? MedicamentoIncompatibleID { get; set; }
        public TablaMedicamentos MedicamentoIncompatible{ get; set; }
    }
}
