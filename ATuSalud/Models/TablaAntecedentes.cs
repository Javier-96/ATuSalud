﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaAntecedentes
    {
        public int Id { get; set; }

        [Column("Id_Paciente")]
        public int PacienteId { get; set; }
        public TablaPaciente Paciente { get; set; }
        public string Familiar { get; set; }
        public string Enfermedad { get; set; }
    }
}
