using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Peals.Models;

namespace Peals.Controllers
{
    public class LoginController : Controller
    {
        private pealsEntities db = new pealsEntities();

        /// <summary>
        /// Crea la sesión para el usuario.
        /// </summary>
        /// <param name="modelo">objecto usuario que solicita el inicio de sesión</param>
        /// <param name="returnUrl">URL a la cual se redireccionara si el login es exitoso</param>
        /// <param name="cc">ControlerContext que solicita la sesión.</param>
        public ActionResult iniciarSesionContexto(usuario modelo, string returnUrl, ControllerContext cc)
        {
            if (ModelState.IsValid)
            {
                usuario usr = validarUsuario(modelo.mail, modelo.contrasena, cc);
                if ( usr != null)
                {
                    usuario usuario_a_recuperar = cc.HttpContext.Session["usuario_de_baja"] as usuario;
                    if (usuario_a_recuperar != null && usr.id == usuario_a_recuperar.id)
                    {
                        cc.HttpContext.Session.Remove("usuario_de_baja");

                        usr.fecha_baja = null;
                        db.ObjectStateManager.ChangeObjectState(usr, System.Data.EntityState.Modified);
                        if (db.SaveChanges() == 0)
                            ModelState.AddModelError("3", "3"); // Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.
                    }

                    if (usr.fecha_baja.HasValue)
                    {
                        cc.HttpContext.Session.Add("usuario_de_baja", usr);
                        ModelState.AddModelError("2", "2"); // El usuario ya fue dado de baja
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(modelo.mail, true); //ese true es para el rememberMe
                        cc.HttpContext.Response.Cookies.Get(0).Expires = System.DateTime.Now.AddHours(24);
                        
                        if (returnUrl == null)
                        {
                            returnUrl = "";
                        }

                        if (returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", usr.tipo_usuario1.nombre);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("1", "1"); // Los datos no son correctos. Por favor, ingresa nuevamente tus datos.
                }
            }

            // si llegamos hasta aca, algo fallo, asiq mostramos el form
            var tipoUsuario =
              from tu in db.tipo_usuario
              select tu;
            ViewData["tipo_usuario"] = new SelectList(tipoUsuario.ToList(), "nombre", "nombre");
            return View(modelo);
        }

        /// <summary>
        /// Verifica que los datos ingresados en el login sean correctos creando además, dos cookies con
        /// los siguientes datos:
        ///  - Cookie Name: idUsuario -- es el id del usuario en cuestion.
        ///  - Cookie Name: tipoUsuario -- Alumno, Docente o Administrador.  
        /// </summary>
        /// <param name="mail">mail a validar</param>
        /// <param name="contrasena">contraseña a validar</param>
        /// <param name="cc">ControllerContext que solicita la validación</param>
        /// <returns>
        /// Devuelve un objecto usuario si la validación es exitosa, de lo contrario devuelve null.
        /// </returns>
        /// <exception cref="InvalidLoginException">Lanzada si el usuario y/o contraseña son incorrectos</exception>
        public usuario validarUsuario(String mail, String contrasena, ControllerContext cc)
        {
            usuario usr = null;

            try
            {
                var usuario =
                from us in db.usuario
                from tu in db.tipo_usuario
                where us.mail == mail &&
                      us.tipo_usuario == tu.id
                select us;

                // verifico que el usuario exista en la base de datos.
                if (usuario.Count() == 0) throw new InvalidLoginException("El nombre de usuario y la contraseña no coinciden.");

                usr = usuario.First();
                // verifico que la password sea correcta.
                if (!Utiles.Password.CheckPassword(usr.contrasena, contrasena)) throw new InvalidLoginException("El nombre de usuario y la contraseña no coinciden.");

                // si todo esta bien, genero el cookie para la sesión.
                HttpCookie cookieUsuario = new HttpCookie("DatosUsuario");
                cookieUsuario["idUsuario"] = Convert.ToString(usr.id);
                cookieUsuario["tipoUsuario"] = Convert.ToString(usr.tipo_usuario1.nombre);
                cookieUsuario.Expires = System.DateTime.Now.AddHours(24);
                cc.HttpContext.Response.SetCookie(cookieUsuario);
            }
            catch (InvalidLoginException)
            {
                usr = null;
            }
            catch (Exception)
            {
                usr = null;
            }

            return usr;
        }

        /// <summary>
        /// Cierra la sesión del usuario y elimina los cookies utilizados en la misma.
        /// </summary>
        /// <returns> GET: /Account/LogOff </returns>
        public ActionResult CerrarSesion(ControllerContext cc)
        {
            if (cc.HttpContext.Request.Cookies["DatosUsuario"] != null)
            {
                // cierro la sesión
                HttpCookie cookieUsuario = cc.HttpContext.Request.Cookies["DatosUsuario"];
                cookieUsuario.Expires = DateTime.Now.AddDays(-1d);
                cc.HttpContext.Response.Cookies.Add(cookieUsuario);

                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
            
        }
    }

    /// <summary>
    /// Clase para personlizar las excepciones lanzadas en el momento del login de usuario.
    /// </summary>
    public class InvalidLoginException : System.ApplicationException
    {
        // TODO: ver bien el tema de los mensajes! 

        public InvalidLoginException() : base() { }
        public InvalidLoginException(string message) : base(message) { }
        public InvalidLoginException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidLoginException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
