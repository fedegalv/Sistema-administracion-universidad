using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("dni")]
        [StringLength(8, ErrorMessage = "Campo DNI requiere 8 caracteres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Campo DNI debe ser numerico")]
        public string Dni { get; set; }
        
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Legajo debe ser numerico")]
        [Column("file")]
        public string Legajo { get; set; }
        [Column("is_admin")]
        public bool EsAdmin { get; set; }
    }
}
