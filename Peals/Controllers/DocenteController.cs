using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Peals.Models;

namespace Peals.Controllers
{
    
    public class DocenteController : UsuarioController
    {

        #region VIEWS

        /// <summary>
        /// Crea la vista principal del Docente. 
        /// </summary>
        /// <returns>GET: /Docente/Index</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult Index()
        {
            // agrega tres vistas parciales para "Actividades", "Cursos" y "Solicitudes"
            return View();
        }

        /// <summary>
        /// Prepara la vista para registrar a un nuevo docente.
        /// </summary>
        /// <returns>GET: /Docente/NuevoDocente</returns>
        public ActionResult NuevoDocente()
        {
            // recupero las especialidades y las guardo en el diccionario
            var especialidades =
                from e in mDb.especialidad
                select e;

            ViewData["especialidad"] = new SelectList(especialidades.ToList(), "id", "nombre");

            // devuelvo la vista anexando en el view la vista parcial de /Usuario/NuevoUsuario.
            return View();
        }

        /// <summary>
        /// Prepara la vista para realizar la edición de los datos del docente.
        /// </summary>
        /// <returns>GET: /Docente/EditarDocente</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult EditarDocente()
        {
            String mailUsuario = User.Identity.Name;
            usuario usuario = mDb.usuario.Single(u => u.mail == mailUsuario);
            ViewBag.especialidad = new SelectList(mDb.especialidad, "id", "nombre", usuario.especialidad);

            return View();
        }

        /// <summary>
        /// Prepara la vista para poder dar de baja al docente.
        /// </summary>
        /// <see cref="Usuario/DarBajaUsuario"/>
        /// <returns>GET: Docente/DarBajaDocente</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult DarBajaDocente()
        {
            return View();
        }


        /// <summary>
        /// Devuelvo un listado de todas las actividades creadas por el docente.
        /// </summary>
        /// <param name="nombre">Opcional, es el nombre de la actividad y se usa para filtrar los resultados.</param>
        /// <returns>PartialView: /Docente/_ListadoDeActividades</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult _ListadoDeActividades(string nombre= "")
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            var actividades = mDb.actividad.Where(x => x.docente == id && (x.estado == (int)EstadoActividad.Alta || x.estado == (int)EstadoActividad.ConHistorial) && x.nombre.Contains(nombre.ToLower()));

            return PartialView(actividades.ToList());
        }

