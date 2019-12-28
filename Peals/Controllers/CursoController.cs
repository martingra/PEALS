using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Peals.Models;
using System.Data;

namespace Peals.Controllers
{
    public class CursoController : Controller
    {
        private pealsEntities mDb = new pealsEntities();
        private ActividadController mActividadController = new ActividadController();

        public CursoController()
        {
        }

        public CursoController(ControllerContext cc)
        {
            ControllerContext = cc;
        }

        #region SET

        public void setModelo(pealsEntities modelo)
        {
            mDb = modelo;
        }

        #endregion

        public enum Filtros { TODOS, PRIVADOS, PUBLICOS };

        #region VIEWS


        [Authorize(Roles = "Administrador")]
        public ActionResult NuevoCurso(int idInstitucion)
        {
            var inst = mDb.institucion.SingleOrDefault(x => x.id == idInstitucion);

            ViewBag.idInstitucion = idInstitucion;
            ViewBag.nombreInstitucion = (inst != null) ? inst.nombre : "Pública";

            ViewData["turno"] = new SelectList(mDb.turno, "id", "nombre");
            ViewData["nivel"] = new SelectList(mDb.nivel, "id", "nombre");

            var plantelDocente =
                from di in mDb.docente_x_institucion
                where di.institucion == idInstitucion
                select new
                {
                    ID = di.docente,
                    Nombre = di.usuario.apellido + ", " + di.usuario.nombre,
                    Mail = di.usuario.mail,
                    Especialidad = (di.usuario.especialidad.HasValue) ? di.usuario.especialidad1.nombre : "Sin Especificar"
                };

            return View(plantelDocente.ToList());
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult EditarCurso(int idCurso)
        {
            var curso = mDb.curso.Single(x => x.id == idCurso);

            ViewBag.idCurso = idCurso;
            ViewBag.turno = new SelectList(mDb.turno, "id", "nombre", curso.turno);
            ViewBag.nivel = new SelectList(mDb.nivel, "id", "nombre", curso.nivel);

            ViewBag.nombreDocente = (curso.docente.HasValue) ? string.Format("{0}, {1}", curso.usuario.apellido, curso.usuario.nombre) : "";
            ViewBag.idDocente = (curso.docente.HasValue) ? curso.docente : -1;

            ViewBag.idInstitucion = curso.institucion;
            ViewBag.nombreInstitucion = (curso.institucion.HasValue) ? curso.institucion1.nombre : "Pública";

            return View(curso);
        }

        #endregion

        #region ABM

        [HttpPost]
        public ActionResult NuevoCurso(curso curso, int idInstitucion, int idDocente)
        {
            try
            {
                curso.institucion = idInstitucion;
                curso.estado = (int)EstadoCurso.Alta;
                //if (idDocente != -1) curso.docente = idDocente;

                mDb.curso.AddObject(curso);

                if (mDb.SaveChanges() > 0)
                {
                    if (idDocente != -1)
                    {
                        var docente = mDb.usuario.Single(x => x.id == idDocente);

                        string mail = docente.mail;
                        string mensaje = "Solicitud del administrador para que dirija el curso";
                        string cursoId = curso.id.ToString();
                        enviarSolCursosADocentes(cursoId, mail, mensaje);
                    }

                    return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception e)
            {
                mDb.DeleteObject(curso);
                mDb.SaveChanges();
                // en caso de erro, agrego un mensaje al model y vuelvo a la vista.
                ModelState.AddModelError("ErrorRegistrar", "Ha ocurrido un error mientras se intentaba registrar los datos. Por favor, intentelo de nuevo más tarde." + e.Message);
            }
            return View();
        }


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
        public ActionResult EditarCurso(curso curso, Int32 idCurso, Int32 idDocente)
        {
            try
            {
                // recupero el curso original y aplico los cambios
                var cursoOriginal = mDb.curso.Single(x => x.id == idCurso);
                cursoOriginal.nombre = curso.nombre;
                cursoOriginal.descripcion = curso.descripcion;
                cursoOriginal.turno = curso.turno;
                cursoOriginal.nivel = curso.nivel;
                cursoOriginal.ano = curso.ano;
                cursoOriginal.division = curso.division;
                if (!(idDocente == -1 || idDocente == null))
                {
                    cursoOriginal.docente = idDocente;
                }

                cursoOriginal.estado = (int)EstadoCurso.Alta;

                // registro los cambios en la bd
                mDb.ObjectStateManager.ChangeObjectState(cursoOriginal, EntityState.Modified);
                if (mDb.SaveChanges() > 0)
                {
                    // Vuelvo al index del Administrador.
                    return RedirectToAction("Index", "Administrador");
                }
            }
            catch { }

            // en caso de erro, agrego un mensaje al model y vuelvo a la vista.
            ModelState.AddModelError("ErrorModificar", "Ha ocurrido un error mientras se intentaba modificar sus datos. Por favor, intentelo de nuevo más tarde.");
            return View();
        }

        /// <summary>
        /// Elimina los cursos pasados por parámetro.
        /// </summary>
        /// <param name="idCurso">ID de los cursos a cerrar.</param>
        /// <returns>Devuelve TRUE si fue exitoso y FALSE en caso contrario.</returns>
        [Authorize(Roles = "Administrador")]
        public bool EliminarCursos(int[] idCurso)
        {
            foreach (int id in idCurso)
            {
                // recupero el curso de la BD y lo elimino.
                var curso = mDb.curso.Single(x => x.id == id);
                //mDb.DeleteObject(curso);
                curso.estado = (int)EstadoCurso.Baja;

                if (curso.docente != null)
                {
                    //enviamos la notificación
                    var institucion = mDb.institucion.Single(x => x.id == curso.institucion1.id);
                    var admin = mDb.usuario.Single(x => x.id == institucion.administrador);
                    string msjNotificacion = "El Administrador de la institución " + institucion.nombre + " ha decidido borrar el curso " + curso.nombre + ". Si usted considera que esto es un error, contactese con el administrador al correo " + admin.mail;
                    string titulo = "Notificación eliminación del curso " + curso.nombre + " de la institución " + institucion.nombre;
                    Int32 usuarioLogeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                    InstitucionController cInstitucion = new InstitucionController(ControllerContext, mDb);

                    cInstitucion.enviarNotificacion(usuarioLogeado, (int)curso.docente, "[ELIMINACIÓN]", curso.institucion1.id, msjNotificacion, titulo);
                }
            }

            // aplico los cambios.
            return (mDb.SaveChanges() > 0);
        }

        #endregion

        #region BORRAR INSCRIPCION CURSOS

        /// <summary>
        /// Borra la inscripcion del alumno a los cursos pasando el id del alumno por parametro
        /// </summary>
        /// <param name="idAlumno">Id del alumno.</param>
        public void BorrarInscripcionCursosAlumno(int idAlumno)
        {
            List<alumno_x_curso> inscripciones = this.GetInscripcionesAlumno(idAlumno);

            foreach (alumno_x_curso axc in inscripciones)
            {
                mDb.alumno_x_curso.DeleteObject(axc);
            }
        }

        [Authorize(Roles = "Administrador")]
        public void DarDeBajaCursosDocente(int idUsuario)
        {
            List<curso> cursos = this.GetCursosDocente(idUsuario);

            foreach (curso c in cursos)
            {
                c.estado = (int)EstadoCurso.Baja;
            }
        }

        //public void BorrarInscripcionCursosDocente(int idDocente)
        //{
        //    List<curso> cursos = this.GetCursosDocente(idDocente);

        //    foreach (curso c in cursos)
        //    {
        //        c.docente = null;
        //    }
        //}
        [Authorize(Roles = "Administrador")]
        public void DarBajaCursosYActividadesInstituciones(List<int> idInstituciones)
        {
            List<curso> cursos = this.getCursosPorInstitucion(idInstituciones);
            List<actividad> actividades = new List<actividad>();
            mActividadController.setModelo(mDb);
            foreach (curso c in cursos)
            {
                //busco todas las actividades que pertenecen a ese curso
                actividades = mActividadController.getActividadesCurso(c.id);
                //ahora que tengo las actividades tengo que eliminar las referencias en actividad por curso.
                this.borrarActividadesPorCurso(c.id);
                //borro los alumnos del curso.
                this.borrarAlumnosDelCurso(c.id);

                //ahora hago el tratamiento especifico para cada actividad
                foreach (actividad a in actividades)
                {
                    a.estado = (int)EstadoActividad.Baja;
                    mDb.ObjectStateManager.ChangeObjectState(a, EntityState.Modified);
                }

                c.estado = (int)EstadoCurso.Baja;
            }
        }

        [Authorize(Roles = "Administrador, Docente")]
        public void borrarActividadesPorCurso(int idCurso)
        {
            var actividades = from axc in mDb.actividad_x_curso
                              where axc.curso == idCurso
                              select axc;
            List<actividad_x_curso> lista = actividades.ToList();
            foreach (actividad_x_curso axc in lista)
            {
                mDb.actividad_x_curso.DeleteObject(axc);
            }
        }

        [Authorize(Roles = "Administrador, Docente")]
        public void borrarAlumnosDelCurso(int idCurso)
        {
            var alumnos = from axc in mDb.alumno_x_curso
                          where axc.curso == idCurso
                          select axc;
            List<alumno_x_curso> lista = alumnos.ToList();
            foreach (alumno_x_curso axc in lista)
            {
                mDb.alumno_x_curso.DeleteObject(axc);
            }
        }

        #endregion

        #region GET CURSOS

        /// <summary>
        /// Devuelve los cursos de un docente pasado por parámetro.
        /// </summary>
        /// <param name="mail">E-Mail del docente</param>
        /// <returns>Listado de los cursos del docente.</returns>

        [Authorize(Roles = "Administrador, Docente")]
        public List<curso> GetCursosDocente(string mail, Filtros filtro = Filtros.TODOS)
        {
            // devuelvo el listado de cursos del docente.
            List<curso> cursos = mDb.curso.Where(c => c.usuario.mail == mail).ToList();

            return FiltrarCursos(cursos, filtro);
        }

        /// <summary>
        /// Devuelve los cursos de un docente pasado por parámetro.
        /// </summary>
        /// <param name="idUsuario">ID del docente</param>
        /// <returns>Listado de los cursos del docente.</returns>
        /// 
        [Authorize(Roles = "Administrador, Docente")]
        public List<curso> GetCursosDocente(int idUsuario, Filtros filtro = Filtros.TODOS)
        {
            // devuelvo el listado de cursos del docente.
            List<curso> cursos = mDb.curso.Where(c => c.docente == idUsuario && c.estado == 1).ToList();

            return FiltrarCursos(cursos, filtro);
        }

        /// <summary>
        /// Devuelve los cursos de un alumno pasado por parámetro.
        /// </summary>
        /// <param name="idUsuario">ID del alumno</param>
        /// <returns>Listado de los cursos del alumno.</returns>
        public List<curso> GetCursosAlumno(int idUsuario)
        {
            var cursos =
              from c in mDb.curso
              join axc in mDb.alumno_x_curso on c.id equals axc.curso
              where axc.alumno == idUsuario
              select c;

            List<curso> listaCursos = cursos.ToList();

            return listaCursos;
        }


        /// <summary>
        /// Devuelve los cursos de una Institución pasada por parámetro.
        /// </summary>
        /// <param name="idInstitución">ID de la institución</param>
        /// <returns>Listado de los cursos del docente.</returns>
        public List<curso> GetCursosInstitucion(int idInstitución, Filtros filtro = Filtros.TODOS)
        {
            // devuelvo el listado de cursos del docente.
            List<curso> cursos = mDb.curso.Where(c => c.institucion == idInstitución).ToList();

            return FiltrarCursos(cursos, filtro);
        }

        private List<curso> FiltrarCursos(List<curso> cursos, Filtros filtro)
        {
            switch (filtro)
            {
                case Filtros.PRIVADOS:
                    return cursos.Where(x => x.es_publico == false).ToList();

                case Filtros.PUBLICOS:
                    return cursos.Where(x => x.es_publico == true).ToList();

                default:
                    return cursos;
            }
        }

        private List<alumno_x_curso> GetInscripcionesAlumno(int idAlumno)
        {
            var inscripciones =
             from axc in mDb.alumno_x_curso
             where axc.alumno == idAlumno
             select axc;

            List<alumno_x_curso> listaInscripciones = inscripciones.ToList();

            return listaInscripciones;
        }


        public List<curso> getCursosPorInstitucion(List<int> idInstituciones)
        {
            List<curso> listaCursos = new List<curso>();
            if (idInstituciones != null)
            {
                var cursos = from c in mDb.curso
                             where idInstituciones.Contains(c.institucion.Value)
                             select c;

                listaCursos = cursos.ToList();
            }

            return listaCursos;
        }

        public int getCantHistorialCurso(int idCurso)
        {
            int historial = (from ha in mDb.historial_actividad
                             where ha.curso == idCurso
                             select ha).Count();

            return historial;
        }

        #endregion

        #region AUTOCOMPLETE

        public JsonResult AutocompletePorNombre(string parametro)
        {
            var cursos =
                from c in mDb.curso
                where c.nombre.Contains(parametro)
                select new { Value = c.nombre, Label = c.nombre, Id = c.id };

            return Json(cursos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompletePorDocente(string parametro)
        {
            var cursos =
                from c in mDb.curso
                where c.usuario.apellido.Contains(parametro) || c.usuario.nombre.Contains(parametro)
                select new { Value = c.usuario.apellido, Label = string.Concat(c.usuario.apellido, ", ", c.usuario.nombre), Id = c.id };

            return Json(cursos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion

        [HttpPost]
        public ActionResult getAlumnos(String idCurso)
        {
            Int32 id_curso = Int32.Parse(idCurso);
            var alumnos =
                from a in mDb.usuario
                from ac in mDb.alumno_x_curso
                where ac.alumno == a.id
                    && ac.curso1.id == id_curso
                select new { Value = a.nombre + " " + a.apellido, Label = a.nombre + " " + a.apellido, Id = a.id };

            return Json(alumnos.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getActividades(String idCurso)
        {
            Int32 id_curso = Int32.Parse(idCurso);
            var actividades =
                from a in mDb.actividad
                from ac in mDb.actividad_x_curso
                where ac.actividad == a.id
                    && ac.curso == id_curso
                select new { Value = a.nombre, Label = a.nombre, Id = a.id };

            return Json(actividades.Distinct().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
