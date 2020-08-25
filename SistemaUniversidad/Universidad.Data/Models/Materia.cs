using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Models
{
    public class Materia
    {
        public string Nombre { get; set; }
        public EHorario Horario { get; set; }
        public int IdProfesor { get; set; }
        public int CupoMaximoAlumnos { get; set; }


    }
}
