using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Models
{
    [Table("assignment")]
    public class Materia
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        
        [Required]
        [Column("name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Nombre { get; set; }

        
        [Required]
        [Column("schedule")]
        public EHorario Horario { get; set; }

        //[Column("professor_id")]
        //public int IdProfesor { get; set; }
        [Column("professor_id")]
        [Required(ErrorMessage = "Se requiere un profesor")]
        public int IdProfesor { get; set; }

        [Required]
        [Column("student_max_capacity")]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un numero valido")]
        public int CupoMaximoAlumnos { get; set; }

        [Column("used_capacity")]
        [Display(Name = "Alumnos anotados")]

        public int CupoUtilizado { get; set; }


    }
}
