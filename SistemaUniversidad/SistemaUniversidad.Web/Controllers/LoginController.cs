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
        // COMPRUEBA QUE EL USUARIO SEA VALIDO
        public ActionResult Autorizar(User usuarioProvisto)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.EncontrarUsuario(usuarioProvisto);
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
                    if ((bool)Session["userIsadmin"])
                    {
                        Session["user"] = usuario;
                        return RedirectToAction("Index", "Administrador");
                    }
                    else if (!(bool)Session["userisAdmin"])
                    {
                        Session["user"] = usuario;
                        SqlAlumnoData sqlAlumno = new SqlAlumnoData();
                        var alumno = sqlAlumno.Obtener(usuario.Id);
                        if (alumno == null)
                        {
                            Alumno alumnoNuevo = new Alumno
                            {
                                IdUsuario = usuario.Id,
                            };
                            sqlAlumno.Agregar(alumnoNuevo);
                        }
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