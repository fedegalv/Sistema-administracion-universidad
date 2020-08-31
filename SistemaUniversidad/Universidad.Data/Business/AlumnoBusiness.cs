using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace Universidad.Data.Business
{
    public class AlumnoBusiness
    {
        /// <summary>
        /// Anota el alumno a la materia provista mediante su ID provista, verifica que no se repita ni que el horario ya este ocupado
        /// </summary>
        /// <param name="id">Id de la materia</param>
        /// <param name="usuarioProvisto">Usuario de la sesion</param>
        /// <returns></returns>
        public static string AnotarAlumnoACurso(int id, User usuarioProvisto)
        {
            SqlUserData sqlUser = new SqlUserData();
            SqlAlumnoData sqlAlumno = new SqlAlumnoData();
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            SqlMateriaData sqlMateria = new SqlMateriaData();
            string mensaje = "";

            ///GUARDO EN USUARIO LA INFORMACIO DEL USUARIO GUARDADO EN SESSION
            var usuario = sqlUser.EncontrarUsuario(usuarioProvisto);
            /// A PARTIR DE LA ID DEL USUARIO BUSCO EL ALUMNO QUE COINCIDA
            var alumno = sqlAlumno.Obtener(usuario.Id);
            ///BUSCO LA MATERIA QUE COINCIDA CON LA ID RECIBIDA
            var materia = sqlMateria.Obtener(id);
            if (alumno != null && materia != null && usuario != null)
            {
                if (materia.CupoUtilizado < materia.CupoMaximoAlumnos)
                {
                    if (alumno.ListaMaterias != "")
                    {
                        /// BUSCA COINCIDENCIA DE ID DE MATERIA DENTRO DE LA LISTA MATERIAS DEL ALUMNOS, DEVUELVE TRUE SI ENCONTRO QUE LA MATERIA YA ESTABA EN LA LISTA
                        if (alumno.ListaMaterias.Split(',').Contains(materia.Id.ToString()))
                        {
                            return mensaje = $"Ya estas anotado a la materia {materia.Nombre}!";
                        }
                        else
                        {
                            ///VERIFICAR QUE NO ESTE INSCRIPTO EN OTRAS MATERIAS MISMO HORARIO
                            foreach (var item in alumno.ListaMaterias.Split(','))
                            {
                                /// SI LA MATERIA CONCIDE EN HORARIO CON ALGUNA MATERIA EN LA LISTA NO SE PUEDE ANOTAR
                                if (sqlMateria.Obtener(int.Parse(item)).Horario == materia.Horario)
                                {
                                    return mensaje = $"El horario de esta materia coincide con otra en la que estas anotado!";
                                }
                            }

                        }
                        /// SI LA MATERIA NO SE REPITE Y NO SE SUPERPONE CON OTRA, SE AGREGA UNA COMTA AL STRING
                        alumno.ListaMaterias += ",";
                    }
                    /// Y SE AGREGA LA MATERIA A LA LISTA
                    alumno.ListaMaterias = alumno.ListaMaterias + materia.Id;
                    materia.CupoUtilizado++;
                    sqlMateria.Actualizar(materia);
                    sqlAlumno.Actualizar(alumno);
                    mensaje = $"Anotado en la materia {materia.Nombre} con exito!";
                }
                else
                {
                    mensaje = $"Ya no hay cupo disponible para la materia {materia.Nombre}";
                }
            }
            else
            {
                mensaje = "ERROR no se pudo realizar la accion";
            }

            return mensaje;
        }

        /// <summary>
        /// Se busca un alumno que coincida con Id del usuario, y se obtiene una lista de materias de el
        /// </summary>
        /// <param name="id">Id del usuario de la sesion</param>
        /// <returns>Lista de materias del alumno</returns>
        public static List<Materia> ObtenerListaMateriasAlumno(int id)
        {
            SqlAlumnoData sqlAlumno = new SqlAlumnoData();
            SqlMateriaData sqlMateria = new SqlMateriaData();
            var alumno = sqlAlumno.Obtener(id);
            List<Materia> listaMaterias = new List<Materia>();
            foreach (var materia in sqlMateria.ObtenerTodos())
            {
                if (alumno.ObtenerMateriaDeLista(materia.Id))
                {
                    listaMaterias.Add(materia);
                }
            }
            return listaMaterias;
        }
        /// <summary>
        /// Devuelve lista de materias en la base de datos;
        /// </summary>
        /// <returns>Lista de materias</returns>
        
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
