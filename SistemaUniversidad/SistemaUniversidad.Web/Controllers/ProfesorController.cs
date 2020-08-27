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
        // GET: Profesor

        [HttpGet]
        public ActionResult Editar(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
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
                    SqlProfesorData sqlProfesor = new SqlProfesorData();
                    sqlProfesor.Actualizar(profesor);
                    return RedirectToAction("Profesores", "Administrador");
                }
            }

            return View(profesor);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            Profesor profesor = sqlProfesor.Obtener(id);
            return View("~/Views/Profesor/Eliminar.cshtml", profesor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Profesor profesor)
        {

            if (profesor != null)
            {
                SqlProfesorData sqlProfesor = new SqlProfesorData();
                sqlProfesor.Remover(profesor.Id);
                return RedirectToAction("Profesores", "Administrador");
            }

            return View(profesor);
        }
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
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
                    SqlProfesorData sqlProfesor = new SqlProfesorData();
                    sqlProfesor.Agregar(profesor);
                    return RedirectToAction("Profesores", "Administrador");
                }
            }

            return View("~/Views/Profesor/Crear.cshtml", profesor);

        }
    }
}