using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace Universidad.Data.Business
{
    public class ProfesorBusiness
    {
        /// <summary>
        /// Obtiene un profesor a partir de una ID provista
        /// </summary>
        /// <param name="id">Id del profesor</param>
        public static Profesor ObtenerProfesor(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            return sqlProfesor.Obtener(id);
        }
        /// <summary>
        /// Actualiza  Profesor de la base de datos con el Profesor provisto
        /// </summary>
        /// <param name="profesor">Profesor con cambios realizados</param>
        /// <returns>True si se actualizo, false si profesor era null</returns>
        static public List<Profesor> ObtieneListaProfesor()
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            return sqlProfesor.ObtenerTodos().ToList();
        }
        public static bool ActualizarProfesor(Profesor profesor)
        {
            if (profesor != null)
            {
                SqlProfesorData sqlProfesor = new SqlProfesorData();
                sqlProfesor.Actualizar(profesor);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Elimina profesor de la base de datos
        /// </summary>
        /// <param name="profesor">Profesor a eliminar</param>
        /// <returns>True si pudo eliminar, false si profesor era null</returns>
        public static bool EliminarProfesor(Profesor profesor)
        {
            if (profesor != null)
            {
                SqlProfesorData sqlProfesor = new SqlProfesorData();
                sqlProfesor.Remover(profesor.Id);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Agrega profesor a base de datos
        /// </summary>
        /// <param name="profesor">Profesor a agregar</param>
        /// <returns>True si pudo agregar, false si profesor es null</returns>
        public static bool AgregarProfesor(Profesor profesor)
        {
            if (profesor != null)
            {
                SqlProfesorData sqlProfesor = new SqlProfesorData();
                sqlProfesor.Agregar(profesor);
                return true;
            }
            return false;
        }
    }
}
