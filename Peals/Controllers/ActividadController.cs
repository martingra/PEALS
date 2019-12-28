using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Peals.Models;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data;

namespace Peals.Controllers
{
    public class ActividadController : Controller
    {
        private pealsEntities mDb = new pealsEntities();
        private RecursoController mRecursoController = new RecursoController();

        public ActionResult Index()
        {
            ViewBag.DefaultMessage = "No tiene ninguna actividad creada.";

            return View();
        }

        public ActionResult CrearActividad()
        {
            int id_docente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<criterio_evaluacion> criterios = mDb.criterio_evaluacion.Where(x => x.docente == id_docente).ToList<criterio_evaluacion>();
            ViewBag.Criterios = criterios;

            //List<senia> senias = mDb.senia.Where(x=> x.activo.Value).ToList<senia>();
            //ViewBag.Senias = senias;

            return View();
        }

        public ActionResult _Senias(String filtro = "")
        {
            List<senia> senias = mDb.senia.Where(x => x.activo.Value && x.clase.Contains(filtro)).OrderBy(x => x.clase).ToList<senia>();
            return PartialView(senias);
        }

        /// <summary>
        /// Guarda la actividad en la base de datos, subiendo también la nuevas imágenes.
        /// </summary>
        /// <param name="actividad">JSON de la actividad</param>
        /// <param name="criterio">Id del criterio de evaluacion</param>
        public ActionResult GuardarActividad(string actividad, string criterio, HttpPostedFileBase video)
        {
            int user_id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(actividad);
            actividad act = new actividad();
            act.nombre = json.nombre;
            act.descripcion = json.explicacion;

            if (video != null)
            {
                act.videoExplicacion = Utiles.Utils.GuardarArchivoEnDisco(video, ControllerContext);
            }

            act.docente = user_id;
            act.criterio = int.Parse(criterio);
            act.fecha_alta = System.DateTime.Now;
            act.estado = 1;
            mDb.actividad.AddObject(act);
            mDb.SaveChanges();

            Dictionary<int, int> recursosNuevos = new Dictionary<int, int>();

            for (int i = 0; i < json.ejercicios.Count; i++)
            {
                ejercicio ejer = new ejercicio();
                ejer.actividad = act.id;
                ejer.zoom = json.ejercicios[i].zoom;

                mDb.ejercicio.AddObject(ejer);

                mDb.SaveChanges();

                int id_recurso_correcto = -1;
                for (int j = 0; j < json.ejercicios[i].recursos.Count; j++)
                {
                    int type = json.ejercicios[i].recursos[j].type + 1;
                    int id_recurso = -1;
                    if (type == (int)TipoDeRecurso.Texto)
                    {
                        string text = json.ejercicios[i].recursos[j].text;
                        recurso recurso = new recurso()
                        {
                            nombre = "",
                            ruta = text,
                            tipo_recurso = type,
                            subido_por = user_id,
                            estado = 1
                        };

                        mDb.recurso.AddObject(recurso);
                        mDb.SaveChanges();

                        id_recurso = recurso.id;
                    }
                    else
                    {
                        int id_tmp = json.ejercicios[i].recursos[j].id;
                        if (id_tmp < 0) // Si el id es negativo, el recurso fue cargado desde la PC
                        {
                            if (recursosNuevos.ContainsKey(id_tmp)) // Conpruebo que el recurso no haya sido cargado con anterioridad para la actividad
                            {
                                
                                id_recurso = recursosNuevos[id_tmp];
                            }
                            else // En caso de ser nuevo, lo guardo y lo agrego al diccionario para controlar que no se suba de nuevo en la actividad
                            {
                                HttpPostedFileBase file = Request.Files[id_tmp.ToString()];
                                if (file != null)
                                {
                                    id_recurso = mRecursoController.GuardarRecurso(file, file.FileName, user_id, ControllerContext, type).id;
                                    recursosNuevos.Add(id_tmp, id_recurso);
                                }
                                else // Si pasa por acá es porque algo no se cargo
                                {
                                    System.Console.WriteLine("No se guardo el recurso " + id_tmp + " para la actividad " + act.id);
                                }
                            }
                        }
                        else
                        {
                            id_recurso = id_tmp;
                        }
                    }

                    if ((int)json.ejercicios[i].solucion.tipo == (int)SolucionActividad.Opciones && json.ejercicios[i].recursos[j].id == json.ejercicios[i].solucion.respuesta)
                        id_recurso_correcto = id_recurso;

                    ejercicio_x_recurso ej_recurso = new ejercicio_x_recurso()
                    {
                        recurso = id_recurso,
                        ejercicio = ejer.id,
                        pos_top = json.ejercicios[i].recursos[j].top,
                        pos_left = json.ejercicios[i].recursos[j].left,
                        width = json.ejercicios[i].recursos[j].width,
                        height = json.ejercicios[i].recursos[j].height
                    };

                    mDb.ejercicio_x_recurso.AddObject(ej_recurso);
                    mDb.SaveChanges();
                }

                switch ((int)json.ejercicios[i].solucion.tipo)
                {
                    case (int)SolucionActividad.Opciones:
                        ejer.recurso_correcto = id_recurso_correcto;
                        ejer.deletreo = 0;
                        break;
                    case (int)SolucionActividad.Escribir:
                        ejer.texto_solucion = json.ejercicios[i].solucion.respuesta;
                        ejer.deletreo = json.ejercicios[i].solucion.opcion;
                        break;
                    case (int)SolucionActividad.Senias:
                        ejer.senia = json.ejercicios[i].solucion.respuesta;
                        ejer.deletreo = 0;
                        break;
                }

                mDb.ObjectStateManager.ChangeObjectState(ejer, System.Data.EntityState.Modified);
                mDb.SaveChanges();
            }

            mDb.SaveChanges();

            return RedirectToAction("_AsignarActividad", new { id_actividad = act.id, nombre_actividad = act.nombre });
        }

