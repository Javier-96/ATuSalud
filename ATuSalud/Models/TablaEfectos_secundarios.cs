using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    [Table("TablaEfectos_secundarios")]
    public class TablaEfectos_secundarios
    {
        public int id { get; set; }
        public string nombre_efecto { get; set; }
        public string severidad { get; set; }
    }
}