        /// <summary>
        /// Devuelve un listado con todos los docentes registrados en el sistema, diciendo además
        /// cuales de ellos trabajan con la institución pasada por parámetro.
        /// </summary>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult TodosLosDocentes(int idInstitucion)
        {
            ViewBag.idInstitucion = idInstitucion;
            var institucion = mDb.institucion.First(x => x.id == idInstitucion);

            var docentes =
                from d in mDb.usuario
                join di in mDb.docente_x_institucion on d.id equals di.docente into ljoin // LEFT JOIN
                from lj in ljoin.DefaultIfEmpty()
                where d.tipo_usuario == (int)TipoDeUsuario.Docente
                let tieneInstitucion = lj.docente.HasValue // Var Aux para que indica si un docente se encuentra trabajando en una institución.
                group d.id by new { d.id, d.nombre, d.apellido, d.mail, d.especialidad1, tieneInstitucion } into d
                select new
                {
                    Id = d.Key.id,
                    Nombre = string.Concat(d.Key.apellido, ", ", d.Key.nombre),
                    Mail = d.Key.mail,
                    Especialidad = d.Key.especialidad1.nombre,
                    CantInstituciones = (d.Key.tieneInstitucion) ? d.Count() : 0,
                    TrabajaEnInstitucion = (from inst in mDb.docente_x_institucion where inst.docente == d.Key.id && inst.institucion == idInstitucion select 1).Count(),
                    SolicitudesEnviadas = (
                        from m in mDb.mensaje 
                        from md in mDb.mensaje_x_destinatario
                        where m.id == md.mensaje1.id
                            && m.emisor_mensaje == institucion.administrador 
                            && m.tipo_mensaje == 2 //Solicitud
                            && (m.estado_mensaje == 1 || m.estado_mensaje == 2) //
                            && m.tipo_solicitud == 3 //inscripcion docente
                            && md.destinatario == d.Key.id
                        select m.id
                        ).Count() 
                };

            return View(docentes);
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult DiacOSeguimiento()
        {
            return View();
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult Reportes()
        {
            Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            //var cursos =
            //    from c in mDb.curso
            //    where c.docente == idUsuario
            //    select c;
            //ViewData["cursos"] = new SelectList(cursos.ToList(), "id", "nombre");

            ViewBag.docente = idUsuario;
            return View();
        }


        #endregion

        #region ABM

        /// <summary>
        /// Guarda los datos del docente en la base de datos.
        /// </summary>
        /// <param name="docente">Docente a registrar</param>
        /// <returns>Devuelve la vista Index del docente o un mensaje en caso de error.</returns>
        [HttpPost]
        public ActionResult NuevoDocente(usuario docente)
        {
            // Si el modelo es válido, guardo el usuario; de lo contrario, devuelvo null.
            return (ModelState.IsValid) ? GuardarUsuario(docente, View().ViewName, ControllerContext) : View();
        }

        /// <summary>
        /// Aplica los cambios a los datos del docente.
        /// </summary>
        /// <param name="docente">Objecto que contiene los cambios aplicados por el docente.</param>
        /// <returns>Redirecciona a la página Index o muestra un mensaje en caso de error.</returns>
        [HttpPost]
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult EditarDocente(usuario docente)
        {
            // Si el modelo es válido, guardo los cambios; de lo contrario, vuelvo a la vista.
            return (ModelState.IsValid) ? ModificarUsuario(docente) : View();
        }

        /// <summary>
        /// Guarda el docente dado de baja en la base de datos.
        /// </summary>
        /// <param name="docente">Docente a dar de baja</param>
        /// <returns>Devuelve la vista Index del home o un mensaje en caso de error.</returns>
        [HttpPost]
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult DarBajaDocente(usuario doc)
        {
            //seteo el modelo a lo demas controladores
            mActividadController.setModelo(mDb);
            mCursoController.setModelo(mDb);
            mInstitucionController.setModelo(mDb);
            mRecursoController.setModelo(mDb);

            // debido a que los cambios sólo se pueden aplicar al usuario original, lo recupero de la base de datos.
            int idUsr = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario docente = mDb.usuario.Single(usr => usr.id == idUsr);

            //Doy de baja a los recursos
            mRecursoController.DarDeBajaRecursosDocente(docente.id);

            // Doy de baja a las actividades del docente.
            mActividadController.DarDeBajaActividadesDocente(docente.id);

            // borro el docente de las actividades con curso.
            //mActividadController.BorrarInscripcionActividadesDocenteConCurso(docente.id);

            // Doy de baja a los cursos del docente
            mCursoController.DarDeBajaCursosDocente(docente.id);

            // borro el docente de las actividades sin curso pero con historial.
            //mActividadController.BorrarInscripcionActividadesDocenteSinCurso(docente.id);

            // borro las actividades del docente que no tengan curso y no tengan historial.
            //mActividadController.BorrarActividadesDocenteSinHistorial(docente.id);
            // borro el docente de los cursos
            //mCursoController.BorrarInscripcionCursosDocente(docente.id);

            // borro las inscripciones del docente a las instituciones
            mInstitucionController.BorrarInscripcionInstitucionesDocente(docente.id);

            // doy de baja al usuario
            this.DarBajaUsuario(docente);

            if (mDb.SaveChanges() == 0)
            {
                ModelState.AddModelError("ErrorModificar", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
                return View();
            }

            // Si se pudo dar de baja al usuario, cierro sesión y lo redirecciono a la pagina principal.
            return this.CerrarSesion();
        }

        #endregion

        /// <summary>
        /// INCOMPLETO - SE ENCARGARIA DE PREPARA LA VISTA PARA LA GESTION DE LAS 
        /// ACTIVIDADES POR PARTE DEL DOCENTE.
        /// </summary>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult GestionDeActividades()
        {
            // TODO: por ahí es mejor aplicar esto en un controlador específico de la actividad.
            return View();
        }



        #region PARTIAL VIEWS

        /// <summary>
        /// Crea una vista parcial que contiene una grilla con todas las actividades que esperan una
        /// correccion por parte del docente logueado.
        /// </summary>
        /// <returns>GET: /Docente/_ActividadesSinCorregir</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult _ActividadesSinCorregir(string searchCriteria = null, string searchValue = null)
        {
            //recupero el ID del usuario de la sesión
            int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            // consulto por las actividades, asignadas a un curso del cual el docente esta a cargo y, 
            // que se encuentran en el historial sin una nota del docente.
            // TODO: hay ciertas actividades que no tendrian nota por parte del docente. Hay que ver bien eso después.
            var actividadesPendientes =
                from hact in mDb.historial_actividad
                join acur in mDb.actividad_x_curso on hact.actividad equals acur.actividad
                where
                    hact.docente == idUsuario &&
                    hact.calificacion_docente == null && acur.curso == hact.curso

                select new
                {
                    Id = hact.id,
                    Actividad = hact.actividad1.nombre,
                    ApellidoAlumno = hact.usuario.apellido,
                    NombreAlumno = hact.usuario.nombre,
                    MailAlumno = hact.usuario.mail,
                    Institucion = acur.curso1.institucion1.nombre,
                    NombreCurso = acur.curso1.nombre,
                    AnoCurso = acur.curso1.ano,
                    DivisionCurso = acur.curso1.division,
                    Calificacion = hact.calificacion_sistema
                };

            if (!string.IsNullOrEmpty(searchCriteria))
            {
                // aplico el filtro a los datos.
                switch (searchCriteria)
                {
                    case "Alumno":
                        if (searchValue.Contains(","))
                        {
                            String nombre = searchValue.Split(',')[1].Trim().ToUpper();
                            String apellido = searchValue.Split(',')[0].Trim().ToUpper();

                            actividadesPendientes = actividadesPendientes.Where(item => item.ApellidoAlumno.ToUpper() == apellido && item.NombreAlumno.ToUpper() == nombre);
                        }
                        else
                        {
                            actividadesPendientes = actividadesPendientes.Where(item => item.ApellidoAlumno.ToUpper().Contains(searchValue.ToUpper()) || item.NombreAlumno.ToUpper().Contains(searchValue.ToUpper()) || item.MailAlumno.Contains(searchValue));
                        }

                        
                        break;
                    case "Actividad":
                        actividadesPendientes = actividadesPendientes.Where(item => item.Actividad.ToUpper().Contains(searchValue.ToUpper()));
                        break;
                    case "Institucion":
                        actividadesPendientes = actividadesPendientes.Where(item => item.Institucion.ToUpper().Contains(searchValue.ToUpper()));
                        break;
                    case "Curso":
                        //actividadesPendientes = actividadesPendientes.Where(item => item.DivisionCurso.ToUpper().Contains(searchValue.ToUpper()) || item.AnoCurso.Value.ToString().Contains(searchValue));
                        actividadesPendientes = actividadesPendientes.Where(item => item.NombreCurso.ToUpper().Contains(searchValue.ToUpper()));
                        break;
                }
            }

            // devuelvo la vista parcial con las actividades pendientes cargadas en el modelo.
            return PartialView(actividadesPendientes.ToList());
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult corregirActividad(int historialActividad)
        {
            historial_actividad ha = mDb.historial_actividad.First(x => x.id == historialActividad);
            ViewBag.HistorialActividad = historialActividad;

            criterio_evaluacion criterio = mDb.criterio_evaluacion.First(x => x.docente == ha.docente);

            System.Xml.XmlDocument xml_criterio = new System.Xml.XmlDocument();
            xml_criterio.LoadXml(criterio.descripcion);
            System.Xml.XmlNodeList intervalos = xml_criterio.GetElementsByTagName("intervalo");

            try
            {
                for (int i = 0; i < intervalos.Count; i++)
                {
                    int desde = int.Parse(intervalos[i].Attributes["value"].Value);
                    int hasta = int.Parse(intervalos[i + 1].Attributes["value"].Value);

                    if (desde <= (int)ha.calificacion_sistema && hasta >= (int)ha.calificacion_sistema)
                    {
                        if (intervalos[i + 1].InnerText == "-1")
                        {
                            ViewBag.imgCritSistema = "/Content/Resources/Actividad/carita-feliz.png";
                        }
                        else
                        {
                            int idRec = System.Int32.Parse(intervalos[i + 1].InnerText);
                            recurso rec = mDb.recurso.FirstOrDefault(x => x.id == idRec);
                            ViewBag.imgCritSistema = rec.ruta.Substring(1);
                        }

                        break;
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                ViewBag.imgCritSistema = "/Content/Resources/Actividad/carita-feliz.png";
            }
            
            return View(ha);
        }

        [HttpPost]
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult corregirActividad(int calificacion, int historialActividad, String mensaje)
        {
            historial_actividad ha = mDb.historial_actividad.First(x => x.id == historialActividad);
            ha.calificacion_docente = calificacion;

            //le mandamos una notificacion automatica al alumno avisandole que ya se corrigió la actividad
            MensajeController cMensaje = new MensajeController();
            cMensaje.setModelo(mDb);
            cMensaje.enviarNotificacion(ha.docente, ha.alumno, "", ha.id, "Te avisamos que el docente ha corregido la actividad " + ha.actividad1.nombre + ", resuelta el "+ ha.fecha_realizacion +". La calificación del docente es: " + ha.calificacion_docente + ". El Docente te Dejo el siguiente mensaje: " + mensaje, "Corrección Actividad");

            if (mDb.SaveChanges() == 0)
                return View("Error");
            else
                return RedirectToAction("Index", "Docente");
        }

        /// <summary>
        /// Crea una vista parcial con el listado de los cursos del docente.
        /// </summary>
        /// <returns>PartialView: /Docente/_Cursos</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult _Cursos(string searchCriteria = null, string searchValue = null)
        {
            //recupero el ID del usuario de la sesión
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<curso> cursos = mCursoController.GetCursosDocente(idDocente);
            string message = "En estos momentos no dispones de cursos a tu cargo.";

            int? actividad = TempData["ID_Actividad"] as int?;
            if (actividad.HasValue)
            {
                var c = mDb.actividad_x_curso.Where(x => x.curso1.docente == idDocente && x.actividad == actividad).Select(x => x.curso).ToList();
                cursos = cursos.Where(x => !c.Contains(x.id)).ToList();
            }

            if (!string.IsNullOrEmpty(searchCriteria))
            {
                if (searchCriteria.Equals("Institucion"))
                {
                    cursos = cursos.Where(x => x.institucion1.nombre.ToUpper().Contains(searchValue.ToUpper())).ToList();
                    message = "No se encontraron cursos pertenecientes a la institución con \"" + searchValue + "\" en su nombre";
                }
                else
                {
                    cursos = cursos.Where(x => x.nombre.ToUpper().Contains(searchValue.ToUpper())).ToList();
                    message = "No se encontraron cursos con \"" + searchValue + "\"";
                }
            }

            ViewBag.Cursos_DefaultMessage = message; 

            return PartialView(cursos);
        }

        /// <summary>
        /// Crea una vista parcial con el listado de solicitudes de inscripción para los cursos de un docente.
        /// </summary>
        /// <returns>PartialView: /Docente/_SolicitudesPendientes</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult _SolicitudesPendientes(int cantidadRegistros)
        {
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var solicitudes =
                from m_d in mDb.mensaje_x_destinatario
                join m in mDb.mensaje on m_d.mensaje equals m.id
                join c in mDb.curso on m.referencia equals c.id
                join u in mDb.usuario on m.emisor_mensaje equals u.id
                where m_d.destinatario == idDocente &&
                        m.tipo_mensaje1.nombre == "Solicitud" &&
                        (m.estado_mensaje1.nombre == "Pendiente" || m.estado_mensaje1.nombre == "Notificado") 
                select new
                {
                    Id = m.id,
                    Alumno = u.mail,
                    Curso = c.nombre,
                    TipoSolicitud = m.tipo_solicitud
                };

            ViewBag.solicitudes = solicitudes.ToList();
            return PartialView();
            //return null;
        }

        /// <summary>
        /// Crea una vista parcial con el listado de los cursos del alumno.
        /// </summary>
        /// <returns>PartialView: /Alumno/_Cursos</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult _CursosDocente()
        {
            //recupero el ID del usuario de la sesión
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<curso> cursos = mCursoController.GetCursosDocente(idDocente);
            ViewBag.Cursos_DefaultMessage = "En estos momentos no dispones de un curso a tu cargo.";

            return PartialView(cursos);
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult _InstitucionesDocente()
        {
            //recupero el ID del usuario de la sesión
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<institucion> instituciones = mInstitucionController.GetInstitucionesDocente(idDocente);
            ViewBag.Cursos_DefaultMessage = "En estos momentos no te encuentras inscripto a ninguna institución.";

            return PartialView(instituciones);
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult _ActividadesDocente()
        {
            //recupero el ID del usuario de la sesión
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            List<actividad> actividades = mActividadController.GetActividadesDocente(idDocente);
            ViewBag.Cursos_DefaultMessage = "En estos momentos no tienes ninguna actividad.";

            return PartialView(actividades);
        }


        #endregion

        #region GET
        [Authorize(Roles = "Docente, Administrador")] 
        public List<usuario> getDocentesPorInstitucion(List<int> idInstituciones)
        {
            List<usuario> listaDocentes = new List<usuario>();
            
            if (idInstituciones != null)
            {
                 var idDocentes = (from dxi in mDb.docente_x_institucion
                                    where idInstituciones.Contains(dxi.institucion.Value)
                                    select dxi.docente).Distinct();

                var docentes = from d in mDb.usuario
                                where idDocentes.Contains(d.id)
                                select d;

                listaDocentes = docentes.ToList();
            }

            return listaDocentes;
        }

        #endregion



        #region METODOS DE SOPORTE

        /// <summary>
        /// Recupera el ID de un docente por medio de su dirección de e-mail.
        /// </summary>
        /// <param name="mail">E-Mail del docente.</param>
        /// <returns>ID del docente.</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public int ObtenerIdDocente(String mail)
        {
            var docente_db =
                from d in mDb.usuario
                where d.mail == mail
                select d;
            return docente_db.Single().id;
        }

        /// <summary>
        /// Consulta por todas las especialidad disponible en la base de datos por medio de Ajax.
        /// </summary>
        /// <returns>Devuelve un objeto jSon con el listado de especialidades.</returns>
        public JsonResult GetEspecialidades()
        {
            var especialidades =
                from e in mDb.especialidad
                select e;

            JsonResult jSon = new JsonResult { Data = new SelectList(especialidades.ToList(), "id", "nombre") };
            jSon.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jSon;
        }

        /// <summary>
        /// Agrega una nueva especialidad a la base de datos por medio de Ajax, verificando primero
        /// que no exista en una especialidad con el mismo nombre. Ya sea porque se agregue la especialidad
        /// o ya exista una con el mismo nombre, se devuelve su ID y, -1 en caso de error.
        /// </summary>
        /// <param name="nombre_especialidad">Es el nombre con que se guardará la especialidad</param>
        /// <returns>
        /// Retorna un objecto jSon con el siguiente atributo:
        ///     - Index: Int, es el Id con el que se guardo la especialidad. Por cualquier error, 
        ///         se devuelve -1.
        /// </returns>
        public JsonResult NuevaEspecialidad(string nombre_especialidad)
        {
            int index = -1;

            // Verifico que se hayan recibo bien los datos del Json
            if (!string.IsNullOrEmpty(nombre_especialidad))
            {
                especialidad ret = mDb.especialidad.SingleOrDefault(m => m.nombre.Equals(nombre_especialidad));

                bool success = true;
                if (ret == null)
                {
                    // Si no existe una especialidad con ese nombre, la creo
                    ret = new especialidad();
                    ret.nombre = nombre_especialidad;
                    mDb.especialidad.AddObject(ret);

                    // Si se guardo la especialidad, success es true.
                    success = (mDb.SaveChanges() > 0);
                }

                // Si se guardo o ya existia una especialidad con ese nombre, se devuelve el Id.
                // Por cualquier tipo de error ocurrido, se devuelve -1.
                index = (success) ? ret.id : -1;
            }

            JsonResult jSon = new JsonResult { Data = new { Index = index } };
            jSon.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jSon;
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public JsonResult GetCurso(int idCurso)
        {
            var curso = mDb.curso.Single(c => c.id == idCurso);

            JsonResult jSon = new JsonResult
            {
                Data = new
                {
                    Nombre = curso.nombre,
                    Ano = curso.ano,
                    Division = curso.division,
                    Turno = curso.turno1.nombre,
                    Nivel = curso.nivel1.nombre,
                    Institucion = curso.institucion1.nombre,
                    Descripcion = curso.descripcion,
                    Publico = (curso.es_publico.Value) ? "Curso Público" : "Curso Privado"
                }
            };
            jSon.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jSon;
        }

        /// <summary>
        /// Cierro la sesion del docente.
        /// </summary>
        /// <returns>Devuelve la vista Index del home o un mensaje en caso de error.</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult CerrarSesion()
        {
            LoginController login = new LoginController();
            return login.CerrarSesion(ControllerContext);
        }

        #endregion

        #region AUTOCOMPLETE 

        /// <summary>
        /// Recupera las actividades que pertenezcan a la institucion pasada por parámetro. 
        /// </summary>
        /// <param name="parametro">texto ingresado hasta el momento en el input de autocomplete</param>
        /// <returns>Devuelve un Json con las primeras 5 actividades que cumplen con esa condicion.</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public JsonResult Autocomplete_Alumno(string parametro)
        {
            //recupero el ID del usuario de la sesión
            int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            var alumnos =
                from alumno in mDb.alumno_x_curso
                where
                    alumno.curso1.docente == idUsuario &&
                    (alumno.usuario.apellido.Contains(parametro) || alumno.usuario.nombre.Contains(parametro) || alumno.usuario.mail.Contains(parametro))
                select new
                {
                    Id = alumno.usuario.id,
                    Value = string.Concat(alumno.usuario.apellido, ", ", alumno.usuario.nombre),
                    Label = string.Concat(alumno.usuario.apellido, ", ", alumno.usuario.nombre)
                };

            return Json(alumnos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Recupera los cursos que pertenezcan a la institucion pasada por parámetro. 
        /// </summary>
        /// <param name="parametro">texto ingresado hasta el momento en el input de autocomplete</param>
        /// <returns>Devuelve un Json con las primeras 5 cursos que cumplen con esa condicion.</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public JsonResult Autocomplete_NombreActividad(string parametro)
        {
            //recupero el ID del usuario de la sesión
            int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            var actividades =
                from act in mDb.actividad
                where
                    act.docente == idUsuario &&
                    act.nombre.Contains(parametro)
                select new
                {
                    Id = act.id,
                    Value = act.nombre,
                    Label = act.nombre
                };

            return Json(actividades.Take(5), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Recupera los cursos que pertenezcan a la institucion pasada por parámetro. 
        /// </summary>
        /// <param name="parametro">texto ingresado hasta el momento en el input de autocomplete</param>
        /// <returns>Devuelve un Json con las primeras 5 cursos que cumplen con esa condicion.</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public JsonResult Autocomplete_NombreInstitucion(string parametro)
        {
            //recupero el ID del usuario de la sesión
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var cursos =
                from c in mDb.curso
                where c.usuario.id == idDocente && c.institucion1.nombre.Contains(parametro)
                select new
                {
                    Value = c.institucion1.nombre,
                    Label = c.institucion1.nombre,
                    Id = c.institucion1.id
                };

            return Json(cursos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Recupera los cursos que contengan en su nombre el "filtro" pasado por parámetro. 
        /// </summary>
        /// <param name="parametro">texto ingresado hasta el momento en el input de autocomplete</param>
        /// <returns>Devuelve un Json con los primeros 5 cursos que cumplen con esa condicion.</returns>
        [Authorize(Roles = "Docente, Administrador")] 
        public JsonResult Autocomplete_NombreCurso(string parametro)
        {
            //recupero el ID del usuario de la sesión
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var cursos =
                from c in mDb.curso
                where c.usuario.id == idDocente && c.nombre.Contains(parametro)
                select new
                {
                    Value = c.nombre,
                    Label = c.nombre,
                    Id = c.id
                };

            return Json(cursos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion



        [HttpPost]
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult getCursos()
        {
            Int32 id_docente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var cursos =
                from c in mDb.curso
                where c.docente == id_docente && c.estado == (int) EstadoCurso.Alta
                select new { Value = c.nombre, Label = c.nombre, Id = c.id };

            return Json(cursos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult getAlumnos()
        {
            Int32 id_docente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var alumnos =
                from a in mDb.usuario
                from ac in mDb.alumno_x_curso
                where ac.alumno == a.id
                    && ac.curso1.docente == id_docente && ac.curso1.estado == (int) EstadoCurso.Alta
                select new { Value = a.nombre + " " + a.apellido, Label = a.nombre + " " + a.apellido, Id = a.id };

            return Json(alumnos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "Docente, Administrador")]
        public ActionResult getAlumnosCurso(int idCurso)
        {
            Int32 id_docente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            if (idCurso != 0)
            {
                var alumnos =
                from a in mDb.usuario
                from ac in mDb.alumno_x_curso
                where ac.alumno == a.id
                    && ac.curso1.docente == id_docente && ac.curso1.estado == (int)EstadoCurso.Alta && ac.curso == idCurso
                select new { Value = a.nombre + " " + a.apellido, Label = a.nombre + " " + a.apellido, Id = a.id };

                return Json(alumnos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var alumnos =
                                from a in mDb.usuario
                                from ac in mDb.alumno_x_curso
                                where ac.alumno == a.id
                                    && ac.curso1.docente == id_docente && ac.curso1.estado == (int)EstadoCurso.Alta
                                select new { Value = a.nombre + " " + a.apellido, Label = a.nombre + " " + a.apellido, Id = a.id };

                return Json(alumnos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Docente, Administrador")] 
        public ActionResult getActividades()
        {
            Int32 id_docente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var actividades =
                from a in mDb.actividad
                from ac in mDb.actividad_x_curso
                where ac.actividad == a.id
                    && ac.curso1.docente == id_docente && ac.curso1.estado == (int) EstadoCurso.Alta
                select new { Value = a.nombre, Label = a.nombre, Id = a.id };

            return Json(actividades.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public bool desvincularCurso(int idCurso)
        {
            //enviamos la notificacion
            Int32 usuarioLogeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var curso = mDb.curso.Single(x => x.id == idCurso);
            var docente = mDb.usuario.Single(x => x.id == usuarioLogeado);
            InstitucionController cInstitucion = new InstitucionController(ControllerContext, mDb);
            String mensaje = "El docente '" + docente.mail + "' ha decidido dejar de dirigir el curso '" + curso.nombre +"' de la institución '" + curso.institucion1.nombre + "'. Si usted considera que esto es un error, por favor responda este correo o escriba un mensaje al usuario " + docente.mail ;
            cInstitucion.enviarNotificacion(usuarioLogeado, (int) curso.institucion1.administrador, "<DESVINCULACION>", curso.id, mensaje, "El docente " + docente.mail + " ha decidido desvincularse del curso " + curso.nombre);
            //modificamos el curso para que no tenga curso
            curso.docente = null;

            if(mDb.SaveChanges() > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        [Authorize(Roles = "Docente, Administrador")] 
        public bool desvincularInstitucion(int idInstitucion)
        {
            Int32 usuarioLogeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var docente = mDb.usuario.Single(x => x.id == usuarioLogeado);
            var institucion = mDb.institucion.Single(x => x.id == idInstitucion);
            String cursosDesvinculados = "";
            String separador = "";

            //recorro los cursos en cuestion y les voy sacando el docente y guardando su nombre para enviarlos
            var cursos =
                from c in mDb.curso
                where c.institucion == idInstitucion && c.docente == usuarioLogeado
                select c;

            foreach (curso cu in cursos)
            {
                cu.docente = null;
                cursosDesvinculados = cursosDesvinculados + separador +  cu.nombre;
                separador = ", ";
            }
            //borro la asignacion del docente con la institucion
            var docenteInstitucion = mDb.docente_x_institucion.Single(x => x.docente == usuarioLogeado && x.institucion == idInstitucion);
            mDb.docente_x_institucion.DeleteObject(docenteInstitucion);

            //mando la notificacion correspondiente
            InstitucionController cInstitucion = new InstitucionController(ControllerContext, mDb);
            String mensaje = "El docente '" + docente.mail + "' ha decidido dejar de participar en la institución '" + institucion.nombre + "' Esto implica que el docente dejará de dirigir los cursos '"+ cursosDesvinculados +"'. Si usted considera que esto es un error, por favor responda este correo o escriba un mensaje al usuario  " + docente.mail ;
            cInstitucion.enviarNotificacion(usuarioLogeado, (int) institucion.administrador, "<DESVINCULACION>", institucion.id, mensaje, "El docente " + docente.mail + " ha decidido desvincularse de la institución " + institucion.nombre);


            if (mDb.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    
    }
}