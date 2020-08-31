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
    public class MateriaController : Controller
    {
        [HttpGet]

        public ActionResult Crear()
        {
            ViewData["profesorLista"] = new SelectList(ProfesorBusiness.ObtieneListaProfesor(), "Id", "Apellido");
            return View("~/Views/Materia/Crear.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Materia materia)
        {
            if (ModelState.IsValid)
            {
                if (MateriaBusiness.AgregarMateria(materia))
                {
                    return RedirectToAction("Materias", "Administrador");
                }
            }
            ViewData["profesorLista"] = new SelectList(ProfesorBusiness.ObtieneListaProfesor(), "Id", "Apellido");
            return View("~/Views/Materia/Crear.cshtml", materia);

        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewData["profesorLista"] = new SelectList(ProfesorBusiness.ObtieneListaProfesor(), "Id", "Apellido");
            return View("~/Views/Materia/Editar.cshtml", MateriaBusiness.ObtenerMateria(id));
        }

        [HttpPost]
        public ActionResult Editar(Materia materia)
        {
            if (ModelState.IsValid)
            {
                if (MateriaBusiness.ActualizarMateria(materia))
                {
                    return RedirectToAction("Materias", "Administrador");
                }
            }
            ViewData["profesorLista"] = new SelectList(ProfesorBusiness.ObtieneListaProfesor(), "Id", "Apellido");
            return View("~/Views/Materia/Editar.cshtml", materia);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            return View("~/Views/Materia/Eliminar.cshtml", MateriaBusiness.ObtenerMateria(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Materia materia)
        {

            if (MateriaBusiness.EliminarMateria(materia))
            {
                return RedirectToAction("Materias", "Administrador");
            }

            return View(materia);
        }
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            return View("~/Views/Materia/Detalles.cshtml", MateriaBusiness.ObtenerMateria(id));
        }
        [HttpGet]
        public ActionResult _mostrarProfesor(int id)
        {
            return PartialView(ProfesorBusiness.ObtenerProfesor(id));
        }
    }
}