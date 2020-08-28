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
        // GET: Materia
        public ActionResult Crear()
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
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
                        SqlMateriaData sqlMateria = new SqlMateriaData();
                        sqlMateria.Agregar(materia);
                        return RedirectToAction("Materias", "Administrador");
                    }
                }
                SqlProfesorData sqlProfesor = new SqlProfesorData();
                var profesorLista = new SelectList(sqlProfesor.ObtenerTodos().ToList(), "Id", "Apellido");
                ViewData["profesorLista"] = profesorLista;
                return View("~/Views/Materia/Crear.cshtml", materia);
 
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            SqlProfesorData sqlProfesor = new SqlProfesorData();
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
                    SqlMateriaData sqlMateria = new SqlMateriaData();
                    sqlMateria.Actualizar(materia);
                    return RedirectToAction("Materias", "Administrador");
                }
            }
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            var profesorLista = new SelectList(sqlProfesor.ObtenerTodos().ToList(), "Id", "Apellido");
            ViewData["profesorLista"] = profesorLista;
            return View("~/Views/Materia/Editar.cshtml", materia);
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            Materia materia = sqlMateria.Obtener(id);
            return View("~/Views/Materia/Eliminar.cshtml", materia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(Materia materia)
        {

            if (materia != null)
            {
                SqlMateriaData sqlMateria = new SqlMateriaData();
                sqlMateria.Remover(materia.Id);
                return RedirectToAction("Materias", "Administrador");
            }

            return View(materia);
        }
        [HttpGet]
        public ActionResult Detalles(int id)
        {
            SqlMateriaData sqlMateria = new SqlMateriaData();
            Materia materia = sqlMateria.Obtener(id);
            return View("~/Views/Materia/Detalles.cshtml", materia);
        }



        [HttpGet]
        public ActionResult _mostrarProfesor(int id)
        {
            SqlProfesorData sqlProfesor = new SqlProfesorData();
            var profesor = sqlProfesor.Obtener(id);
            return PartialView(profesor);
        }
    }
}