        /// <summary>
        /// Prepara una vista parcial para realizar la asignación de las actividades a los cursos, especificando la fecha
        /// a partir de la cual estarán disponibles.
        /// </summary>
        /// <param name="ids_actividades">IDs de las actividades a las que se les asignarán los cursos.</param>
        /// <param name="actividades">Nombres de las actividades a las que se les asignarán los cursos.</param>
        /// <param name="callbackCancelar">Función JavaScript a la que se llamará si se cancela la operación.</param>
        /// <returns>Partial View: /Actividad/_AsignarActividad</returns>
        public ActionResult _AsignarActividad(int id_actividad, string nombre_actividad, string callbackCancelar = "btnClick_cancelarAsignacion()")
        {
            // guardo los ids en una lista temporal
            Session.Add("ID_Actividad", id_actividad);

            // agrego los ViewBag, que se utilizaran en la vista
            ViewBag.Titulo = nombre_actividad;

            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<int> cAsignados = mDb.actividad_x_curso.Where(x => x.actividad == id_actividad && x.curso1.docente == idDocente).Select(y => y.curso.Value).ToList();
            List<curso> cursos = mDb.curso.Where(x => x.docente == idDocente && !cAsignados.Contains(x.id)).ToList();

            ViewBag.Cursos_DefaultMessage = "Ya has asignado la actividad a todos tus cursos";

            ViewBag.Btn_Cancelar = callbackCancelar;

            return PartialView(cursos);
        }

