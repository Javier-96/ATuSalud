using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaReservaEspacios
    {
        public int Id { get; set; }
        [Column("Id_Profesional")]
        public int ProfesionalId { get; set; }
        public TablaProfesional Profesional { get; set; }
        public string Espacio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
