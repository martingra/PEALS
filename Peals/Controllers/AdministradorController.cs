using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Web.Mvc;
using Peals.Models;
using System;

namespace Peals.Controllers
{
     
    public class AdministradorController : UsuarioController
    {
        private DocenteController mDocenteController = new DocenteController();
        private AlumnoController mAlumnoController = new AlumnoController();

        #region Views
        
        /// <summary>
        /// Prepara la vista principal del Administrador cargando en el modelo el listado de
        /// instutuciones a cargo del administrador logueado.
        /// </summary>
        /// <returns>GET: Administrador/Index</returns>
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            ViewBag.Administrador = User.Identity.Name;

            // recupero el id del usuario logueado.
            int idAdmin = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            // recupero todas las instituciones que tiene a cargo
            var instituciones =
                from 
                    ins in mDb.institucion
                where
                    ins.administrador == idAdmin
                select new
                {
                    ID = ins.id,                                                // ID de la institucion
                    Nombre = ins.nombre,                                        // Nombre de a institucion
                    Cursos = ins.curso.Distinct().Count(),                      // Cantidad de cursos
                    Docentes = ins.docente_x_institucion.Distinct().Count(),    // Cantidad de docentes
                    Alumnos = ins.alumno_x_institucion.Distinct().Count()       // Cantidad de alumnos
                };

            if (ControllerContext.HttpContext.Session["institucion"] != null && (int)ControllerContext.HttpContext.Session["institucion"] != -1)
            {
                ViewBag.institucionSeleccionada = ControllerContext.HttpContext.Session["institucion"];
                int idInst = (int)ControllerContext.HttpContext.Session["institucion"];
                var institucion = mDb.institucion.Single(x => x.id == idInst);
                ViewBag.nombreInstitucionSeleccionada = institucion.nombre;
            }
            else
            {
                ViewBag.institucionSeleccionada = 0;
            }
            // devuelvo la vista con las instituciones cargadas en el modelSo.
            return View(instituciones.ToList());
        }

        /// <summary>
        /// Prepara la vista para registrar a un nuevo administrador
        /// </summary>
        /// <see cref="Usuario/NuevoUsuario"/>
        /// <returns>GET: Administrador/NuevoAdministrador</returns>
        public ActionResult NuevoAdministrador()
        {
            return View();
        }

        /// <summary>
        /// Prepara la vista para poder editar los datos del administrador.
        /// </summary>
        /// <see cref="Usuario/EditarUsuario"/>
        /// <returns>GET: Administrador/EditarAdministrador</returns>
        [Authorize(Roles = "Administrador")]
        public ActionResult EditarAdministrador()
        {
            return View();
        }

        /// <summary>
        /// Prepara la vista para poder dar de baja al administrador.
        /// </summary>
        /// <see cref="Usuario/DarBajaUsuario"/>
        /// <returns>GET: Administrador/DarBajaAdministrador</returns>
        [Authorize(Roles = "Administrador")]
        public ActionResult DarBajaAdministrador()
        {
            return View();
        }

        /// <summary>
        /// Registra los datos del nuevo admnistrador en la base de datos, verificando primero
        /// que los datos sean válidos.
        /// </summary>
        /// <param name="administrador">usuario a registrar</param>
        /// <returns>En caso de éxito, se redirecciona a Administrador/Index; de los cotrario, se muestra un error.</returns>
        [HttpPost]
        public ActionResult NuevoAdministrador(usuario administrador)
        {
            // Si el modelo es válido, guardo el usuario; de lo contrario, devuelvo null.
            return (ModelState.IsValid) ? GuardarUsuario(administrador, View().ViewName, ControllerContext) : View();
        }


        /// <summary>
        /// Registra las modificaciones aplicadas a los datos del usuario.
        /// </summary>
        /// <param name="administrador">usuario modificado</param>
        /// <returns>En caso de éxito, se redirecciona a Administrador/Index; de los cotrario, se muestra un error.</returns>
        [HttpPost]
        public ActionResult EditarAdministrador(usuario administrador)
        {
            // Si el modelo es válido, guardo los cambios; de lo contrario, vuelvo a la vista.
            return (ModelState.IsValid) ? ModificarUsuario(administrador) : View();
        }

