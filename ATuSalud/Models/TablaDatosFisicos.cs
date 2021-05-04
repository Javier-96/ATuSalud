using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
	[Table("TablaDatosFisico")]
    public class TablaDatosFisicos
    {		
		public int Id { get; set; }
		
		//public string Nombre { get; set; }

		[Column("Id_Paciente")]
		public int? PacienteId { get; set; }
		public TablaPaciente Paciente { get; set; }

		public int Peso { get; set; }

		public int Altura { get; set; }

		public string Alergias { get; set; }

		public string Grupo_sanguineo { get; set; }

		public bool Fumador { get; set; }

		public bool Drogas { get; set; }

	}

}
