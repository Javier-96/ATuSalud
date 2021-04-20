﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaCitasPaciente
    {
		public int Id { get; set; }
		public int TablaPacienteId { get; set; }
		public int TablaProfesionalId { get; set; }
		public DateTime	Fecha_atencion{ get; set; }
		public DateTime Fecha_acabar { get; set; }
		public string Observaciones { get; set; }
		public DateTime Fecha_registro { get; set; }

	}
}