        /// <summary>
        /// Guarda el administrador dado de baja en la base de datos.
        /// </summary>
        /// <param name="administrador">administrador a dar de baja</param>
        /// <returns>Devuelve la vista Index del home o un mensaje en caso de error.</returns>
        [HttpPost]
        public ActionResult DarBajaAdministrador(ControllerContext cc)
        {
            //seteo el modelo a lo demas controladores
            mActividadController.setModelo(mDb);
            mCursoController.setModelo(mDb);
            mInstitucionController.setModelo(mDb);

            // debido a que los cambios sólo se pueden aplicar al usuario original, lo recupero de la base de datos.
            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario administrador = mDb.usuario.Single(usr => usr.id == idUsr);

            //recupero las instituciones del administrador, borro la referencia del mismo a las instituciones y recupero los ids de las instituciones
            List<institucion> instituciones = mInstitucionController.GetInstitucionesAdministrador(administrador.id);
            List<int> idInstituciones = new List<int>();
            foreach (institucion i in instituciones)
            {
                idInstituciones.Add(i.id);
                i.administrador = null;
                mDb.ObjectStateManager.ChangeObjectState(i, EntityState.Modified);
            }

            // borro las inscripciones de los docentes a las instituciones del administrador.
            mInstitucionController.BorrarInscripcionDocentesInstituciones(idInstituciones);

            // borro las inscriciones de los alumnos a las instituciones del administrador.
            mInstitucionController.BorrarInscripcionAlumnosInstituciones(idInstituciones);

            // borro los cursos de los docentes pertenecientes a las instituciones del administrador.
            // borro las actividades de esos cursos que no tengan historial de actividad.
            // las actividades que tengan historial quedaran desvinculadas del docente.
            mCursoController.DarBajaCursosYActividadesInstituciones(idInstituciones);

            // doy de baja al usuario
            this.DarBajaUsuario(administrador);

            if (mDb.SaveChanges() == 0)
            {
                ModelState.AddModelError("ErrorModificar", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
                return View();
            }

            // Si se pudo dar de baja al usuario, cierro sesión y lo redirecciono a la pagina principal.
            return this.CerrarSesion();
        }

        public bool validarAdministrador(string mailAdministrador)
        {
            usuario nuevoUsuario;
            try
            {
                nuevoUsuario = mDb.usuario.Single(usr => usr.mail == mailAdministrador);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
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
        public JsonResult EsUsuarioAdministradorRegistrado(string email)
        {
            bool ret = mDb.usuario.Any(m => m.mail == email);

            if (ret)
            {
                usuario user = mDb.usuario.First(m => m.mail == email);
                if (user.tipo_usuario != 1)
                {
                    ret = false;
                }
            }

            JsonResult jSon = new JsonResult { Data = new { Success = ret } };
            jSon.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jSon;
        }

        public ActionResult exportarAdministrador(string mailAdministrador)
        {
            usuario nuevoUsuario;
            try
            {
               nuevoUsuario = mDb.usuario.Single(usr => usr.mail == mailAdministrador);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("ErrorModificar", "Por favor, ingrese el mail de un usuario registrado");
                return RedirectToAction("DarBajaAdministrador", "Administrador");
            }

            if (nuevoUsuario.tipo_usuario != 1)
            {
                ModelState.AddModelError("ErrorModificar", "Por favor, ingrese el mail de un usuario Administrador");
                return RedirectToAction("DarBajaAdministrador", "Administrador");
            }

            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario administrador = mDb.usuario.Single(usr => usr.id == idUsr);

            mInstitucionController.setModelo(mDb);
            List<institucion> instituciones = mInstitucionController.GetInstitucionesAdministrador(administrador.id);
            


            foreach (institucion i in instituciones)
            {
                i.administrador = nuevoUsuario.id;
                mDb.ObjectStateManager.ChangeObjectState(i, EntityState.Modified);
            }
            
            // doy de baja al usuario
            this.DarBajaUsuario(administrador);

            if (mDb.SaveChanges() == 0)
            {
                ModelState.AddModelError("ErrorModificar", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
                return View();
            }

            // Si se pudo dar de baja al usuario, cierro sesión y lo redirecciono a la pagina principal.
            return this.CerrarSesion();
        }

        /// <summary>
        /// Cierro la sesion del administrador.
        /// </summary>
        /// <returns>Devuelve la vista Index del home o un mensaje en caso de error.</returns>
        public ActionResult CerrarSesion()
        {
            LoginController login = new LoginController();
            ControllerContext.HttpContext.Session["institucion"] = null;
            return login.CerrarSesion(ControllerContext);
        }


        public ActionResult Reportes()
        {
            Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var institucion =
                from i in mDb.institucion
                where i.administrador == idUsuario
                select i;
            ViewData["institucion"] = new SelectList(institucion.ToList(), "id", "nombre");

            return View();
        }
        #endregion


        public bool setInstitucionSeleccionada(int idInstitucion)
        {
            if (idInstitucion != -1)
            {
                ControllerContext.HttpContext.Session["institucion"] = idInstitucion;
            }
            return true;
        }

        #region REPORTES
        public ActionResult reporteCursos(Int32 idInstitucion)
        {


            return View();
        }

        #endregion

        #region PARTIAL VIEWS

        /// <summary>
        /// Crea una vista parcial con el listado de las instituciones del administrador.
        /// </summary>
        /// <returns>PartialView: /Administrador/_InstitucionesAdministrador</returns>
        public ActionResult _InstitucionesAdministrador()
        {
            //recupero el ID del usuario de la sesión
            int idAdministrador = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<institucion> instituciones = mInstitucionController.GetInstitucionesAdministrador(idAdministrador);
            ViewBag.Cursos_DefaultMessage = "En estos momentos no te encuentras inscripto a ninguna institución.";

            return PartialView(instituciones);
        }

        /// <summary>
        /// Crea una vista parcial con el listado de las instituciones del administrador.
        /// </summary>
        /// <returns>PartialView: /Administrador/_InstitucionesAdministrador</returns>
        public ActionResult _DocentesAdministrador()
        {
            //recupero el ID del usuario de la sesión
            int idAdministrador = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<institucion> instituciones = mInstitucionController.GetInstitucionesAdministrador(idAdministrador);
            List<int> idInstituciones = new List<int>();
            List<usuario> docentes = new List<usuario>();
            foreach (institucion i in instituciones)
            {
                idInstituciones.Add(i.id);
            }
            
            docentes = mDocenteController.getDocentesPorInstitucion(idInstituciones);

            ViewBag.Cursos_DefaultMessage = "En estos momentos ningún docente se encuentra inscripto a ninguna institución.";

            return PartialView(docentes);
        }

        public ActionResult _AlumnosAdministrador()
        {
            //recupero el ID del usuario de la sesión
            int idAdministrador = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<institucion> instituciones = mInstitucionController.GetInstitucionesAdministrador(idAdministrador);
            List<int> idInstituciones = new List<int>();
            List<usuario> alumnos = new List<usuario>();
            foreach (institucion i in instituciones)
            {
                idInstituciones.Add(i.id);
            }

            alumnos = mAlumnoController.getAlumnosPorInstitucion(idInstituciones);

            ViewBag.Cursos_DefaultMessage = "En estos momentos ninguno docente se encuentra inscripto a ninguna institución.";

            return PartialView(alumnos);
        }

        public ActionResult _CursosAdministrador()
        {
            //recupero el ID del usuario de la sesión
            int idAdministrador = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<institucion> instituciones = mInstitucionController.GetInstitucionesAdministrador(idAdministrador);
            List<int> idInstituciones = new List<int>();
            List<curso> cursos = new List<curso>();
            foreach (institucion i in instituciones)
            {
                idInstituciones.Add(i.id);
            }

            cursos = mCursoController.getCursosPorInstitucion(idInstituciones);

            ViewBag.Cursos_DefaultMessage = "En estos momentos ninguno docente se encuentra inscripto a ninguna institución.";

            return PartialView(cursos);
        }

        #endregion
    }
}
