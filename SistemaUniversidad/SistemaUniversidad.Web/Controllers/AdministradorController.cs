using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad.Data.Models;

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


            return View();
        }
    }
}