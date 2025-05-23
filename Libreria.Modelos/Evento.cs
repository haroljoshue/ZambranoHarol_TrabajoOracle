using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Libreria.Modelos
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        [Precision(10, 2)]
        public decimal Precio { get; set; }
        public string Tipo { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
        public string Modalidad { get; set; }

        //Navigation Properties
        public List<Sesion>? Sesiones { get; set; }
        public List<Inscripcion>? Inscripciones { get; set; }
        public List<EventoPonente>? EventoPonentes { get; set; }
        public List<HistorialEvento>? HistorialEventos { get; set; }
        public List<Pago>? Pagos { get; set; }

    }
}