        /// <summary>
        /// Carga las asignaciones en la base de datos.
        /// </summary>
        /// <param name="ids_cursos">IDs de los cursos que fueron seleccionados.</param>
        /// <param name="fecha_apertura">A partir de que se fecha se podrá realizar la actividad.</param>
        /// <returns>View: /Actividad/Index</returns>
        [HttpPost]
        public ActionResult AsignarActividad(string ids_cursos, string fecha_apertura)
        {
            // recupero los ids de las actividades de la lista temporal.
            int? actividad = Session["ID_Actividad"] as int?;
            Session.Remove("ID_Actividad");

            // obtengo los ids de los cursos.
            string[] cursos = ids_cursos.Split(',');

            foreach (var cur in cursos)
            {
                int idCurso = int.Parse(cur);
                mDb.actividad_x_curso.Select(x => x.actividad == actividad && x.curso == idCurso);


                // cargo los datos a la base de datos.
                actividad_x_curso aCur = new actividad_x_curso()
                {
                    actividad = actividad,
                    curso = idCurso,
                    fecha_apertura = DateTime.Parse(fecha_apertura)
                };

                mDb.actividad_x_curso.AddObject(aCur);
            }

            if (mDb.SaveChanges() <= 0)
            {
                // si hay algún error, agrego un mensaje al modelo.
                ModelState.AddModelError("ErrorAsignacion", "Ha ocurrido un error mientras se asignaba la actividad. Por favor, intentelo más tarde.");
            }

            return RedirectToAction("Index");
        }

        public ActionResult _CursosPorActividad(int idActividad, string nombre = "")
        {
            var cursos = mDb.actividad_x_curso.Where(x => x.actividad == idActividad && x.curso1.nombre.ToLower().Contains(nombre)).ToList();

            return (cursos.Count > 0) ? PartialView(cursos) : null;
        }

        public ActionResult VerActividad(int idActividad, int idCurso)
        {
            actividad model = mDb.actividad.Single(x => x.id == idActividad);
            List<ejercicio> ejercicios = mDb.ejercicio.Where(x => x.actividad == idActividad).ToList();

            ViewBag.idActividad = idActividad;
            ViewBag.idCurso = idCurso;
            ViewBag.Titulo = model.nombre;
            ViewBag.Descripcion = model.descripcion;
            ViewBag.Explicacion = model.videoExplicacion == null ? "~/Content/" : model.videoExplicacion;

            return View(ejercicios);
        }

        [HttpPost]
        public ActionResult VerActividad(int idActividad, int idCurso, int tiempo, int usoAyudaActividad, int usoAyudaConsigna, int intentos, int ejNoResueltos, int cantidadEjercicios)
        {
            historial_actividad ha = new historial_actividad();
            curso curso = mDb.curso.First(x => x.id == idCurso);

            ha.actividad = idActividad;
            ha.alumno = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            ha.curso = idCurso;
            ha.docente = (int)curso.docente;
            ha.fecha_realizacion = DateTime.Now;
            ha.institucion = curso.institucion;
            ha.intentos = intentos;

            TimeSpan ts = new TimeSpan(0, 0, tiempo);
            ha.tiempo = ts;
            
            ha.uso_ayuda_actividad = usoAyudaActividad == 1 ? true : false;
            ha.uso_ayuda_consigna = usoAyudaConsigna == 1 ? true : false;
            ha.intentos = intentos;
            ha.totalEjercicios = cantidadEjercicios;
            ha.ejerciciosNoResueltos = ejNoResueltos;

            corregirPorSistema(ref ha);

            mDb.historial_actividad.AddObject(ha);
            if (mDb.SaveChanges() == 0)
                return View("Error");
            else
                return RedirectToAction("ResultadoActividad", "Actividad", new { historialActividad = ha.id });
        }

        public void corregirPorSistema(ref historial_actividad ha)
        {
            int puntaje = 100;
            int puntajeIntentos = ((int)ha.intentos - 1) * 5;

            puntaje = puntaje - puntajeIntentos - (((bool)ha.uso_ayuda_actividad ? 1 : 0) * 10) - (((bool)ha.uso_ayuda_consigna ? 1 : 0) * 20);

            int ejerciciosIncorrectos = (puntaje / (int)ha.totalEjercicios) * (int) ha.ejerciciosNoResueltos;
            puntaje = puntaje - ejerciciosIncorrectos;

            ha.calificacion_sistema = puntaje;
        }

