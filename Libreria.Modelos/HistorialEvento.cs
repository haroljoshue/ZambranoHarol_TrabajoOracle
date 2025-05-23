using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class HistorialEvento
    {
        [Key]
        public int HistolialEventoId { get; set; }
        public DateTime Fecha { get; set; }
        public int participantes { get; set; }
        [Precision(10, 2)]
        public decimal recaudacion { get; set; }
        public int certificados { get; set; }

        //FK
        public int EventoId { get; set; }

        //Navigation Properties
        public Evento? Evento { get; set; }
    }
}
