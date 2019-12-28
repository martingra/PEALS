using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;
using System.Data;

namespace Peals.Controllers
{
    public class AlumnoController : UsuarioController
    {

        #region VIEWS
        /// <summary>
        /// Crea la vista principal del Alumno. 
        /// </summary>
        /// <returns>GET: /Alumno/Index</returns>
        public ActionResult Index()
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            ViewBag.idAlumno = id;
            DateTime fechaHoy = DateTime.Now;

            var actividadesPorAlumno =
                from alumno in mDb.alumno_x_curso
                join actividades in mDb.actividad_x_curso on alumno.curso equals actividades.curso
                where alumno.alumno == id && 
                      actividades.fecha_apertura <= fechaHoy &&
                      (actividades.actividad1.estado == (int)EstadoActividad.Alta || actividades.actividad1.estado == (int)EstadoActividad.ConHistorial)
                select new
                {
                    ID = actividades.actividad1.id,
                    Alumno = alumno.alumno,
                    Nombre = actividades.actividad1.nombre,
                    NombreCurso = actividades.curso1.nombre,
                    AnoCurso = actividades.curso1.ano,
                    DivisionCurso = actividades.curso1.division,
                    IDCurso = actividades.curso1.id,
                    Resolucion = (
                        from ha in mDb.historial_actividad
                        where ha.actividad == actividades.actividad1.id && ha.alumno == alumno.alumno
                        select ha
                        ).Count()
                };

            //var sql = ((System.Data.Objects.ObjectQuery)actividadesPorAlumno).ToTraceString();

            return View(actividadesPorAlumno);
        }

        /// <summary>
        /// Prepara la vista para registrar a un nuevo alumno.
        /// </summary>
        /// <see cref="Usuario/NuevoUsuario"/>
        /// <returns>GET: Alumno/NuevoAlumno</returns>
        public ActionResult NuevoAlumno()
        {
            return View();
        }

        /// <summary>
        /// Prepara la vista para poder modificar los datos del alumno.
        /// </summary>
        /// <see cref="Usuario/EditarUsuario"/>
        /// <returns>GET: Alumno/EditarAlumno</returns>
        public ActionResult EditarAlumno()
        {
            return View();
        }

        /// <summary>
        /// Prepara la vista para poder dar de baja al alumno.
        /// </summary>
        /// <see cref="Usuario/DarBajaUsuario"/>
        /// <returns>GET: Alumno/DarBajaAlumno</returns>
        public ActionResult DarBajaAlumno()
        {
            return View();
        }

        public ActionResult MisCursos()
        {
            return View();
        }

        public ActionResult Reportes()
        {

            return View();
        }
        #endregion

        #region ABM
        /// <summary>
        /// Guarda los datos del alumno en la base de datos.
        /// </summary>
        /// <param name="alumno">Alumno a registrar</param>
        /// <returns>Devuelve la vista Index del alumno o un mensaje en caso de error.</returns>
        [HttpPost]
        public ActionResult NuevoAlumno(usuario alumno)
        {
            // Si el modelo es válido, guardo el usuario; de lo contrario, vuelvo a la vista.
            return (ModelState.IsValid) ? GuardarUsuario(alumno, View().ViewName, ControllerContext) : View();
        }

        /// <summary>
        /// Aplica los cambios a los datos del alumno.
        /// </summary>
        /// <param name="alumno">Objecto que contiene los cambios aplicados por el alumno.</param>
        /// <returns>Redirecciona a la página Index o muestra un mensaje en caso de error.</returns>
        [HttpPost]
        public ActionResult EditarAlumno(usuario alumno)
        {
            // Si el modelo es válido, guardo los cambios; de lo contrario, vuelvo a la vista.
            return (ModelState.IsValid) ? ModificarUsuario(alumno) : View();
        }

