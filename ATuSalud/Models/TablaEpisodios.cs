using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaEpisodios
    {
        public int Id { get; set; }

        [Column("Id_Paciente")]
        public int PacienteId { get; set; }
        public TablaPaciente Paciente { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
       
        public string Causa { get; set; }
       
        [Column("ID_CodigoCIAP")]
        public int? CodigoId { get; set; }
        public TablaCodigoCiap Codigo { get; set; }
        public string Nombre { get; set; }

        


    }
}
