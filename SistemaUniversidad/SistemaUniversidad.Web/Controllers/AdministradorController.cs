using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace SistemaUniversidad.Web.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        [HttpGet]
        public ActionResult Index()
        {
            //User model = (User)TempData["user"];
            User model = (User)Session["user"];
            return View(model);
        }

        public ActionResult Profesores()
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            var listaProfesor = sqlProfesor.ObtenerTodos();
            return View(listaProfesor);
        }
        [HttpGet]
        public ActionResult EditarProfesor(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            Profesor profesor = sqlProfesor.Obtener(id);
            return View(profesor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProfesor(Profesor profesor)
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

        public ActionResult EliminarProfesor(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            Profesor profesor = sqlProfesor.Obtener(id);
            return View(profesor);
        }
        public ActionResult DetallesProfesor(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            Profesor profesor = sqlProfesor.Obtener(id);
            return View(profesor);
        }
        [HttpGet]
        public ActionResult CrearProfesor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProfesor(Profesor profesor)
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

            return View(profesor);

        }
    }
}