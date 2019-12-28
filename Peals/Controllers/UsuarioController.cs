using System;
using System.Linq;
using System.Web.Mvc;
using Peals.Models;
using System.Data;

namespace Peals.Controllers
{
    public class UsuarioController : Controller
    {
        protected pealsEntities mDb = new pealsEntities();
        
        protected DomicilioController mDomicilioController = new DomicilioController();
        protected CursoController mCursoController = new CursoController();
        protected InstitucionController mInstitucionController = new InstitucionController();
        protected ActividadController mActividadController = new ActividadController();
        protected RecursoController mRecursoController = new RecursoController();

        #region VIEWS

        /// <summary>
        /// Prepara la vista para creación de un nuevo usuario.
        /// </summary>
        /// <returns>PartialView: /Usuario/NuevoUsuario</returns>
        public ActionResult NuevoUsuario()
        {
            // obtengo los países para cargarlos en un comboBox
            var paises =
                from p in mDb.pais
                select p;

            // agrego los países al diccionario de datos para poder usuarlos en la vista.
            ViewData["pais"] = new SelectList(paises.ToList(), "id", "nombre");
            ViewData["provincia"] = new SelectList(new[] { "" });
            ViewData["localidad"] = new SelectList(new[] { "" });

            return PartialView();
        }

        /// <summary>
        /// Prepara la vista para la edición de un usuario.
        /// </summary>
        /// <returns>PartialView: /Usuario/EditarUsuario</returns>
        public ActionResult EditarUsuario()
        {
            // recupero el usuario logueado.
            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario usuario = mDb.usuario.Single(usr => usr.id == idUsr);

            // borro la contraseña para que no se devuelva a la vista.
            usuario.contrasena = "";

            // guardo los datos que serán cargados en los combo
            ViewBag.pais = new SelectList(mDb.pais, "id", "nombre", usuario.localidad1.provincia1.pais);
            ViewBag.provincia = mDomicilioController.GetSelectListProvinciasPorPais(usuario.localidad1.provincia1.pais1.id, usuario.localidad1.provincia1.id);
            ViewBag.localidad = mDomicilioController.GetSelectListLocalidadesPorProvincia(usuario.localidad1.provincia1.id, usuario.localidad1.id);

            return PartialView(usuario);
        }

        /// <summary>
        /// Prepara a vista para realizar el cambio de contraseña.
        /// </summary>
        /// <returns>GET: /Usuario/CambiarContrasenia</returns>
        public ActionResult CambiarContrasenia()
        {
            return View();
        }

        public ActionResult DarBajaUsuario()
        {
            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario usuario = mDb.usuario.Single(usr => usr.id == idUsr);

            // borro la contraseña para que no se devuelva a la vista.
            usuario.contrasena = "";

            return PartialView(usuario);
        }

        #endregion

        #region ABM

        /// <summary>
        /// Guarda los datos de un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Nuevo usuario</param>
        /// <param name="returnUrl">Es la página a donde se irá en caso de un registro exitoso.</param>
        /// <param name="cc">Controller que solicita el pedido.</param>
        /// <returns>Si fue exitoso, devuelve la página principal del usuario; de lo contrario, devuelve un error. </returns>
        public ActionResult GuardarUsuario(usuario usuario, string returnUrl, ControllerContext cc)
        {
            // recupero el tipo de usuario y agrego la fecha de alta.
            usuario.tipo_usuario = ObtenerIdTipoDeUsuario(cc.RouteData.Values["controller"].ToString());
            usuario.fecha_alta = System.DateTime.Now;

            // encripto la contraseña
            string tmp = usuario.contrasena;
            usuario.contrasena = Utiles.Password.HashPassword(usuario.contrasena);

            // aplico los cambios.
            mDb.usuario.AddObject(usuario);
            if (mDb.SaveChanges() == 0)
            {
                ModelState.AddModelError("ErrorGuardar", "Ha ocurrido un error mientras se intentaba guardar sus datos. Por favor, intentelo de nuevo más tarde.");
                return View();
            }

            // recupero la contraseña sin encriptar para poder realizar el primer login.
            usuario.contrasena = tmp;

            // Si se pudo grabar el usuario, creo la sesión y lo redirecciono
            // a su página principal.
            LoginController login = new LoginController();
            return login.iniciarSesionContexto(usuario, returnUrl, cc);
        }

