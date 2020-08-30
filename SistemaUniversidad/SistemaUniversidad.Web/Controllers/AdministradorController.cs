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
        private SqlProfesorData sqlProfesor;
        SqlMateriaData sqlMateria;
        public AdministradorController()
        {
            sqlProfesor = new SqlProfesorData();
            sqlMateria = new SqlMateriaData();
        }
        // GET: Administrador
        [HttpGet]
        public ActionResult Index()
        {
            User model = (User)Session["user"];
            return View(model);
        }
        [HttpGet]
        public ActionResult Profesores()
        {
            var listaProfesor = sqlProfesor.ObtenerTodos();
            return View(listaProfesor);
        }
        [HttpGet]
        public ActionResult Materias()
        {
            var listaMaterias = sqlMateria.ObtenerTodos();
            return View(listaMaterias);
        }

        public ActionResult _mostrarProfesor(int id)
        {
            Profesor profesor = sqlProfesor.Obtener(id);
            return PartialView(profesor);
        }
    }
}