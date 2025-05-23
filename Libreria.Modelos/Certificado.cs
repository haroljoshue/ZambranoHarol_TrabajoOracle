using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Certificado
    {
        [Key]
        public int CertificadoId { get; set; }
        public string Detalles { get; set; }

        //FK    
        public int InscripcionId { get; set; }

        //Navigation Properties
        public Inscripcion? Inscripcion { get; set; }
    }
}