        /// <summary>
        /// Modifica los datos de un usuario de la base de datos.
        /// </summary>
        /// <param name="usuario">Es el usuario que contiene los datos modificados.</param>
        /// <returns></returns>
        public ActionResult ModificarUsuario(usuario usuario)
        {
            // debido a que los cambios sólo se pueden aplicar al usuario original, lo recupero de la base de datos.
            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario usrOriginal = mDb.usuario.Single(usr => usr.id == idUsr);

            // paso los datos que puden haber sido modificados.
            usrOriginal.nombre = usuario.nombre;
            usrOriginal.apellido = usuario.apellido;
            usrOriginal.fecha_nacimiento = usuario.fecha_nacimiento;
            usrOriginal.localidad = usuario.localidad;
            usrOriginal.especialidad = usuario.especialidad;

            // aplico los cambios.
            mDb.ObjectStateManager.ChangeObjectState(usrOriginal, EntityState.Modified);
            if (mDb.SaveChanges() == 0)
            {
                ModelState.AddModelError("ErrorModificar", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
                return View();
            }

            // si todo fue bien, vuelvo al "Index" de usuario.
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Aplica el cambio de contraseña verificando primero que las mismas coincidan.
        /// </summary>
        /// <param name="contrasena">Contraseña vieja.</param>
        /// <param name="nuevaContrasena">Contraseña nueva</param>
        /// <param name="repNuevaContrasena">Repetición de la nueva contraseña.</param>
        /// <returns>Si el cambio fue exitoso, se cierra la sesión. De los contrario, se muestra un mensaje de error.</returns>
        [HttpPost]
        public ActionResult CambiarContrasenia(string contrasena, string nuevaContrasena, string repNuevaContrasena)
        {
            // recupero los datos del usuario para aplicarle los cambios.
            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario usrOriginal = mDb.usuario.Single(usr => usr.id == idUsr);

            // verifico si las contraseñas coinciden.
            if (ModelState.IsValid && nuevaContrasena.Equals(repNuevaContrasena) && Utiles.Password.CheckPassword(usrOriginal.contrasena, contrasena))
            {
                // aplico el algoritmo de encriptado y guardo los cambios.
                usrOriginal.contrasena = Utiles.Password.HashPassword(nuevaContrasena);
                mDb.ObjectStateManager.ChangeObjectState(usrOriginal, EntityState.Modified);
                if (mDb.SaveChanges() == 0)
                {
                    ModelState.AddModelError("ErrorContrasena", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
                    return View();
                }

                // si todo fue bien, cierro la sesión.
                LoginController login = new LoginController();
                return login.CerrarSesion(ControllerContext);
            }

            ViewBag.error = "La contraseña actual no es correcta. Vuelva a intentarlo.";
            return View();
        }


        public ActionResult RecuperarContrasenia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContrasenia(String mail)
        {
            usuario usr = mDb.usuario.FirstOrDefault(x => x.mail == mail);

            if (usr != null)
            {
                String nuevaContrasena = System.DateTime.Now.ToString("ddMMyyyyHHmmss");

                usr.contrasena = Utiles.Password.HashPassword(nuevaContrasena);
                mDb.ObjectStateManager.ChangeObjectState(usr, EntityState.Modified);

                MensajeController msjController = new MensajeController();
                msjController.enviarEmail(mail, "[PEALS] Recuperación de contraseña", "Hemos modificado su contraseña por la siguiente: " + nuevaContrasena);

                if (mDb.SaveChanges() > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Ocurrio un error. Intente nuevamente." ;
                    return View("ErrorConMensaje");
                }
            }
            else
            {
                ViewBag.error = "No existe un usuario con el correo electrónico "+ mail +" registrado en PEALS.";
                return View("ErrorConMensaje");
            }
        }

        /// <summary>
        /// Guarda los datos de un usuario cuando se da de baja en la base de datos.
        /// </summary>
        /// <param name="usuario">Usuario que se da de baja</param>
        /// <param name="returnUrl">Es la página a donde se irá en caso de un registro exitoso.</param>
        /// <param name="cc">Controller que solicita el pedido.</param>
        /// <returns>Si fue exitoso, devuelve la página de Inicio del sistema; de lo contrario, devuelve un error. </returns>
        [HttpPost]
        public void DarBajaUsuario(usuario usuario)
        {
            // Asigno la fecha de baja
            usuario.fecha_baja = System.DateTime.Now;

            //Asigno el estado "de baja"
            usuario.estado_usuario = (int)EstadoUsuario.DeBaja;

            // aplico los cambios.
            mDb.ObjectStateManager.ChangeObjectState(usuario, EntityState.Modified);
        }

        #endregion

        #region MÉTODOS AUXILIARES

        /// <summary>
        /// Recupera el ID de un Tipo de Usuario pasado por parámetro.
        /// </summary>
        /// <param name="tipoUsr">Nombre del tipo de usuario.</param>
        /// <returns>Devuelve el ID del tipo de usuario pasado por parámetro.</returns>
        public int ObtenerIdTipoDeUsuario(string tipoUsr)
        {
            return mDb.tipo_usuario.Single(tu => tu.nombre.Equals(tipoUsr)).id;
        }

        /// <summary>
        /// Verifica si el nombre de usuario(e-mail) pasado por parámetro se 
        /// encuentra en la base de datos.
        /// </summary>
        /// <param name="email">Es el email que será verificado</param>
        /// <returns> 
        /// Devuelve "True" si el usuario ya se encuentra registrado y "False"
        /// en caso contrario.
        /// </returns>
        public JsonResult EsUsuarioRegistrado(string email)
        {
            bool ret = mDb.usuario.Any(m => m.mail == email);

            JsonResult jSon = new JsonResult { Data = new { Success = ret } };
            jSon.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jSon;
        }

        [HttpPost]
        public ActionResult existeMail(String mail)
        {
            var usuarios =
                from usu in mDb.usuario
                where usu.mail == mail
                select new
                {
                    Id = usu.id
                };

            Int32 id = usuarios.ToList().Count;
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
