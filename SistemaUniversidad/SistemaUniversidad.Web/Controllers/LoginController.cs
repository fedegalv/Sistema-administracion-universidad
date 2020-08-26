using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SistemaUniversidad;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace SistemaUniversidad.Web.Controllers
{
    public class LoginController : Controller
    {
        SqlUserData db = new SqlUserData();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autorizar(User userModel)
        {
            if (ModelState.IsValid)
            {
                var userDetails = db.FindUser(userModel);
                if (userDetails == null)
                {
                    ViewBag.ErrorMessage = "DNI o Legajo no encontrado";
                    return View("Index");
                }
                else
                {
                    //ViewBag.ErrorMessage = "Encontrado";
                    Session["userId"] = userDetails.Id;
                    Session["userDni"] = userDetails.Dni;
                    Session["userIsAdmin"] = userDetails.EsAdmin;
                    if ((bool)Session["userIsadmin"])
                    {
                        //TempData["user"] = userDetails;
                        Session["user"] = userDetails;
                        return RedirectToAction("Index", "Administrador");
                    }
                    else if (!(bool)Session["userisAdmin"])
                    {
                        Session["user"] = userDetails;
                        return RedirectToAction("Index", "Alumno");
                    }
                }
            }
            return View(userModel);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.ErrorMessage = "Sesion cerrada";
            return RedirectToAction("Index", "Login");
        }
    }
}