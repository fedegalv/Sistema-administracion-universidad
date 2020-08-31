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
    public class AdministradorController : Controller
    {
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
            return View(ProfesorBusiness.ObtieneListaProfesor());
        }
        [HttpGet]
        public ActionResult Materias()
        {
            return View(MateriaBusiness.ObtenerListaMaterias().OrderBy(m => m.Nombre));
        }

        public ActionResult _mostrarProfesor(int id)
        {
            return PartialView(ProfesorBusiness.ObtenerProfesor(id));
        }
    }
}