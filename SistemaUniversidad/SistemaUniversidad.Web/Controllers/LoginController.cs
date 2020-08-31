using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SistemaUniversidad;
using Universidad.Data.Business;
using Universidad.Data.Models;
using Universidad.Data.Services;

namespace SistemaUniversidad.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // COMPRUEBA QUE EL USUARIO SEA VALIDO
        public ActionResult Autorizar(User usuarioProvisto)
        {
            if (ModelState.IsValid)
            {
                var usuario = LogInBusiness.BucarUsuario(usuarioProvisto);
                if (usuario == null)
                {
                    ViewBag.ErrorMessage = "DNI o Legajo no encontrado";
                    return View("Index");
                }
                else
                {
                    Session["userId"] = usuario.Id;
                    Session["userDni"] = usuario.Dni;
                    Session["userIsAdmin"] = usuario.EsAdmin;
                    //SI EL USUARIO ES ADMINISTRADOR REDIRIGE A SU SECCION CORRESPONDIENTE
                    if ((bool)Session["userIsadmin"])
                    {
                        Session["user"] = usuario;
                        return RedirectToAction("Index", "Administrador");
                    }
                    else if (!(bool)Session["userisAdmin"])
                    {
                        // SI NO ES ADMINISTRADOR, SE CREA UN ALUMNO NUEVO SI CORRESPONDE
                        Session["user"] = usuario;
                        AlumnoBusiness.CrearAlumno(usuario.Id);
                        return RedirectToAction("Index", "Alumno");
                    }
                }
            }
            return View(usuarioProvisto);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.ErrorMessage = "Sesion cerrada";
            return RedirectToAction("Index", "Login");
        }
    }
}