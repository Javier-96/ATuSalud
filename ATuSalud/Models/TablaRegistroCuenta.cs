using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaRegistroCuenta
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string emailAddress { get; set; }
        public int telefono { get; set; }
        public string Especialidad { get; set; }
        public string primeraPassword { get; set; }
        public string segundaPassword { get; set; }
    }
}
