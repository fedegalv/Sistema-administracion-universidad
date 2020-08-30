using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace SistemaUniversidad.Web.Controllers
{
    public class AlumnoController : Controller
    {
        private SqlMateriaData sqlMateria;
        SqlAlumnoData sqlAlumno;
        SqlUserData sqlUser;
        public AlumnoController()
        {
            sqlAlumno = new SqlAlumnoData();
            sqlMateria = new SqlMateriaData();
            sqlUser = new SqlUserData();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = Session["user"];
            return View(model);
        }
        [HttpGet]
        /// Devuelve como modelo lista de materias ordenadas, para mostrar en el View
        public ActionResult Materias()
        {
            var listaMaterias = sqlMateria.ObtenerTodos();
            ViewData["error"] = TempData["error"];
            return View(listaMaterias.OrderBy(m => m.Nombre));
        }

        [HttpGet]
        public ActionResult Detalles(int id)
        {
            Materia materia = sqlMateria.Obtener(id);
            return View("~/Views/Alumno/Detalles.cshtml", materia);
        }
        [HttpGet]
        /// RECIBE UNA ID DE LA MATERIA
        public ActionResult Anotar(int id)
        {
            //GUARDO EN USUARIO LA INFORMACIO DEL USUARIO GUARDADO EN SESSION
            var usuario = sqlUser.EncontrarUsuario(((User)Session["user"]));
            /// A PARTIR DE LA ID DEL USUARIO BUSCO EL ALUMNO QUE COINCIDA
            var alumno = sqlAlumno.Obtener(usuario.Id);
            ///BUSCO LA MATERIA QUE COINCIDA CON LA ID RECIBIDA
            var materia = sqlMateria.Obtener(id);
            if (alumno != null && materia != null && usuario != null)
            {
                if (materia.CupoUtilizado < materia.CupoMaximoAlumnos)
                {
                    /// BUSCA COINCIDENCIA DE ID DE MATERIA DENTRO DE LA LISTA MATERIAS DEL ALUMNOS
                    bool yaAnotado = alumno.ListaMaterias.Split(',').Contains(materia.Id.ToString());
                    bool horarioYaOcupado = false;
                    if (yaAnotado)
                    {
                        TempData["error"] = $"Ya estas anotado a la materia {materia.Nombre}!";
                    }
                    else
                    {
                        //VERIFICAR QUE NO ESTE INSCRIPTO EN OTRAS MATERIAS MISMO HORARIO
                        List<Materia> listaMateriasAnotado = new List<Materia>();
                        foreach (var item in alumno.ListaMaterias.Split(','))
                        {
                            listaMateriasAnotado.Add(sqlMateria.Obtener(int.Parse(item)));
                        }
                        foreach (var item in listaMateriasAnotado)
                        {
                            if (item.Horario == materia.Horario)
                            {
                                TempData["error"] = $"El horario de esta materia coincide con otra en la que estas anotado!";
                                horarioYaOcupado = true;
                            }
                        }
                        if (!horarioYaOcupado)
                        {
                            if (alumno.ListaMaterias == null)
                            {
                                alumno.ListaMaterias = alumno.ListaMaterias + materia.Id;
                            }
                            else
                            {
                                alumno.ListaMaterias += ",";
                                alumno.ListaMaterias += materia.Id.ToString();
                            }
                            materia.CupoUtilizado++;
                            sqlMateria.Actualizar(materia);
                            sqlAlumno.Actualizar(alumno);
                        }
                    }
                }
                else
                {
                    TempData["error"] = $"Ya no hay cupo disponible para la materia {materia.Nombre}";
                }
            }
            else
            {
                TempData["error"] = "ERROR no se pudo realizar la accion";
            }
            return RedirectToAction("Materias", "Alumno");
        }

        [HttpGet]
        /// SE PODRIA GUARDA LA LISTA EN UN VIEWDATA PARA NO TENER QUE PEDIR CONSTANTEMENTE A LA BASE DE DATOS, Y HACERLO UNA VEZ?
        public ActionResult _mostrarMateriasAlumnos(int id)
        {
            var alumno = sqlAlumno.Obtener(id);
            List<Materia> listaMaterias = new List<Materia>();
            foreach (var materia in sqlMateria.ObtenerTodos())
            {
                if (alumno.ObtenerMateriaDeLista(materia.Id))
                {
                    listaMaterias.Add(materia);
                }
            }

            return PartialView(listaMaterias.OrderBy(m => m.Nombre));
        }
    }
}