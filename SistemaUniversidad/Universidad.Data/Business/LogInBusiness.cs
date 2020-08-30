using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace Universidad.Data.Business
{
    public class LogInBusiness
    {
         static public User BucarUsuario(User usuarioProvisto)
        {
            SqlUserData db = new SqlUserData();
            var usuario = db.EncontrarUsuario(usuarioProvisto);
            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }
        static public void CrearAlumno(int idUsuario)
        {
            SqlAlumnoData sqlAlumno = new SqlAlumnoData();

            var alumno = sqlAlumno.Obtener(idUsuario);
            if (alumno == null)
            {
                Alumno alumnoNuevo = new Alumno
                {
                    IdUsuario = idUsuario,
                    ListaMaterias = ""
                };
                sqlAlumno.Agregar(alumnoNuevo);
            }
        }

    }
}
