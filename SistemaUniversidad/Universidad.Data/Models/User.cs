using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Campo DNI requiere 8 caracteres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Campo DNI debe ser numerico")]
        public string dni { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Legajo debe ser numerico")]
        public string legajo { get; set; }
        public bool is_admin { get; set; }
    }
}
