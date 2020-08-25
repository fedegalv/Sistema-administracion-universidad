using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Models
{
    public class Profesor
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public string Dni { get; set; }
        public bool Activo { get; set; }
    }
}
