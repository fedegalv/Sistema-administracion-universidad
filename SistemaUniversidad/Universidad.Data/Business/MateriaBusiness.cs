using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace Universidad.Data.Business
{
    public class MateriaBusiness
    {
        /// <summary>
        /// Obtiene lista de Profesor
        /// </summary>
        /// <returns>List de Profesor</returns>
        
        /// <summary>
        /// Agrega materia a la base datos
        /// </summary>
        /// <param name="materia"> Materia a agregar</param>
        /// <returns>True si agrego , false si materia era null</returns>
        static public bool AgregarMateria(Materia materia)
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            if (materia != null)
            {
                sqlMateria.Agregar(materia);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Obtiene materia de la base de datos de acuerdo a la id provista
        /// </summary>
        /// <param name="id">Id de la materia</param>
        /// <returns>Materia encontrada, sino null</returns>
        static public Materia ObtenerMateria(int id)
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            return  sqlMateria.Obtener(id);
        }
        /// <summary>
        /// Actualiza la materia con la nueva informacion en base de datos
        /// </summary>
        /// <param name="materia">Materia editada</param>
        /// <returns>True si se actualizo, false si materia es null</returns>
        static public bool ActualizarMateria(Materia materia)
        {
            if (materia != null)
            {
                SqlMateriaData sqlMateria = new SqlMateriaData();
                sqlMateria.Actualizar(materia);
                return true;
            }
            return false;
        }

        static public bool EliminarMateria(Materia materia)
        {
            if (materia != null)
            {
                SqlMateriaData sqlMateria = new SqlMateriaData();
                sqlMateria.Remover(materia.Id);
                return true;
            }
            return false;
        }
        public static IEnumerable<Materia> ObtenerListaMaterias()
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            return sqlMateria.ObtenerTodos();
        }
        /// <summary>
        /// Devuelve materia correspondiente al Id provisto
        /// </summary>
        /// <param name="id">Id de la materia</param>
        /// <returns>Materia si encontro, o null</returns>
      
    }
}
