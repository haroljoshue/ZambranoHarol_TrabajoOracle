using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Asistencia
    {
        [Key]
        public int AsistenciaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        // FK
        public int ParticipanteId { get; set; }
        public int SesionId { get; set; }

        // Navigation Properties
        public Participante? Participante { get; set; }
        public Sesion? Sesion { get; set; }
    }
}

