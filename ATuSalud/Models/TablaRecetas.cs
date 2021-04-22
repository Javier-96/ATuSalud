﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaRecetas
    {
        public int Id { get; set; }
        public string Diagnostico { get; set; }
        public string Medicamento_generico { get; set; }
        public string Cantidad { get; set; }
        public string Dosis { get; set; }
        public string Duracion { get; set; }
        public DateTime Fecha { get; set; }

    }
}