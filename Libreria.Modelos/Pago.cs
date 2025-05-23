using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        [Precision(10, 2)]
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public string Estado { get; set; }
        public string ComprobantePago { get; set; }

        public int InscripcionId { get; set; }
        public int EventoId { get; set; }

        public Inscripcion? Inscripcion { get; set; }
        public Evento? Evento { get; set; }
    }
}