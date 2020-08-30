using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Data.Business;
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
            // ANOTA ALUMNO AL A METERIA ENVIANDO EL ID DE LA MISMA, ACTUALIZA LAS BD O NO RESPECTIVAMENTE
            string mensajeError = AlumnoBusiness.AnotarAlumnoACurso(id, (User)Session["user"]);
            if (mensajeError != "")
            {
                TempData["error"] = mensajeError;
            }
            return RedirectToAction("Materias", "Alumno");
        }

        [HttpGet]
        /// RECIBE LA ID DEL 
        public ActionResult _mostrarMateriasAlumnos(int id)
        {
            List<Materia> listaMaterias = AlumnoBusiness.ObtenerListaMateriasAlumno(id);
            if (listaMaterias.Count > 0)
            {
                return PartialView(listaMaterias.OrderBy(m => m.Nombre));
            }
            return null;
        }
    }
}