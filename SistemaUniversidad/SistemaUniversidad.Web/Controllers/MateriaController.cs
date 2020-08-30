using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace SistemaUniversidad.Web.Controllers
{
    public class MateriaController : Controller
    {
        private SqlProfesorData sqlProfesor;
        private SqlMateriaData sqlMateria;
        public MateriaController()
        {
            sqlProfesor = new SqlProfesorData();
            sqlMateria = new SqlMateriaData();
        }
        // GET: Materia
        public ActionResult Crear()
        {
            var profesorLista = new SelectList(sqlProfesor.ObtenerTodos().ToList(), "Id", "Apellido");
            ViewData["profesorLista"] = profesorLista;
            return View("~/Views/Materia/Crear.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Materia materia)
        {

            if (ModelState.IsValid)
            {
                if (materia != null)
                {
                    sqlMateria.Agregar(materia);
                    return RedirectToAction("Materias", "Administrador");
                }
            }
            var profesorLista = new SelectList(sqlProfesor.ObtenerTodos().ToList(), "Id", "Apellido");
            ViewData["profesorLista"] = profesorLista;
            return View("~/Views/Materia/Crear.cshtml", materia);

        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var profesorLista = new SelectList(sqlProfesor.ObtenerTodos().ToList(), "Id", "Apellido");
            ViewData["profesorLista"] = profesorLista;
            Materia materia = sqlMateria.Obtener(id);
            return View("~/Views/Materia/Editar.cshtml", materia);
        }

        [HttpPost]
        public ActionResult Editar(Materia materia)
        {
            if (ModelState.IsValid)
            {
                if (materia != null)
                {
                    sqlMateria.Actualizar(materia);
                    return RedirectToAction("Materias", "Administrador");
                }
            }
            var profesorLista = new SelectList(sqlProfesor.ObtenerTodos().ToList(), "Id", "Apellido");
            ViewData["profesorLista"] = profesorLista;
            return View("~/Views/Materia/Editar.cshtml", materia);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Materia materia = sqlMateria.Obtener(id);
            return View("~/Views/Materia/Eliminar.cshtml", materia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Materia materia)
        {

            if (materia != null)
            {
                sqlMateria.Remover(materia.Id);
                return RedirectToAction("Materias", "Administrador");
            }

            return View(materia);
        }
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            Materia materia = sqlMateria.Obtener(id);
            return View("~/Views/Materia/Detalles.cshtml", materia);
        }



        [HttpGet]
        public ActionResult _mostrarProfesor(int id)
        {
            var profesor = sqlProfesor.Obtener(id);
            return PartialView(profesor);
        }
    }
}