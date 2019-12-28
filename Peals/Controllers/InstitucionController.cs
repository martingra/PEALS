using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Peals.Models;

namespace Peals.Controllers
{
    public class InstitucionController : Controller
    {
        private pealsEntities mDb = new pealsEntities();
        private DomicilioController mDomicilioController = new DomicilioController();
        private InformacionController mInformacionController = new InformacionController();
        private CursoController mCursoController = new CursoController();

        #region SET

        public void setModelo(pealsEntities modelo)
        {
            mDb = modelo;
        }


        #endregion


        public InstitucionController()
        {
        }

        public InstitucionController(ControllerContext cc, pealsEntities pe)
        {
            ControllerContext = cc;
            mDb = pe;
        }

        #region VIEWS

        /// <summary>
        /// Prepara la página principal de la institucion como una PartialView, cargando los 
        /// cursos y los docentes de la misma.
        /// </summary>
        /// <param name="idInstitucion">id de la institucion</param>
        /// <returns>PartialView: Institucion/Index</returns>
        public ActionResult Index(int idInstitucion)
        {
            ViewBag.IDInstitucion = idInstitucion;
            ViewBag.Docentes = mDb.docente_x_institucion.Where(d => d.institucion == idInstitucion && d.usuario.tipo_usuario == (int)TipoDeUsuario.Docente).ToList();

            ViewBag.turno = new SelectList(mDb.turno.ToList(), "id", "nombre");
            ViewBag.nivel = new SelectList(mDb.nivel.ToList(), "id", "nombre");

            // TODO: cambiar el id de la institucion por el que viene en la URL
            return PartialView();
        }

        /// <summary>
        /// Prepara la vista para crear una nueva institución.
        /// </summary>
        /// <returns>GET: Institucion/NuevaInstitucion</returns>
        /// <see cref="Informacion/AgregarInformacion"/>
        public ActionResult NuevaInstitucion()
        {
            var paises =
                from p in mDb.pais
                select p;

            ViewData["pais"] = new SelectList(paises.ToList(), "id", "nombre");
            ViewData["provincia"] = new SelectList(new[] { "" });
            ViewData["localidad"] = new SelectList(new[] { "" });

            return View();
        }

        /// <summary>
        /// Prepara la vista para poder realizar la edición de datos de la institución.
        /// </summary>
        /// <param name="idInstitucion"id de la institución></param>
        /// <returns>GET: Institucion/EditarInstitucion</returns>
        public ActionResult EditarInstitucion(int idInstitucion)
        {
            institucion institucion = mDb.institucion.Single(i => i.id == idInstitucion);
            //los datos de la informacion se manejan en el partial view de informacion! :)

            ViewBag.IDInstitucion = idInstitucion;
            ViewBag.pais = new SelectList(mDb.pais, "id", "nombre", institucion.localidad1.provincia1.pais);

            SelectList provincias = mDomicilioController.GetSelectListProvinciasPorPais(institucion.localidad1.provincia1.pais1.id, institucion.localidad1.provincia1.id);
            SelectList localidades = mDomicilioController.GetSelectListLocalidadesPorProvincia(institucion.localidad1.provincia1.id, institucion.localidad1.id);

            ViewBag.provincia = provincias;
            ViewBag.localidad = localidades;

            return View(institucion);
        }

        /// <summary>
        /// A definir
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public ActionResult EliminarInstitucion(int idInstitucion)
        {
            // recupero el id del usuario logueado.
            int idAdmin = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            ViewBag.institucion = mDb.institucion.Single(x => x.id == idInstitucion);

            return View(mDb.institucion.Where(ins => ins.administrador == idAdmin && ins.id != idInstitucion).ToList());
        }

        #endregion

        #region ABM

        /// <summary>
        /// Registro a la nueva institución en la bd
        /// </summary>
        /// <param name="institucion">Institución a registrar.</param>
        /// <param name="info">Información a registrar.</param>
        /// <param name="imagen">Imagen cargada en la información.</param>
        /// <param name="video">Video cargado en la información.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NuevaInstitucion(institucion institucion, informacion info, HttpPostedFileBase imagen, HttpPostedFileBase video)
        {
            try
            {
                institucion.administrador = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

                int idInformación = mInformacionController.GuardarInformacion(info, imagen, video, ControllerContext);
                if (idInformación != -1) institucion.informacion = idInformación;
                institucion.fecha_alta = DateTime.Now;

                mDb.institucion.AddObject(institucion);
                if (mDb.SaveChanges() > 0)
                    return RedirectToAction("Index", "Administrador");
            }
            catch { }
            // en caso de erro, agrego un mensaje al model y vuelvo a la vista.
            ModelState.AddModelError("ErrorRegistrar", "Ha ocurrido un error mientras se intentaba registrar los datos. Por favor, intentelo de nuevo más tarde.");
            return View();
        }


