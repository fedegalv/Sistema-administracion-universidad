using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Authorize(User userModel)
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
                    Session["id"] = userDetails.id;
                    Session["dni"] = userDetails.dni;
                    Session["isAdmin"] = userDetails.is_admin;
                    return RedirectToAction("Index", "Home");
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