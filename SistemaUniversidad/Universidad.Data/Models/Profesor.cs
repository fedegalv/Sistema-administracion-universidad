using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Models
{
    [Table("professor")]
    public class Profesor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Nombre { get; set; }
        [Column("last_name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Debe usar letras unicamente")]
        public string Apellido { get; set; }
        [Column("dni")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Campo DNI debe ser numerico")]
        public string Dni { get; set; }
        [Column("is_active")]
        public bool Activo { get; set; }
    }
}
