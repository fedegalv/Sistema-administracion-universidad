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
        // GET: Alumno
        public ActionResult Index()
        {
            var model = Session["user"];


            return View(model);
        }
        public ActionResult Materias()
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            var listaMaterias = sqlMateria.ObtenerTodos();
            ViewData["error"] = TempData["error"];
            return View(listaMaterias.OrderBy(m => m.Nombre));
        }

        [HttpGet]
        public ActionResult Detalles(int id)
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            Materia materia = sqlMateria.Obtener(id);
            return View("~/Views/Alumno/Detalles.cshtml", materia);
        }
        [HttpGet]
        public ActionResult Anotar(int id)
        {
            SqlAlumnoData sqlAlumno = new SqlAlumnoData();
            SqlMateriaData sqlMateria = new SqlMateriaData();
            SqlUserData sqlUser = new SqlUserData();

            var usuario = sqlUser.EncontrarUsuario(((User)Session["user"]));
            var alumno = sqlAlumno.Obtener(usuario.Id);
            var materia = sqlMateria.Obtener(id);
            if (alumno != null && materia != null && usuario != null)
            {
                if (materia.CupoUtilizado < materia.CupoMaximoAlumnos)
                {
                    bool yaAnotado = alumno.ListaMaterias.Split(',').Contains(materia.Id.ToString());
                    if (yaAnotado)
                    {
                        TempData["error"] = $"Ya estas anotado a la materia {materia.Nombre}!";
                    }
                    else
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

            return PartialView(listaMaterias);
        }
    }
}