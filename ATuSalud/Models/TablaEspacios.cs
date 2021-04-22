using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATuSalud.Models
{
    public class TablaEspacios
    {
        public int Id { get; set; }

        [Column("Id_Reserva")]
        public int ReservaID { get; set; }
        public TablaReservaEspacios Reserva { get; set; }
        public string EspacioGeneral { get; set; }
        public string Mobiliario { get; set; }
    }
}
