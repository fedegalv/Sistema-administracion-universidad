using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Data.Models
{
    [Table("student")]
    public class Alumno
    {
        [Key]
        [Column("id")]
        [Display(Name = "ID")]
        public int IdAlumno { get; set; }

        [Column("user_id")]
        public int IdUsuario { get; set; }

        [Column("subject-list")]
        public string ListaMaterias { get; set; }


        public bool ObtenerMateriaDeLista(int id)
        {
            if (ListaMaterias != null)
            {
                return ListaMaterias.Split(',').Contains(id.ToString());
            }
            return false; 
            
        }
    }

    
}
