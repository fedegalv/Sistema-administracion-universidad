using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    public class SqlAlumnoData : IUniversidadData<Alumno>
    {
        private AlumnoDbContext db;
        public SqlAlumnoData()
        {
            db = new AlumnoDbContext();
        }
        /// <summary>
        /// Actualiza la base de datos con el alumno
        /// </summary>
        /// <param name="alumno"></param>
        public void Actualizar(Alumno alumno)
        {
            var entrada = db.Entry(alumno);
            entrada.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        /// <summary>
        /// Agrega el alumno al base de datos
        /// </summary>
        /// <param name="alumno"></param>
        public void Agregar(Alumno alumno)
        {
            db.students.Add(alumno);
            db.SaveChanges();
        }
        /// <summary>
        /// Busca el alumno que corresponda con la id del usuario provista.
        /// </summary>
        /// <param name="id">Id del usuario a buscar en alumnos</param>
        /// <returns>Alumno que su campo IdUsuario coincida con la id de usuario correspondiete</returns>
        public Alumno Obtener(int id)
        {
            var alumno = db.students.FirstOrDefault(x => x.IdUsuario == id);
            return alumno;
        }
        /// <summary>
        /// Obtiene todos los alumnos de la base de datos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Alumno> ObtenerTodos()
        {
            return db.students;
        }
        /// <summary>
        /// Elimina alumno de la base de datos
        /// </summary>
        /// <param name="id">Id del alumno a eliminar</param>
        public void Remover(int id)
        {
            var alumno = db.students.Find(id);
            var entrada = db.Entry(alumno);
            entrada.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
