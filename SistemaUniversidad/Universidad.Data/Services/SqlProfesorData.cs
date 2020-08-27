using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    public class SqlProfesorData : IUniversidadData<Profesor>
    {
        private ProfesorDbContext db;
        public SqlProfesorData()
        {
            db = new ProfesorDbContext();
        }
        /// <summary>
        /// Agrega profesor a la base de datos
        /// </summary>
        /// <param name="profesor"></param>
        public void Agregar(Profesor profesor)
        {
            db.professor.Add(profesor);
            db.SaveChanges();
        }
        /// <summary>
        /// Obtiene profesor de la base de datos a traves del id provisto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Profesor si encuentra, si no null</returns>
        public Profesor Obtener(int id)
        {
            return db.professor.FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// Obtiene todas los profesores de la base de datos
        /// </summary>
        /// <returns>IEnnumerable con profesores</returns>
        public IEnumerable<Profesor> ObtenerTodos()
        {
            return db.professor;
        }
        /// <summary>
        /// Remueve profesor de la base de datos, a traves de la id provista
        /// </summary>
        /// <param name="id">id del profesor a remover</param>
        public void Remover(int id)
        {
            var profesor = db.professor.Find(id);
            var entrada = db.Entry(profesor);
            entrada.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
        /// <summary>
        /// Actualiza la base de datos con profesor provisto
        /// </summary>
        /// <param name="profesor">Profesor a actualizar</param>
        public void Actualizar(Profesor profesor)
        {
            var entrada = db.Entry(profesor);
            entrada.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
