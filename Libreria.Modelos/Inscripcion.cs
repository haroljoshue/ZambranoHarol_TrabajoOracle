using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Inscripcion
    {
        [Key]
        public int InscripcionId { get; set; }
        public bool EstadoPago { get; set; }
        public DateTime FechaInscripcion { get; set; }

        // FK
        public int EventoId { get; set; }
        public int ParticipanteId { get; set; }

        // Navigation Properties
        public Evento? Evento { get; set; }
        public Participante? Participante { get; set; }
        public Pago? Pago { get; set; }
    }
}


