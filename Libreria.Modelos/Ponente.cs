using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Ponente
    {
        [Key]
        public int PonenteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Institucion { get; set; }
        public string Correo { get; set; }
        public string Especialidad{ get; set; }

        //Navigation Properties
        public List<EventoPonente>? EventoPonentes { get; set; }

    }
}
