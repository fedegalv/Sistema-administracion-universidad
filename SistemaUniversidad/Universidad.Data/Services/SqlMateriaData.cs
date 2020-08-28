using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    public class SqlMateriaData : IUniversidadData<Materia>
    {
        private MateriaDbContext db;
        public SqlMateriaData()
        {
            db = new MateriaDbContext();
        }
        /// <summary>
        /// Guarda la materia en la base de datos
        /// </summary>
        /// <param name="materia"></param>
        public void Agregar(Materia materia)
        {
            db.assignment.Add(materia);
            db.SaveChanges();
        }
        /// <summary>
        /// Obtiene la materia en la base de datos, a traves de la id provista
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Materia encontrada o null</returns>
        public Materia Obtener(int id)
        {
            var materia = db.assignment.FirstOrDefault(x => x.Id == id);
            return materia;
        }

        /// <summary>
        /// Obtiene todas las materias de la base de datos
        /// </summary>
        /// <returns> IEnumerable de las materias</returns>
        public IEnumerable<Materia> ObtenerTodos()
        {
            return db.assignment;
        }
        /// <summary>
        /// Remueve la materia de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public void Remover(int id)
        {
            var materia = db.assignment.Find(id);
            var entrada = db.Entry(materia);
            entrada.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
        /// <summary>
        /// Actualiza la base de datos con la materia provista
        /// </summary>
        /// <param name="materia">Materia a actualizar</param>
        public void Actualizar(Materia materia)
        {
            var entrada = db.Entry(materia);
            entrada.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
