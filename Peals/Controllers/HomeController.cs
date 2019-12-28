using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;

namespace Peals.Controllers
{
    public class HomeController : Controller
    {
        private pealsEntities db = new pealsEntities();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            if (Request.IsAuthenticated && Request.Cookies["DatosUsuario"] != null)
            {
                switch (Request.Cookies["DatosUsuario"]["tipoUsuario"])
                {
                    case "Administrador":
                        return RedirectToAction("index", "Administrador");
                    case "Docente":
                        return RedirectToAction("index", "Docente");
                    case "Alumno":
                        return RedirectToAction("index", "Alumno");
                }
            }
            else
            {
                var tipoUsuario =
                  from tu in db.tipo_usuario
                  select tu;

                ViewData["tipo_usuario"] = new SelectList(tipoUsuario.ToList(), "nombre", "nombre");
                return View();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Peals.Models.usuario modelo, string returnUrl, string tipoUsuario)
        {
            LoginController login = new LoginController();
            return login.iniciarSesionContexto(modelo, returnUrl, ControllerContext);
        }


        public ActionResult Registrar(string tipo_usuario)
        {

            switch (tipo_usuario)
            {
                case "Docente":
                    return RedirectToAction("NuevoDocente", "Docente");
                case "Administrador":
                    return RedirectToAction("NuevoAdministrador", "Administrador");
                case "Alumno":
                    return RedirectToAction("NuevoAlumno", "Alumno");
                default:
                    return null;
            }
        }
    }
}