        /// <summary>
        /// Guarda el alumno dado de baja en la base de datos.
        /// </summary>
        /// <param name="alumno">Alumno a dar de baja</param>
        /// <returns>Devuelve la vista Index del home o un mensaje en caso de error.</returns>
        [HttpPost]
        public ActionResult DarBajaAlumno(usuario alum)
        {
            //seteo el modelo a lo demas controladores
            mCursoController.setModelo(mDb);
            mInstitucionController.setModelo(mDb);

            // debido a que los cambios sólo se pueden aplicar al usuario original, lo recupero de la base de datos.
            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario alumno = mDb.usuario.Single(usr => usr.id == idUsr);           

             // borro las inscripciones a los cursos del alumno
             mCursoController.BorrarInscripcionCursosAlumno(alumno.id);

             // borro las inscripciones a las instituciones del alumno
             mInstitucionController.BorrarInscripcionInstitucionesAlumno(alumno.id);

             // doy de baja al usuario
             this.DarBajaUsuario(alumno);


                if (mDb.SaveChanges() == 0)
                {
                    ModelState.AddModelError("ErrorModificar", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
                    return View();
                }

            // Si se pudo dar de baja al usuario, cierro sesión y lo redirecciono a la pagina principal.
            return this.CerrarSesion();
        }

        #endregion

        #region MÉTODOS AUXILIARES

        /// <summary>
        /// Cierro la sesion del alumno.
        /// </summary>
        /// <returns>Devuelve la vista Index del home o un mensaje en caso de error.</returns>
        public ActionResult CerrarSesion()
        {
            LoginController login = new LoginController();
            return login.CerrarSesion(ControllerContext);
        }

        #endregion

        #region PARTIAL VIEWS

        /// <summary>
        /// Crea una vista parcial con el listado de los cursos del alumno.
        /// </summary>
        /// <returns>PartialView: /Alumno/_Cursos</returns>
        public ActionResult _CursosAlumno()
        {
            //recupero el ID del usuario de la sesión
            int idAlumno = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<curso> cursos = null;

            cursos = mCursoController.GetCursosAlumno(idAlumno);
            ViewBag.Cursos_DefaultMessage = "En estos momentos no te encuentras inscripto a ningun curso.";

            return PartialView(cursos);
        }

        public ActionResult _InstitucionesAlumno()
        {
            //recupero el ID del usuario de la sesión
            int idAlumno = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<institucion> instituciones = null;

            instituciones = mInstitucionController.GetInstitucionesAlumno(idAlumno);
            ViewBag.Cursos_DefaultMessage = "En estos momentos no te encuentras inscripto a ninguna institución.";

            return PartialView(instituciones);
        }

        /// <summary>
        /// devuelve los alumnos que estan inscriptos a una institucion particular
        /// </summary>
        /// <returns></returns>
        public ActionResult _AlumnosInstitucion(int idInstitucion, int idCurso)
        {
            //curso curso = mDb.curso.First(x => x.id == idCurso);
            ViewBag.curso = idCurso;
            List<int> instituciones = new List<int>();
            instituciones.Add(idInstitucion);
            List<usuario> alumnos = getAlumnosPorInstitucion(instituciones);
            ViewBag.Alumnos_DefaultMessage = "No hay ningún alumno inscripto en esta institución.";
            return PartialView(alumnos);
        }

        /// <summary>
        /// devuelve todos los alumnos de peals que no están en el curso
        /// </summary>
        /// <returns></returns>
        public ActionResult _AlumnosNoCurso(int idInstitucion, int idCurso, String filtro = "")
        {
            ViewBag.curso = idCurso;
            ViewBag.institucion = idInstitucion;

            List<int> instituciones = new List<int>();
            instituciones.Add(idInstitucion);

            //var qAlumnos = 
            //    from a in mDb.usuario
            //    where a.tipo_usuario1.nombre == "Alumno" &&
            //            !(from ac in mDb.alumno_x_curso    
            //              select ac.alumno).Contains(a.id) 
            //    select a;

            Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            var qAlumnos =
            from a in mDb.usuario
            where a.tipo_usuario1.nombre == "Alumno" &&
                    !(from ac in mDb.alumno_x_curso where ac.curso == idCurso
                      select ac.alumno).Contains(a.id) && (
                      a.nombre.Contains(filtro) || a.apellido.Contains(filtro) || a.mail.Contains(filtro)
                      )
            select new
            {
                a.id,
                a.nombre,
                a.apellido,
                a.mail,
                solicitudes = (
                    from msj in mDb.mensaje 
                    from msjDest in mDb.mensaje_x_destinatario
                    where msjDest.mensaje == msj.id && msjDest.destinatario == a.id && msj.emisor_mensaje == idUsuario && msj.tipo_mensaje == 2 && msj.tipo_solicitud == 5 && msj.referencia == idCurso
                    select msj.id).Count()
            };

            //List<usuario> alumnos = qAlumnos.ToList();

            //List<usuario> alumnos = getAlumnosPorInstitucion(instituciones);
            ViewBag.Alumnos_DefaultMessage = "No hay ningún alumno inscripto en esta institución.";
            return PartialView(qAlumnos);
        }

        /// <summary>
        /// hecho para ser usado por alguien q lo necesite. yo no lo use.
        /// </summary>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public ActionResult _AlumnosCurso(int idCurso)
        {
            ViewBag.curso = idCurso;
            curso cur = mDb.curso.Single(x => x.id == idCurso);
            ViewBag.nombreCurso = cur.nombre;
            var alumnos =
                from al in mDb.usuario
                from cu in mDb.curso
                from al_cu in mDb.alumno_x_curso
                where al.id == al_cu.alumno && cu.id == al_cu.curso && cu.id == idCurso
                select al;

            ViewBag.Alumnos_DefaultMessage = "No hay ningún alumno inscripto en esta institución.";
            return PartialView(alumnos);
        }

        #endregion

        #region GET

        public List<usuario> getAlumnosPorInstitucion(List<int> idInstituciones)
        {
            List<usuario> listaAlumnos = new List<usuario>();
            if (idInstituciones != null)
            {
                var idAlumnos = (from axi in mDb.alumno_x_institucion
                                where idInstituciones.Contains(axi.institucion.Value)
                               select axi.alumno).Distinct();

                var alumnos = from a in mDb.usuario
                                where idAlumnos.Contains(a.id)
                                select a;

                listaAlumnos = alumnos.ToList();
            }

            return listaAlumnos;
        }

        #endregion

        [HttpPost]
        public ActionResult getActividades()
        {
            Int32 id_alumno = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var mostrar =
                from a in mDb.actividad
                from ac in mDb.alumno_x_curso
                from acc in mDb.actividad_x_curso
                where ac.curso1.estado == (int) EstadoCurso.Alta
                    && acc.actividad == a.id
                    && acc.curso == ac.curso
                    && ac.alumno == id_alumno
                select new { Value = a.nombre, Label = a.nombre, Id = a.id };

            return Json(mostrar.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
