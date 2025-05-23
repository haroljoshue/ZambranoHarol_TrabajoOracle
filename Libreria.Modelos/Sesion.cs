using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Sesion
    {
        [Key]
        public int SesionId { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        //FK
        public int EventoId { get; set; }
        public int SalaId { get; set; }

        //Navigation Properties
        public Evento? Evento { get; set; }
        public Sala? Sala { get; set; }
        public List<Asistencia>? Asistencias { get; set; }
      
    }
}
