using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaDatosFisicos
    {		
		public int Id { get; set; }
		public int TablaDatosFisicosId { get; set; }
		public string Nombre { get; set; }

		public int Peso { get; set; }

		public double Altura { get; set; }

		public string Alergias { get; set; }

		public string Grupo_sanguineo { get; set; }

		public bool Fumador { get; set; }

		public bool Drogas { get; set; }
	}

}
