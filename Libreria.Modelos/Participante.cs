using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Participante
    {
        [Key]
        public int ParticipanteId { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Institucion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        //Navigation Properties
        public List<Inscripcion>? Inscripciones { get; set; }
        public List<Asistencia>? Asistencias { get; set; }
    }
}