        /// <summary>
        /// Guardo las modificaciones realizadas a los datos de la institución en la base de datos.
        /// </summary>
        /// <param name="idInstitucion">ID de la instición registrada en la BD</param>
        /// <param name="inst">Institucion modificada.</param>
        /// <param name="info">Información de la intitución modificada.</param>
        /// <param name="imagen">Imagen cargada en la información.</param>
        /// <param name="video">Video cargado en la información.</param>
        /// <returns>Si es exitoso, se redirecciona a "Administrador/Index"; de los contrario, se muestra el error.</returns>
        [HttpPost]
        public ActionResult EditarInstitucion(int idInstitucion, institucion inst, informacion info, HttpPostedFileBase imagen, HttpPostedFileBase video)
        {
            try
            {
                // recupero la institucion de la bd
                institucion instOriginal = mDb.institucion.Single(x => x.id == idInstitucion);

                // aplico los cambios
                instOriginal.telefono = inst.telefono;
                instOriginal.calle = inst.calle;
                instOriginal.altura_calle = inst.altura_calle;
                instOriginal.piso = inst.piso;
                instOriginal.departamento = inst.departamento;
                instOriginal.localidad = inst.localidad;
                instOriginal.informacion = mInformacionController.ModificarInformacion(instOriginal.informacion, info, imagen, video, ControllerContext);

                // registro los cambios en la bd.
                mDb.ObjectStateManager.ChangeObjectState(instOriginal, EntityState.Modified);
                if (mDb.SaveChanges() > 0)
                {
                    // si todo fue bien, vuelvo al "Index" de usuario.
                    return RedirectToAction("Index", "Administrador");
                }
            }
            catch { }

            // en caso de erro, agrego un mensaje al model y vuelvo a la vista.
            ModelState.AddModelError("ErrorModificar", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
            return View();
        }

        /// <summary>
        /// Elimina una institución y todas sus dependencias de la base de datos exportando, si así se desea,
        /// los datos a una neuva institución.
        /// </summary>
        /// <param name="idInstitucion">Id de la instutución que se va a eliminar.</param>
        /// <param name="datos">Datos a exportar.</param>
        /// <returns>
        /// Si el resultado es exitoso, se redirecciona  a la página principal del Administrador, de los contrario se presenta el 
        /// error en pantalla.
        /// </returns>
        /// <remarks>El parámetro "datos" esta serializado por medio de la función "JSON.stringify" de javascript.</remarks>
        [HttpPost]
        public bool EliminarInstitucion(int idInstitucion, int idInstitucionNueva)
        {
            try
            {
                // recupero los datos de la institucion de la bd.
                institucion inst = mDb.institucion.Single(x => x.id == idInstitucion);
                if (idInstitucionNueva != 0)
                {
                    //para cada curso de la institucion a borrar, lo paso a la nueva institucion
                    List<curso> cursosMoviendo = mDb.curso.Where(x => x.institucion1.id == idInstitucion).ToList();

                    foreach (curso cur in cursosMoviendo)
                    {
                        cur.institucion = idInstitucionNueva;
                        mDb.ObjectStateManager.ChangeObjectState(cur, EntityState.Modified);
                    }

                    List<docente_x_institucion> docentes = mDb.docente_x_institucion.Where(x => x.institucion == idInstitucion).ToList();

                    foreach (docente_x_institucion docInst in docentes)
                    {
                        int? idDocente = docInst.docente;

                        int existe = mDb.docente_x_institucion.Where(x => x.docente == idDocente && x.institucion == idInstitucionNueva).ToList().Count;

                        if (existe == 0)
                        {
                            docInst.institucion = idInstitucionNueva;
                            mDb.ObjectStateManager.ChangeObjectState(docInst, EntityState.Modified);
                        }
                    }
                }
                else
                {
                    List<curso> cursosMoviendo = mDb.curso.Where(x => x.institucion1.id == idInstitucion).ToList();

                    foreach (curso cur in cursosMoviendo)
                    {
                        cur.estado = (int)EstadoCurso.Baja;
                        cur.institucion = null;
                        mDb.ObjectStateManager.ChangeObjectState(cur, EntityState.Modified);
                    }

                    List<docente_x_institucion> docentes = mDb.docente_x_institucion.Where(x => x.institucion == idInstitucion).ToList();

                    foreach (docente_x_institucion docInst in docentes)
                    {
                        mDb.docente_x_institucion.DeleteObject(docInst);
                    }
                }


                // saca a los docentes y a los alumnos de la institución.
                if (inst.docente_x_institucion != null) inst.docente_x_institucion.ToList().ForEach(d => { mDb.DeleteObject(d); });
                if (inst.alumno_x_institucion != null) inst.alumno_x_institucion.ToList().ForEach(a => { mDb.DeleteObject(a); });

                // saco a los alumnos inscriptos en los cursos de la institución y elimino esos cursos.
                if (inst.curso != null)
                {
                    inst.curso.ToList().ForEach(c =>
                    {
                        mDb.alumno_x_curso.Where(x => x.curso == c.id).ToList().ForEach(ac => { mDb.DeleteObject(ac); });
                        mDb.DeleteObject(c);
                    });
                }

                //elimino los diac si los hubiera
                List<diac> diacs = mDb.diac.Where(x => x.institucion == idInstitucion).ToList();
                foreach (diac diac in diacs)
                {
                    List<item> items = mDb.item.Where(x => x.diac == diac.id).ToList();
                    foreach (item item in items)
                    {
                        List<llenadoseguimiento> llenadosSeguimiento = mDb.llenadoseguimiento.Where(x => x.diac == diac.id).ToList();
                        foreach (llenadoseguimiento ls in llenadosSeguimiento)
                        {
                            List<llenadoseguimientodetalle> llenadosSeguimientoDetalle = mDb.llenadoseguimientodetalle.Where(x => x.llenadoseguimiento == ls.id).ToList();
                            foreach (llenadoseguimientodetalle lsd in llenadosSeguimientoDetalle)
                            {
                                mDb.llenadoseguimientodetalle.DeleteObject(lsd);
                            }
                            mDb.llenadoseguimiento.DeleteObject(ls);
                        }

                        List<opcion> opciones = mDb.opcion.Where(x => x.item == item.id).ToList();
                        foreach (opcion opc in opciones)
                        {
                            mDb.opcion.DeleteObject(opc);
                        }

                        mDb.item.DeleteObject(item);
                    }
                    mDb.diac.DeleteObject(diac);
                }

                // elimino la información y la institución de la bd.
                if (inst.informacion.HasValue) mDb.DeleteObject(inst.informacion1);
                mDb.DeleteObject(inst);

                List<historial_actividad> historialesActividad = mDb.historial_actividad.Where(x => x.institucion == idInstitucion).ToList();
                foreach (historial_actividad ha in historialesActividad)
                {
                    ha.institucion = null;
                    mDb.ObjectStateManager.ChangeObjectState(ha, EntityState.Modified);
                    //mDb.historial_actividad.DeleteObject(ha);
                }

                List<recurso_compartido> recursosCompartidos = mDb.recurso_compartido.Where(x => x.institucion == idInstitucion).ToList();
                foreach (recurso_compartido rc in recursosCompartidos)
                {
                    mDb.recurso_compartido.DeleteObject(rc);
                }

                // aplico los cambios en la base de datos.
                if (mDb.SaveChanges() > 0)
                {
                    ControllerContext.HttpContext.Session["institucion"] = null;
                    return true;
                }
            }
            catch (Exception e)
            {
            }

            // en caso de error, devuelvo false;
            return false;
        }


        //[HttpPost]
        //public bool EliminarInstitucion(int idInstitucion, string datos = null)
        //{
        //    try
        //    {
        //        if (datos != null)
        //        {
        //            // recupero los datos que se van a exportar.
        //            JavaScriptSerializer serializer = new JavaScriptSerializer();
        //            paqueteExportación[] paquetes = (paqueteExportación[])serializer.Deserialize(datos, typeof(paqueteExportación[]));

        //            foreach (paqueteExportación paquete in paquetes)
        //            {
        //                // actualizo los datos de lo cursos.
        //                var cursos = mDb.curso.Where(x => paquete.idCursos.Contains(x.id));
        //                foreach (curso c in cursos)
        //                {
        //                    c.institucion = paquete.idInstitucion;
        //                    mDb.ObjectStateManager.ChangeObjectState(c, EntityState.Modified);
        //                }

        //                // actualizo los datos de los docentes.
        //                var docentes = mDb.docente_x_institucion.Where(x => paquete.idDocentes.Contains(x.docente.Value));
        //                foreach (docente_x_institucion d in docentes)
        //                {
        //                    d.institucion = paquete.idInstitucion;
        //                    mDb.ObjectStateManager.ChangeObjectState(d, EntityState.Modified);
        //                }
        //            }
        //        }

        //        // recupero los datos de la institucion de la bd.
        //        institucion inst = mDb.institucion.Single(x => x.id == idInstitucion);

        //        // saca a los docentes y a los alumnos de la institución.
        //        if (inst.docente_x_institucion != null) inst.docente_x_institucion.ToList().ForEach(d => { mDb.DeleteObject(d); });
        //        if (inst.alumno_x_institucion != null) inst.alumno_x_institucion.ToList().ForEach(a => { mDb.DeleteObject(a); });

        //        // saco a los alumnos inscriptos en los cursos de la institución y elimino esos cursos.
        //        if (inst.curso != null)
        //        {
        //            inst.curso.ToList().ForEach(c =>
        //            {
        //                mDb.alumno_x_curso.Where(x => x.curso == c.id).ToList().ForEach(ac => { mDb.DeleteObject(ac); });
        //                mDb.DeleteObject(c);
        //            });
        //        }

        //        // elimino la información y la institución de la bd.
        //        if (inst.informacion.HasValue) mDb.DeleteObject(inst.informacion1);
        //        mDb.DeleteObject(inst);

        //        // aplico los cambios en la base de datos.
        //        if (mDb.SaveChanges() > 0)
        //            return true;
        //    }
        //    catch { }

        //    // en caso de error, devuelvo false;
        //    return false;
        //}

        #endregion

        /// <summary>
        /// Clase auxiliar que contiene la información que se va a exportar a otra institución.
        /// </summary>
        public class paqueteExportación
        {
            public int idInstitucion; // id de la nueva institución.
            public int[] idCursos;    // cursos a exportar.
            public int[] idDocentes;  // docentes a exportar.
        }


        #region BORRAR INSCRIPCION INSTITUCIONES

        /// <summary>
        /// Saca a un docente del curso pasado por parámetro y refresca los datos de los cursos.
        /// </summary>
        /// <param name="idInstitucion">ID de la institución a la cual pertenecen los cursos.</param>
        /// <param name="idCursos">ID de los cursos</param>
        /// <returns>Devuelve los Cursos con los datos actualizados y Null si ocurrio algún error en el procedimiento.</returns>
        /// <remarks>El parámetro "idCursos" esta serializado por medio de la función "JSON.stringify" de javascript.</remarks>
        public ActionResult SacarDocenteDeCurso(int idInstitucion, string idCursos)
        {
            // deserializo los cursos pasados por parámetros como un vector de enteros que contendra los ids de los cursos.
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            int[] cursos = (int[])serializer.Deserialize(idCursos, typeof(int[]));

            foreach (int id in cursos)
            {
                // recupero el curso de la bd y actualizo los datos.
                var curso = mDb.curso.Single(x => x.id == id);
                var docenteDesasignado = (int)curso.docente;
                curso.docente = null;
                mDb.ObjectStateManager.ChangeObjectState(curso, EntityState.Modified);

                //enviamos notificacion al docente de que le sacamos el curso
                var admin = mDb.usuario.Single(x => x.id == curso.institucion1.administrador);
                string msjNotificacion = "El Administrador de la institución " + curso.institucion1.nombre + " ha decidido que usted deje de dirigir el curso " + curso.nombre + ". Si usted considera que esto es un error, contactese con el administrador al correo " + admin.mail;
                string titulo = "Notificación desasignación del curso " + curso.nombre;
                Int32 usuarioLogeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                enviarNotificacion(usuarioLogeado, docenteDesasignado, "[DESASIGNADO]", curso.id, msjNotificacion, titulo);

                //cambiamos estado de la solicitud original que le mandamos al docente para que no quede colgado en estado "esperando confirmacion"
                var solicitudAnterior = mDb.mensaje.Single(x => x.tipo_mensaje == 2 && x.tipo_solicitud == 4 && x.estado_mensaje == 3 && x.referencia == curso.id);
                solicitudAnterior.estado_mensaje = 4;
            };

            // aplico los cambios y actualizo los datos de la grilla.
            return (mDb.SaveChanges() > 0) ? RedirectToAction("_Cursos", new { idInstitucion = idInstitucion }) : null;
        }

        public void enviarNotificacion(Int32 idEmisor, Int32 idDestinatario, String prefijo, Int32 idReferencia, String mensajeTexto, String tituloMensaje)
        {
            mensaje mensaje = new mensaje();
            usuario usuario = mDb.usuario.First(x => x.id == idEmisor);

            mensaje.referencia = idReferencia;
            mensaje.emisor_mensaje = usuario.id;
            mensaje.tipo_mensaje = mDb.tipo_mensaje.First(x => x.nombre == "Notificacion").id;
            mensaje.mensaje1 = mensajeTexto;

            mensaje.titulo_mensaje = prefijo + " " + tituloMensaje;

            if (mensaje.titulo_mensaje.Length > 149)
            {
                mensaje.titulo_mensaje = mensaje.titulo_mensaje.Substring(0, 149);
            }

            mDb.mensaje.AddObject(mensaje);
            mensaje.fecha_mensaje = DateTime.Now;
            mensaje.estado_mensaje = mDb.estado_mensaje.First(x => x.nombre == "Pendiente").id;

            usuario = mDb.usuario.First(x => x.id == idDestinatario);

            mensaje_x_destinatario msj_dest = new mensaje_x_destinatario();
            msj_dest.usuario = usuario;
            msj_dest.mensaje = mensaje.id;
            mDb.mensaje_x_destinatario.AddObject(msj_dest);
        }

        /// <summary>
        /// Saca a un docente de la institución eliminando además los cursos de los cuales es responsable.
        /// </summary>
        /// <param name="idInstitucion">ID de la institución.</param>
        /// <param name="idDocente">ID del docente que se ve a sacar.</param>
        /// <returns>Si todo va bien, se vuelve a /Administrador/Index</returns>
        /// <!-- IDEA --> Se podria agregagar un mensaje para el docente.
        public bool SacarDocenteDeInstitucion(int idInstitucion, int idDocente)
        {
            // saco al docente de los cursos de la institucion.
            var cursos = mDb.curso.Where(x => x.institucion == idInstitucion && x.docente == idDocente);
            foreach (var curso in cursos)
            {
                curso.docente = null;
                mDb.ObjectStateManager.ChangeObjectState(curso, EntityState.Modified);
            }

            // saco al docente de la instutción
            var temp = mDb.docente_x_institucion.Single(x => x.institucion == idInstitucion && x.docente == idDocente);
            mDb.DeleteObject(temp);

            //enviamos la notificación
            var institucion = mDb.institucion.Single(x => x.id == idInstitucion);
            var admin = mDb.usuario.Single(x => x.id == institucion.administrador);
            string msjNotificacion = "El Administrador de la institución " + institucion.nombre + " ha decidido que usted deje de participar de la institución. Si usted considera que esto es un error, contactese con el administrador al correo " + admin.mail;
            string titulo = "Notificación desasignación de la institución " + institucion.nombre;
            Int32 usuarioLogeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            enviarNotificacion(usuarioLogeado, idDocente, "[DESASIGNADO]", idInstitucion, msjNotificacion, titulo);

            //aplico los cambios en la base de datos.
            return (mDb.SaveChanges() > 0);
        }

        /// <summary>
        /// Elimina un curso de la institución y refresca los datos de la grilla.
        /// </summary>
        /// <param name="idInstitucion">ID de la institución a la cual pertenecen los cursos.</param>
        /// <param name="idCursos">ID de los cursos</param>
        /// <returns>Devuelve los Cursos con los datos actualizados y Null si ocurrio algún error en el procedimiento.</returns>
        /// <remarks>El parámetro "idCursos" esta serializado por medio de la función "JSON.stringify" de javascript.</remarks>
        public ActionResult EliminarCursos(int idInstitucion, string idCursos)
        {
            // deserializo los cursos pasados por parámetros como un vector de enteros que contendra los ids de los cursos.
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            int[] cursos = (int[])serializer.Deserialize(idCursos, typeof(int[]));

            // elimino los cursos y, si todo fue bien, actualizo los datos de la grilla.
            mCursoController = new CursoController(ControllerContext);
            bool cursosEliminados = mCursoController.EliminarCursos(cursos);
            return (cursosEliminados) ? RedirectToAction("_Cursos", new { idInstitucion = idInstitucion }) : null;
        }

        public void BorrarInscripcionInstitucionesAlumno(int idAlumno)
        {
            List<alumno_x_institucion> inscripciones = this.GetInscripcionesAlumno(idAlumno);

            foreach (alumno_x_institucion axi in inscripciones)
            {
                mDb.alumno_x_institucion.DeleteObject(axi);
            }
        }

        public void BorrarInscripcionInstitucionesDocente(int idDocente)
        {
            List<docente_x_institucion> inscripciones = this.GetInscripcionesInstitucionDocente(idDocente);

            foreach (docente_x_institucion dxi in inscripciones)
            {
                mDb.docente_x_institucion.DeleteObject(dxi);
            }
        }
        #endregion

        public ActionResult AgregarDocente()
        {
            var docentes =
                from d in mDb.usuario
                join tipoUsuario in mDb.tipo_usuario on d.tipo_usuario equals tipoUsuario.id
                where tipoUsuario.nombre == "Docente"
                select d;

            return View(docentes.ToList());
        }

        #region GET INSTITUCIONES

        /// <summary>
        /// Metodo que se encarga de paginar cada 10 registros. Es llamado cada vez q se apreta la flecha
        /// de ver en la vista.
        /// </summary>
        /// <param name="inicio">representa la posicion en el resultado de la consulta a partir de la cual se empiezan a mostrar registros</param>
        /// <returns></returns>
        public ActionResult TodasLasInstituciones(int inicio, string searchCriteria = null, string buscar = null)
        {
            //obtengo todas las instituciones
            var instituciones =
            from i in mDb.institucion
            orderby i.nombre
            select i;

            // aplico el filtro a los datos.
            System.Collections.IEnumerable ret = instituciones.ToList();
            if (!string.IsNullOrEmpty(buscar))
            {
                switch (searchCriteria)
                {
                    case "Nombre":
                        ret = instituciones.ToList().Where(item => item.nombre.ToLower().Contains(buscar.ToLower()));
                        break;
                    case "Localidad":
                        ret = instituciones.ToList().Where(item => item.localidad1.nombre.ToLower().Contains(buscar.ToLower()));
                        break;
                    case "Provincia":
                        ret = instituciones.ToList().Where(item => item.localidad1.provincia1.nombre.ToLower().Contains(buscar.ToLower()));
                        break;
                    case "Pais":
                        ret = instituciones.ToList().Where(item => item.localidad1.provincia1.pais1.nombre.ToLower().Contains(buscar.ToLower()));
                        break;
                }

                //ViewData["searchValue"] = buscar;
                //ViewData["searchCriteria"] = searchCriteria;
            }
            //pagino
            List<institucion> list = new List<institucion>(ret.OfType<institucion>());
            int count = list.Count;

            ViewBag.count = count;
            ViewBag.desde = inicio;

            return View(list.Skip(inicio).Take(6).ToList());
        }

        /// <summary>
        /// Devuelve los cursos de un alumno pasado por parámetro.
        /// </summary>
        /// <param name="idUsuario">ID del alumno</param>
        /// <returns>Listado de los cursos del alumno.</returns>
        public List<institucion> GetInstitucionesAlumno(int idUsuario)
        {
            var instituciones =
              from i in mDb.institucion
              join axi in mDb.alumno_x_institucion on i.id equals axi.institucion
              where axi.alumno == idUsuario
              select i;

            List<institucion> listaInstituciones = instituciones.ToList();

            return listaInstituciones;
        }

        private List<alumno_x_institucion> GetInscripcionesAlumno(int idAlumno)
        {
            var inscripciones =
             from axi in mDb.alumno_x_institucion
             where axi.alumno == idAlumno
             select axi;

            List<alumno_x_institucion> listaInscripciones = inscripciones.ToList();

            return listaInscripciones;
        }

        private List<docente_x_institucion> GetInscripcionesInstitucionDocente(int idDocente)
        {
            var inscripciones =
                from dxi in mDb.docente_x_institucion
                where dxi.docente == idDocente
                select dxi;
            List<docente_x_institucion> listaInscripciones = inscripciones.ToList();
            return listaInscripciones;
        }

        /// <summary>
        /// Devuelve los cursos de un alumno pasado por parámetro.
        /// </summary>
        /// <param name="idUsuario">ID del alumno</param>
        /// <returns>Listado de los cursos del alumno.</returns>
        public List<institucion> GetInstitucionesDocente(int idUsuario)
        {
            var instituciones =
              from i in mDb.institucion
              join dxi in mDb.docente_x_institucion on i.id equals dxi.institucion
              where dxi.docente == idUsuario
              select i;

            List<institucion> listaInstituciones = instituciones.ToList();

            return listaInstituciones;
        }

        /// <summary>
        /// Devuelve las instituciones del administrador pasado por parámetro.
        /// </summary>
        /// <param name="idUsuario">ID del administrador</param>
        /// <returns>Listado de las instituciones del administrador.</returns>
        public List<institucion> GetInstitucionesAdministrador(int idUsuario)
        {
            var instituciones =
              from i in mDb.institucion
              where i.administrador == idUsuario
              select i;

            List<institucion> listaInstituciones = instituciones.ToList();

            return listaInstituciones;
        }

        #endregion

        #region PARTIAL VIEW

        /// <summary>
        /// Devuelve una vista parcial con un listado de todos los cursos pertenecientes a la institucion que están activos (estado != 3).
        /// </summary>
        /// <param name="idInstitucion">Es el id de la institución a la cual pertenecen los cursos.</param>
        /// <param name="criterioBusqueda">OPCIONAL - Criterio utilizado para filtrar los datos.</param>
        /// <param name="valorBusqueda">OPCIONAL - Valor utulizado para filtrar los datos.</param>
        /// <returns>PartialView: /Institucion/_Cursos</returns>
        public ActionResult _Cursos(int idInstitucion, int filasPorPagina = 10, string criterioBusqueda = null, string valorBusqueda = null)
        {
            var cursos =
               from c in mDb.curso
               from m in mDb.mensaje.Where(men => men.referencia == c.id && (men.estado_mensaje == 1 || men.estado_mensaje == 2 || men.estado_mensaje == 6) && men.titulo_mensaje.StartsWith("Solicitud del Administrador para que usted dirija el curso:")).DefaultIfEmpty()
               //join msj in mDb.mensaje on new { } equals new { } into pete
               //from petee in pete.DefaultIfEmpty()
               where c.institucion == idInstitucion && c.estado != (int)EstadoCurso.Baja
               select new
               {
                   Nombre = c.nombre,
                   Descripcion = c.descripcion,
                   Id = c.id,
                   IdTurno = c.turno,
                   Turno = c.turno1.nombre,
                   IdNivel = c.nivel,
                   Nivel = c.nivel1.nombre,
                   Ano = c.ano,
                   Division = c.division,
                   Docente = string.Concat(c.usuario.apellido, ", ", c.usuario.nombre),
                   Institucion = c.institucion1 == null ? "Pública" : c.institucion1.nombre,
                   Solicitud = m == null ? 0 : m.id
                   //Solicitud = (int?)(from m in mDb.mensaje
                   //                where m.titulo_mensaje.Contains("Solicitud del Administrador para que usted dirija el curso:") && m.referencia == c.id
                   //                select m.id).FirstOrDefault()
               };

            if (!string.IsNullOrEmpty(criterioBusqueda) && !string.IsNullOrEmpty(valorBusqueda))
            {
                switch (criterioBusqueda)
                {
                    case "Nombre":
                        cursos = cursos.Where(x => x.Nombre.ToUpper().Contains(valorBusqueda.ToUpper()));
                        break;
                    case "Docente":
                        cursos = cursos.Where(x => x.Docente.ToUpper().Contains(valorBusqueda.ToUpper()));
                        break;
                    case "Turno":
                        int idTurno = int.Parse(valorBusqueda);
                        cursos = cursos.Where(x => x.IdTurno == idTurno);
                        break;
                    case "Nivel":
                        int idNivel = int.Parse(valorBusqueda);
                        cursos = cursos.Where(x => x.IdNivel == idNivel);
                        break;
                }

                if (cursos.Count() == 0) ViewBag.Cursos_DefaultMessage = "No se encontraron cursos con \"" + valorBusqueda + "\" en el parámetro \"" + criterioBusqueda + "\"";
            }
            else
            {
                if (cursos.Count() == 0) ViewBag.Cursos_DefaultMessage = "No se encontraron cursos registrados en la institución";
            }

            int idUsrLogeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario usr = mDb.usuario.First(x => x.id == idUsrLogeado);

            if (usr.tipo_usuario1.nombre == "Alumno")
            {
                cursos = cursos.Where(x => x.Docente != null);
            }

            int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            ViewBag.esAdmin = mDb.usuario.First(x => x.id == idUsuario).tipo_usuario == (int)TipoDeUsuario.Administrador;
            ViewBag.cursosPorPagina = filasPorPagina;

            return PartialView(cursos.ToList());
        }


        /// <summary>
        /// Devuelve una vista parcial con un listado de los docentes pertenecientes a la institución.
        /// </summary>
        /// <param name="idInstitucion">Es el id de la institución a la cual pertenecen los docentes.</param>
        /// <param name="presentarComoLista">Es FALSE si los datos se presentan en un WebGrid y TRUE si se presentan en una lista></param>
        /// <param name="criterioBusqueda">OPCIONAL - Criterio utilizado para filtrar los datos.</param>
        /// <param name="valorBusqueda">OPCIONAL - Valor utulizado para filtrar los datos.</param>
        /// <returns>PartialView: /Institucion/_Docentes</returns>
        public ActionResult _Docentes(int idInstitucion, bool presentarComoLista = false, string criterioBusqueda = null, string valorBusqueda = null, int filasPorPagina = 10)
        {
            ViewBag.esLista = presentarComoLista;

            IQueryable<docente_x_institucion> docentes;
            switch (criterioBusqueda)
            {
                case "Nombre":
                    docentes = mDb.docente_x_institucion.Where(x => x.institucion == idInstitucion && string.Concat(x.usuario.apellido, ", ", x.usuario.nombre).ToUpper().Contains(valorBusqueda.ToUpper()));
                    break;
                case "Mail":
                    docentes = mDb.docente_x_institucion.Where(x => x.institucion == idInstitucion && x.usuario.mail.Contains(valorBusqueda));
                    break;
                case "Especiliadad":
                    docentes = mDb.docente_x_institucion.Where(x => x.institucion == idInstitucion && x.usuario.especialidad1.nombre.ToUpper().Contains(valorBusqueda.ToUpper()));
                    break;
                default:
                    docentes = mDb.docente_x_institucion.Where(x => x.institucion == idInstitucion);
                    break;
            }

            ViewBag.docentesPorPagina = filasPorPagina;

            var mensaje = "";
            if (valorBusqueda == null || criterioBusqueda == null)
            {
                mensaje = "No se encontraron docentes registrados en la institución.";
            }
            else
            {
                mensaje = "No se encontraron docentes con \"" + valorBusqueda + "\" en su \"" + criterioBusqueda + "\" registrados en la institución.";
            }

            if (docentes.Count() == 0) ViewBag.Docentes_DefaultMessage = mensaje;
            return PartialView("_Docentes", docentes.ToList());
        }

        public ActionResult PruebaVideo()
        {
            return View();
        }

        #endregion

        #region AUTOCOMPLETE

        /// <summary>
        /// Devuelve los nombres de las instituciones.
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public JsonResult AutocompletePorNombre(string parametro)
        {
            var instituciones =
                from i in mDb.institucion
                where i.nombre.Contains(parametro)
                select new
                {
                    i.nombre,
                    i.id
                };
            return Json(instituciones.Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Devuelve las localidades en las que hay una institucion.
        /// </summary>
        /// <param name="parametro">texto ingresado hasta el momento en el input de autocomplete</param>
        /// <returns></returns>
        public JsonResult AutocompletePorLocalidad(string parametro)
        {
            var instituciones =
               from i in mDb.institucion
               join l in mDb.localidad on i.localidad equals l.id
               join p in mDb.provincia on l.provincia equals p.id
               join pa in mDb.pais on p.pais equals pa.id
               where i.localidad1.nombre.Contains(parametro)
               select new
               {
                   localidad = i.localidad1.nombre,
                   label = i.localidad1.nombre + ", " + i.localidad1.provincia1.nombre + ", " + i.localidad1.provincia1.pais1.nombre,
                   id = l.id
               };
            return Json(instituciones.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Devuelve las provincias en las que hay una institucion.
        /// </summary>
        /// <param name="parametro">texto ingresado hasta el momento en el input de autocomplete</param>
        /// <returns></returns>
        public JsonResult AutocompletePorProvincia(string parametro)
        {
            var instituciones =
               from i in mDb.institucion
               join l in mDb.localidad on i.localidad equals l.id
               join p in mDb.provincia on l.provincia equals p.id
               join pa in mDb.pais on p.pais equals pa.id
               where i.localidad1.provincia1.nombre.Contains(parametro)
               select new
               {
                   provincia = i.localidad1.provincia1.nombre,
                   label = i.localidad1.provincia1.nombre + ", " + i.localidad1.provincia1.pais1.nombre,
                   id = l.id
               };
            return Json(instituciones.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Devuelve los paises en los que hay una institucion.
        /// </summary>
        /// <param name="parametro">texto ingresado hasta el momento en el input de autocomplete</param>
        /// <returns></returns>
        public JsonResult AutocompletePorPais(string parametro)
        {
            var instituciones =
              from i in mDb.institucion
              join l in mDb.localidad on i.localidad equals l.id
              join p in mDb.provincia on l.provincia equals p.id
              join pa in mDb.pais on p.pais equals pa.id
              where i.localidad1.provincia1.pais1.nombre.Contains(parametro)
              select new
              {
                  pais = i.localidad1.provincia1.pais1.nombre,
                  id = l.id
              };
            return Json(instituciones.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompletePorCursoNombre(string parametro, int idEntidad)
        {
            var cursos =
                from c in mDb.curso
                where c.institucion == idEntidad && c.nombre.ToUpper().Contains(parametro.ToUpper())
                select new { Value = c.nombre, Label = c.nombre, Id = c.id };

            return Json(cursos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompletePorCursoDocente(string parametro, int idEntidad)
        {
            var cursos =
               from c in mDb.curso
               where (c.usuario.apellido.ToUpper().Contains(parametro.ToUpper()) || c.usuario.nombre.ToUpper().Contains(parametro.ToUpper())) &&
                     c.usuario.tipo_usuario == (int)TipoDeUsuario.Docente &&
                     c.institucion == idEntidad
               select new
               {
                   Value = c.usuario.apellido + ", " + c.usuario.nombre,
                   Label = c.usuario.apellido + ", " + c.usuario.nombre,
                   Id = c.docente,
                   Tipo = c.usuario.tipo_usuario1.nombre
               };

            return Json(cursos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompletePorDocenteNombre(string parametro, int idEntidad)
        {
            var docentes =
               from di in mDb.docente_x_institucion
               where di.institucion == idEntidad &&
                     (di.usuario.apellido.ToUpper().Contains(parametro.ToUpper()) || di.usuario.nombre.ToUpper().Contains(parametro.ToUpper()))
               select new
               {
                   Value = di.usuario.apellido + ", " + di.usuario.nombre,
                   Label = di.usuario.apellido + ", " + di.usuario.nombre,
                   Id = di.docente,
                   Tipo = di.usuario.tipo_usuario1.nombre
               };

            return Json(docentes.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompletePorDocenteMail(string parametro, int idEntidad)
        {
            var docentes =
               from i in mDb.institucion
               from u in mDb.usuario
               from di in mDb.docente_x_institucion
               join tu in mDb.tipo_usuario on u.tipo_usuario equals tu.id
               where di.docente == u.id && di.institucion == i.id &&
                     u.mail.Contains(parametro) &&
                     tu.nombre == "Docente" &&
                     i.id == idEntidad
               select new
               {
                   Value = u.mail,
                   Label = u.mail,
                   Id = u.id,
                   Tipo = tu.nombre
               };

            return Json(docentes.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region BORRAR INSCRIPCION

        public void BorrarInscripcionDocentesInstituciones(List<int> idInstituciones)
        {
            List<docente_x_institucion> inscripciones = new List<docente_x_institucion>();

            inscripciones = this.getInscripcionesDocentesPorInstitucion(idInstituciones);

            foreach (docente_x_institucion dxi in inscripciones)
            {
                mDb.docente_x_institucion.DeleteObject(dxi);
            }
        }

        public List<docente_x_institucion> getInscripcionesDocentesPorInstitucion(List<int> idInstituciones)
        {
            var inscripcionesDocente = from dxi in mDb.docente_x_institucion
                                       where idInstituciones.Contains(dxi.institucion.Value)
                                       select dxi;

            return inscripcionesDocente.ToList();
        }

        public void BorrarInscripcionAlumnosInstituciones(List<int> idInstituciones)
        {
            List<alumno_x_institucion> inscripciones = new List<alumno_x_institucion>();

            inscripciones = this.getInscripcionesAlumnosPorInstitucion(idInstituciones);

            foreach (alumno_x_institucion axi in inscripciones)
            {
                mDb.alumno_x_institucion.DeleteObject(axi);
            }
        }

        public List<alumno_x_institucion> getInscripcionesAlumnosPorInstitucion(List<int> idInstituciones)
        {
            var inscripcionesAlumno = from axi in mDb.alumno_x_institucion
                                      where idInstituciones.Contains(axi.institucion.Value)
                                      select axi;
            return inscripcionesAlumno.ToList();
        }

        #endregion


        #region AJAX
        /// <summary>
        /// envia una solicitud por curso al docente correspondiente.
        /// </summary>
        /// <returns>true si se envian todas las solicitudes</returns>
        //public Boolean enviarSolCursosADocentes(String cursos, String mailDocente)
        [HttpGet]
        public ActionResult enviarSolCursosADocentes(String cursos, String mailDocente, String mensaje)
        {
            MensajeController cMensaje = new MensajeController();
            cMensaje.setModelo(mDb);
            Int32 emisor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            String titulo = "Solicitud del Administrador para que usted dirija el curso: ";
            curso oCurso;
            usuario docente = mDb.usuario.First(x => x.mail == mailDocente);

            String m_enviados = "";
            String m_noEnviados = "";
            String separador = "";

            foreach (String curso in cursos.Split('|'))
            {
                Int32 iCurso = Int32.Parse(curso);
                oCurso = mDb.curso.First(x => x.id == iCurso);
                if (cMensaje.NuevaSolicitud(emisor, mensaje, iCurso, titulo + oCurso.nombre, docente.id, (Int32)TipoSolicitud.asignarDocenteACurso))
                {
                    if (cMensaje.getModelo().SaveChanges() > 0)
                    {
                        m_enviados = m_enviados + separador + docente.mail + " - " + oCurso.nombre;
                    }
                    else
                    {
                        m_noEnviados = m_noEnviados + separador + docente.mail + " - " + oCurso.nombre;
                    }
                    separador = ",";
                }
                else
                {
                    m_noEnviados = m_noEnviados + docente.mail + " - " + oCurso.nombre;
                }
            }
            return RedirectToAction("informeEnvioMensaje", "Mensaje", new { enviados = m_enviados, noEnviados = m_noEnviados });
        }

        [HttpPost]
        public ActionResult getCursos(String idInstitucion)
        {
            Int32 id_institucion = Int32.Parse(idInstitucion);
            var cursos =
                from c in mDb.curso
                where c.institucion1.id == id_institucion
                select new { Value = c.nombre, Label = c.nombre, Id = c.id };

            return Json(cursos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult getAlumnosCurso(String idInstitucion, int idCurso)
        {
            Int32 id_institucion = Int32.Parse(idInstitucion);

            if (idCurso != 0)
            {
                var alumnos =
                    from a in mDb.usuario
                    from ai in mDb.alumno_x_institucion
                    from ac in mDb.alumno_x_curso
                    where ai.alumno == a.id
                        && ai.institucion1.id == id_institucion && ac.curso1.institucion == ai.institucion1.id && ac.alumno == a.id
                        && ac.curso1.id == idCurso
                    select new { Value = a.nombre + " " + a.apellido, Label = a.nombre + " " + a.apellido, Id = a.id };
                return Json(alumnos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                var alumnos =
                from a in mDb.usuario
                from ai in mDb.alumno_x_institucion
                where ai.alumno == a.id
                    && ai.institucion1.id == id_institucion
                select new { Value = a.nombre + " " + a.apellido, Label = a.nombre + " " + a.apellido, Id = a.id };
                return Json(alumnos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult getAlumnos(String idInstitucion)
        {
            Int32 id_institucion = Int32.Parse(idInstitucion);
            var alumnos =
                from a in mDb.usuario
                from ai in mDb.alumno_x_institucion
                where ai.alumno == a.id
                    && ai.institucion1.id == id_institucion
                select new { Value = a.nombre + " " + a.apellido, Label = a.nombre + " " + a.apellido, Id = a.id };

            return Json(alumnos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getActividades(String idInstitucion)
        {
            Int32 id_institucion = Int32.Parse(idInstitucion);
            var actividades =
                from a in mDb.actividad
                from ac in mDb.actividad_x_curso
                where ac.actividad == a.id
                    && ac.curso1.institucion1.id == id_institucion
                select new { Value = a.nombre, Label = a.nombre, Id = a.id };

            return Json(actividades.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getDocentes(String idInstitucion)
        {
            Int32 id_institucion = Int32.Parse(idInstitucion);
            var docentes =
                from d in mDb.usuario
                from di in mDb.docente_x_institucion
                where di.docente == d.id
                    && di.institucion == id_institucion
                select new { Value = d.nombre + " " + d.apellido, Label = d.nombre + " " + d.apellido, Id = d.id };

            return Json(docentes.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}