        public ActionResult ResultadoActividad(int historialActividad)
        {
            historial_actividad ha = mDb.historial_actividad.First(x => x.id == historialActividad);
            criterio_evaluacion criterio = mDb.criterio_evaluacion.First(x => x.docente == ha.docente);

            System.Xml.XmlDocument xml_criterio = new System.Xml.XmlDocument();
            xml_criterio.LoadXml(criterio.descripcion);
            System.Xml.XmlNodeList intervalos = xml_criterio.GetElementsByTagName("intervalo");

            try
            {
                for (int i= 0; i< intervalos.Count; i++)
                {
                    int desde = int.Parse(intervalos[i].Attributes["value"].Value);
                    int hasta = int.Parse(intervalos[i+1].Attributes["value"].Value);

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

            if (ha.calificacion_docente != null)
            {
                try
                {
                    for (int i = 0; i < intervalos.Count; i++)
                    {
                        int desde = int.Parse(intervalos[i].Attributes["value"].Value);
                        int hasta = int.Parse(intervalos[i + 1].Attributes["value"].Value);

                        if (desde <= (int)ha.calificacion_docente && hasta >= (int)ha.calificacion_docente)
                        {
                            ViewBag.imgCritDocente = intervalos[i + 1].InnerText;
                            break;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    ViewBag.imgCritDocente = "/Content/Resources/Actividad/carita-feliz.png";
                }
            }
            else
            {
                ViewBag.imgCritDocente = "/Content/Resources/Docente/Docente.PNG";
            }
            
            return View(ha);
        }


        public JsonResult EliminarActividad(int idActividad)
        {
            actividad ac = mDb.actividad.FirstOrDefault(x => x.id == idActividad);
            historial_actividad ha = mDb.historial_actividad.FirstOrDefault(x => x.actividad == idActividad);

            if (ha == null)
            {
                //si no tiene historicos de resolucion, hago borrado físico de la actividad
                //borramos primero las asignaciones a cursos
                List<actividad_x_curso> actsCur = mDb.actividad_x_curso.Where(x => x.actividad == idActividad).ToList();
                foreach (actividad_x_curso actCur in actsCur)
                {
                    mDb.actividad_x_curso.DeleteObject(actCur);
                }

                //borramos los ejercicios
                List<ejercicio> ejercicios = mDb.ejercicio.Where(x => x.actividad == idActividad).ToList();
                foreach (ejercicio ejercicio in ejercicios)
                {
                    //borramos ejercicio por recurso
                    List<ejercicio_x_recurso> ejerciciosPorRecurso = mDb.ejercicio_x_recurso.Where(x => x.ejercicio == ejercicio.id).ToList();
                    foreach (ejercicio_x_recurso ejerRec in ejerciciosPorRecurso)
                    {
                        mDb.ejercicio_x_recurso.DeleteObject(ejerRec);
                    }

                    mDb.ejercicio.DeleteObject(ejercicio);
                }

                


                mDb.actividad.DeleteObject(ac);
            }
            else
            {
                //si tiene historicos de resolucion, hago borrado logico
                ac.estado = (int) EstadoActividad.Baja;
                mDb.ObjectStateManager.ChangeObjectState(ac, EntityState.Modified);
            }

            if (mDb.SaveChanges() > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }


        public JsonResult desvincularCurso(int idActividad, int idCurso)
        {
            actividad_x_curso ac = mDb.actividad_x_curso.FirstOrDefault(x => x.actividad == idActividad && x.curso == idCurso);

            mDb.actividad_x_curso.DeleteObject(ac);

            if (mDb.SaveChanges() > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        #region GET ACTIVIDADES

        /// <summary>
        /// Devuelve las actividades de un docente.
        /// </summary>
        /// <param name="idUsuario">ID del docente</param>
        /// <returns>Listado de las actividades.</returns>
        public List<actividad> GetActividadesDocente(int idUsuario)
        {
            var actividades =
                from a in mDb.actividad
                where a.docente == idUsuario
                select a;

            List<actividad> listaActividades = actividades.ToList();
            return listaActividades;
        }

        /// <summary>
        /// Devuelve las actividades de un docente.
        /// </summary>
        /// <param name="idUsuario">ID del docente</param>
        /// <returns>Listado de las actividades.</returns>
        public List<actividad> GetActividadesDocenteConCurso(int idUsuario)
        {
            var actividades =
                from a in mDb.actividad
                where a.docente == idUsuario
                && (from axc in mDb.actividad_x_curso
                    select axc.actividad).Contains(a.id)
                select a;

            List<actividad> listaActividades = actividades.ToList();
            return listaActividades;
        }

        public List<actividad> GetActividadesDocenteSinCurso(int idUsuario)
        {
            var actividades =
                from a in mDb.actividad
                where a.docente == idUsuario
                && !(from axc in mDb.actividad_x_curso
                     select axc.actividad).Contains(a.id)
                && (from ha in mDb.historial_actividad
                    select ha.actividad).Contains(a.id)
                select a;

            List<actividad> listaActividades = actividades.ToList();
            return listaActividades;
        }

        public List<actividad> GetActividadesDocenteSinHistorial(int idUsuario)
        {
            var actividades =
                from a in mDb.actividad
                where a.docente == idUsuario
                && !(from axc in mDb.actividad_x_curso
                     select axc.actividad).Contains(a.id)
                && !(from ha in mDb.historial_actividad
                     select ha.actividad).Contains(a.id)
                select a;

            List<actividad> listaActividades = actividades.ToList();
            return listaActividades;

        }

        public List<actividad> getActividadesCurso(int idCurso)
        {
            var actividades =
               from a in mDb.actividad
               join axc in mDb.actividad_x_curso on a.id equals axc.actividad
               where axc.curso == idCurso
               select a;

            List<actividad> listaActividades = actividades.ToList();
            return listaActividades;
        }

        public int getCantHistorialActividad(int idActividad)
        {
            int historial = (from ha in mDb.historial_actividad
                             where ha.actividad == idActividad
                             select ha).Count();

            return historial;
        }

        public int getCantCursosActividad(int idActividad)
        {
            int cursosActividad = (from axc in mDb.actividad_x_curso
                                   where axc.actividad == idActividad
                                   select axc).Count();
            return cursosActividad;
        }
        #endregion

        #region SET

        public void setModelo(pealsEntities modelo)
        {
            mDb = modelo;
        }

        #endregion

        #region Borrar Inscripcion Actividades

        public void DarDeBajaActividadesDocente(int idUsuario)
        {
            List<actividad> actividades = this.GetActividadesDocente(idUsuario);

            foreach (actividad a in actividades)
            {
                a.estado = (int)EstadoActividad.Baja;
            }
        }

        //public void BorrarInscripcionActividadesDocenteConCurso(int idUsuario)
        //{
        //    List<actividad> actividades = this.GetActividadesDocenteConCurso(idUsuario);

        //    foreach (actividad a in actividades)
        //    {
        //        a.docente = null;
        //    }

        //}


        //public void BorrarInscripcionActividadesDocenteSinCurso(int idUsuario)
        //{
        //    List<actividad> actividades = this.GetActividadesDocenteSinCurso(idUsuario);

        //    foreach (actividad a in actividades)
        //    {
        //        a.docente = null;
        //    }
        //}


        //public void BorrarActividadesDocenteSinHistorial(int idUsuario)
        //{
        //    List<actividad> actividades = this.GetActividadesDocenteSinHistorial(idUsuario);
        //    foreach (actividad a in actividades)
        //    { this.BorrarActividad(a); }
        //}

        public void BorrarRecursosPorActividad(int idActividad)
        {
            //List<actividad_x_recurso> recursos = this.GetRecursosPorActividad(idActividad);

            //foreach (actividad_x_recurso axr in recursos)
            //{
            //    mDb.actividad_x_recurso.DeleteObject(axr);
            //}
        }

        public void BorrarActividad(actividad a)
        {
            this.BorrarRecursosPorActividad(a.id);
            mDb.actividad.DeleteObject(a);
        }

        #endregion

        #region Get Recursos

        public List<ejercicio_x_recurso> GetRecursosPorActividad(int idEjercicio)
        {
            var recursos =
                from axr in mDb.ejercicio_x_recurso
                where axr.ejercicio == idEjercicio
                select axr;

            List<ejercicio_x_recurso> listaRecursos = recursos.ToList();
            return listaRecursos;
        }

        #endregion

    }
}


