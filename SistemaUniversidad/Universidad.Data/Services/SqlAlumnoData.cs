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
        public void Actualizar(Alumno alumno)
        {
            var entrada = db.Entry(alumno);
            entrada.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Agregar(Alumno alumno)
        {
            db.students.Add(alumno);
            db.SaveChanges();
        }

        public Alumno Obtener(int id)
        {
            var alumno = db.students.FirstOrDefault(x => x.IdUsuario == id);
            return alumno;
        }

        public IEnumerable<Alumno> ObtenerTodos()
        {
            return db.students;
        }

        public void Remover(int id)
        {
            var alumno = db.students.Find(id);
            var entrada = db.Entry(alumno);
            entrada.State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
