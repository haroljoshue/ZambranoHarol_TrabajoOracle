using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class EventoPonente
    {
        [Key]
        public int EventoPonenteId { get; set; }

        //FK
        public int EventoId { get; set; }
        public int PonenteId { get; set; }

        //Navigation Properties
        public Ponente? Ponente { get; set; }
        public Evento? Evento { get; set; }
    }
}
