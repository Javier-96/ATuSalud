using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaPaciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime Fecha_de_nacimiento { get; set; }
        public bool Seguro_privado { get; set; }
        public string DNI { get; set; }
        public string Direccion_postal { get; set; }
        public int telefono_fijo { get; set; }
        public int telefono_movil_1 { get; set; }
        public int telefono_movil_2 { get; set; }
        public string Sexo { get; set; }
    }
}
