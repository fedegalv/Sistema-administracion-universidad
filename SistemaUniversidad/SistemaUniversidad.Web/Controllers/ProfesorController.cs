using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace SistemaUniversidad.Web.Controllers
{
    public class ProfesorController : Controller
    {
        private SqlProfesorData sqlProfesor;
        public ProfesorController()
        {
            sqlProfesor = new SqlProfesorData();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Profesor profesor = sqlProfesor.Obtener(id);
            return View("~/Views/Profesor/Editar.cshtml", profesor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                if (profesor != null)
                {
                    sqlProfesor.Actualizar(profesor);
                    return RedirectToAction("Profesores", "Administrador");
                }
            }

            return View(profesor);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Profesor profesor = sqlProfesor.Obtener(id);
            return View("~/Views/Profesor/Eliminar.cshtml", profesor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Profesor profesor)
        {

            if (profesor != null)
            {
                sqlProfesor.Remover(profesor.Id);
                return RedirectToAction("Profesores", "Administrador");
            }

            return View(profesor);
        }
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            Profesor profesor = sqlProfesor.Obtener(id);
            return View("~/Views/Profesor/Detalles.cshtml", profesor);
        }
        [HttpGet]
        public ActionResult Crear()
        {
            return View("~/Views/Profesor/Crear.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                if (profesor != null)
                {
                    sqlProfesor.Agregar(profesor);
                    return RedirectToAction("Profesores", "Administrador");
                }
            }

            return View("~/Views/Profesor/Crear.cshtml", profesor);

        }
    }
}