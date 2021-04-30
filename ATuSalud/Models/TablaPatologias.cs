using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaPatologias
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        [Column("Id_Paciente")]
        public int? PacienteID { get; set; }
        public TablaPaciente Paciente { get; set; }


        public int? TablaCodigoCIAPId  { get; set; }
        public TablaCodigoCiap TablaCodigoCIAP { get; set; }

    }
}
