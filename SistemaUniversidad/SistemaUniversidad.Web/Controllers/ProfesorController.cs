using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Data.Business;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace SistemaUniversidad.Web.Controllers
{
    public class ProfesorController : Controller
    {
        [HttpGet]
        public ActionResult Editar(int id)
        {
            return View("~/Views/Profesor/Editar.cshtml", ProfesorBusiness.ObtenerProfesor(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                if (ProfesorBusiness.ActualizarProfesor(profesor))
                {
                    return RedirectToAction("Profesores", "Administrador");
                }
            }

            return View(profesor);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            return View("~/Views/Profesor/Eliminar.cshtml", ProfesorBusiness.ObtenerProfesor(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Profesor profesor)
        {

            if (ProfesorBusiness.EliminarProfesor(profesor))
            {
                return RedirectToAction("Profesores", "Administrador");
            }

            return View(profesor);
        }
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            return View("~/Views/Profesor/Detalles.cshtml", ProfesorBusiness.ObtenerProfesor(id));
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
                if (ProfesorBusiness.AgregarProfesor(profesor))
                {
                    return RedirectToAction("Profesores", "Administrador");
                }
            }

            return View("~/Views/Profesor/Crear.cshtml", profesor);

        }
    }
}