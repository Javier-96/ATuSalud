using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaProfesional_Paciente
    {
        public int Id { get; set; }
        [Column("Id_Profesional")]
        public int ProfesionalId { get; set; }
        [Column("Id_Paciente")]
        public int PacienteId { get; set; }
    }
}
