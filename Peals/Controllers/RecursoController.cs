using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Peals.Models;

namespace Peals.Controllers
{
    public class RecursoController : Controller
    {
        private pealsEntities mDb = new pealsEntities();


        public void setModelo(pealsEntities modelo)
        {
            mDb = modelo;
        }

        /// <summary>
        /// Prapara la vista para cargar un nuevo recurso.
        /// </summary>        
        /// <returns>PartialView - /Recurso/_NuevoRecurso</returns>
        public ActionResult _AgregarEditarRecurso()
        {
            return PartialView();
        }

        public ActionResult EditarRecurso(int id)
        {
            recurso rec = mDb.recurso.Single(x => x.id == id);

            return PartialView("_AgregarEditarRecurso", rec);
        }

        [HttpPost]
        public string EditarRecurso(int id, string nombre)
        {
            recurso res = mDb.recurso.Single(x => x.id == id);
            res.nombre = nombre;

            mDb.ObjectStateManager.ChangeObjectState(res, EntityState.Modified);
            if (mDb.SaveChanges() > 0)
            {
                return res.nombre;
            }

            return null;
        }

        /// <summary>
        /// Sube el archivo al servidor y lo guarda  en la base de datos.
        /// </summary>
        /// <param name="file">Archivo a subir</param>
        /// <param name="nombre">Nombre del archivo</param>
        /// <param name="idUsuario">ID del usuario que esta realizando la acción</param>
        /// <param name="cc">Context del controlador que ejecuta la acción</param>        
        public recurso GuardarRecurso(HttpPostedFileBase file, string nombre, int idUsuario, ControllerContext cc, int? type = null)
        {
            // Guardo el archivo en el disco
            //string src = Utiles.Utils.GuardarArchivoEnDisco(file, cc);

            string path = "~/Content/Resources/Uploads/Recursos/";
            string folder = cc.HttpContext.Server.MapPath(path);
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            string fileName = System.IO.Path.Combine(path, idUsuario + "_" + file.FileName);
            file.SaveAs(cc.HttpContext.Request.MapPath(fileName));

            if (!type.HasValue)
                type = Utiles.Utils.GetTipoDeRecurso(file);

            // agrego el recurso a la bd
            recurso recurso = new recurso()
            {
                nombre = nombre,
                ruta = fileName,
                tipo_recurso = type,
                subido_por = idUsuario,
                estado = 1
            };

            mDb.recurso.AddObject(recurso);

            // aplico los cambios
            if (mDb.SaveChanges() <= 0)
            {
                // si ocurre algun error, elimino el archivo del disco.
                System.IO.File.Delete(fileName);
                return null;
            }

            return recurso;
        }

        /// <summary>
        /// Elimina un recursos de la base de datos y del disco.
        /// </summary>
        /// <param name="idRecurso">ID del recurso a eliminar</param>
        /// <returns>True si la operación fue exitosa y False en caso contrario</returns>
        public bool EliminarRecurso(int idRecurso)
        {
            try
            {
                // recupero el id del usuario logueado y el recurso de la bd.
                int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                
                //borramos primeros lo que haya compartido ese recurso
                List<recurso_compartido> rc = mDb.recurso_compartido.Where(x => x.recurso == idRecurso).ToList();
                
                foreach(recurso_compartido recComp in rc){
                    mDb.recurso_compartido.DeleteObject(recComp);
                }

                recurso res = mDb.recurso.SingleOrDefault(x => x.id == idRecurso && x.subido_por == idUsuario);

                if (res == null) return false;

                // elimino el recurso de la bd.
                mDb.recurso.DeleteObject(res);

                if (mDb.SaveChanges() <= 0) return false;

                // elimino el recurso del disco.
                System.IO.File.Delete(Url.Encode(res.ruta));
                return true;
            }
            catch(Exception e) { 
                return false; 
            }
        }

        public bool CompartirRecursos(string sRes, string sInst)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            int[] recursos = (int[])serializer.Deserialize(sRes, typeof(int[]));
            int[] instituciones = (int[])serializer.Deserialize(sInst, typeof(int[]));

            try
            {
                recurso_compartido rcom = null;
                foreach (int rec in recursos)
                {
                    foreach (int inst in instituciones)
                    {
                        if (mDb.recurso_compartido.SingleOrDefault(x => x.recurso == rec && x.institucion == inst) != null)
                            continue;

                        rcom = new recurso_compartido() { institucion = inst, recurso = rec };
                        mDb.recurso_compartido.AddObject(rcom);
                    }
                }

                return (mDb.SaveChanges() > 0);
            }
            catch { return false; }
        }

        public bool CompartirRecurso(int recurso, int institucion)
        {
            try
            {
                recurso_compartido rcom = null;

                rcom = new recurso_compartido() { institucion = institucion, recurso = recurso };
                mDb.recurso_compartido.AddObject(rcom);

                return (mDb.SaveChanges() > 0);
            }
            catch { return false; }
        }

        public bool DejarDeCompartir(int recurso, string sIns)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            int[] instituciones = (int[])serializer.Deserialize(sIns, typeof(int[]));

            try
            {
                List<recurso_compartido> list = mDb.recurso_compartido.Where(x => x.recurso == recurso && instituciones.Contains(x.institucion.Value)).ToList();
                foreach (recurso_compartido rcom in list)
                    mDb.recurso_compartido.DeleteObject(rcom);

                return (mDb.SaveChanges() > 0);
            }
            catch { return false; }
        }

        public bool DejarDeCompartirRecurso(int recurso, int institucion)
        {
            try
            {
                List<recurso_compartido> rc = mDb.recurso_compartido.Where(x => x.recurso == recurso && x.institucion == institucion).ToList();

                foreach (recurso_compartido rcom in rc)
                    mDb.recurso_compartido.DeleteObject(rcom);

                return (mDb.SaveChanges() > 0);
            }
            catch { return false; }
        }


        public ActionResult ListadoRecursos()
        {
            return View();
        }

        /// <summary>
        /// Carga todos los recursos pertenecientes al usuario logueado.
        /// </summary>
        /// <returns>View - /Recurso/ListadoRecursos</returns>
        public ActionResult _Imagenes()
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<recurso> imagenes = mDb.recurso.Where(x => x.subido_por == id && x.tipo_recurso == 1).ToList();
            ViewBag.ListImagenes = (imagenes.Count == 0) ? null : imagenes;
            return PartialView();
        }

        /// <summary>
        /// Carga todos los recursos pertenecientes al usuario logueado.
        /// </summary>
        /// <returns>View - /Recurso/ListadoRecursos</returns>
        public ActionResult _Sonidos()
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<recurso> sonidos = mDb.recurso.Where(x => x.subido_por == id && x.tipo_recurso == 2).ToList();
            ViewBag.ListSonidos = (sonidos.Count == 0) ? null : sonidos;
            return PartialView();
        }

        /// <summary>
        /// Carga todos los recursos pertenecientes al usuario logueado.
        /// </summary>
        /// <returns>View - /Recurso/ListadoRecursos</returns>
        public ActionResult _Videos()
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<recurso> videos = mDb.recurso.Where(x => x.subido_por == id && x.tipo_recurso == 3).ToList();
            ViewBag.ListVideos = (videos.Count == 0) ? null : videos;
            return PartialView();
        }


        /// <summary>
        /// Carga todos los recursos pertenecientes al usuario logueado.
        /// </summary>
        /// <returns>View - /Recurso/ListadoRecursos</returns>
        public ActionResult _ImagenesSearch(String filtro)
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<recurso> imagenes = mDb.recurso.Where(x => x.subido_por == id && x.tipo_recurso == 1 && x.nombre.Contains(filtro)).ToList();
            ViewBag.ListImagenes = (imagenes.Count == 0) ? null : imagenes;
            return PartialView("_Imagenes");
        }

        /// <summary>
        /// Carga todos los recursos pertenecientes al usuario logueado.
        /// </summary>
        /// <returns>View - /Recurso/ListadoRecursos</returns>
        public ActionResult _SonidosSearch(String filtro)
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<recurso> sonidos = mDb.recurso.Where(x => x.subido_por == id && x.tipo_recurso == 2 && x.nombre.Contains(filtro)).ToList();
            ViewBag.ListSonidos = (sonidos.Count == 0) ? null : sonidos;
            return PartialView("_Sonidos");
        }

        /// <summary>
        /// Carga todos los recursos pertenecientes al usuario logueado.
        /// </summary>
        /// <returns>View - /Recurso/ListadoRecursos</returns>
        public ActionResult _VideosSearch(String filtro)
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            List<recurso> videos = mDb.recurso.Where(x => x.subido_por == id && x.tipo_recurso == 3 && x.nombre.Contains(filtro)).ToList();
            ViewBag.ListVideos = (videos.Count == 0) ? null : videos;
            return PartialView("_Videos");
        }


        public JsonResult GetTodosLosRecursosAsJson(string filtro)
        {
            int id = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            var recursos = from rec in mDb.recurso
                           where rec.subido_por == id && rec.nombre.Contains(filtro)
                           select new Recurso
                           {
                               id = rec.id,
                               nombre = rec.nombre,
                               ruta = rec.ruta,
                               es_compartido = rec.recurso_compartido.Count > 0,
                               es_usado = rec.ejercicio_x_recurso.Count > 0,
                               tipo = rec.tipo_recurso.Value
                           };

            List<Recurso> imagenes = new List<Recurso>();
            List<Recurso> sonidos = new List<Recurso>();
            List<Recurso> videos = new List<Recurso>();

            foreach (var rec in recursos)
            {
                switch (rec.tipo)
                {
                    case 1: imagenes.Add(rec); break;
                    case 2: sonidos.Add(rec); break;
                    case 3: videos.Add(rec); break;
                }
            }

            JsonResult jSon = new JsonResult { Data = new { Imagenes = imagenes, Sonidos = sonidos, Videos = videos } };
            jSon.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return jSon;
        }

        /// <summary>
        /// Carga los recursos disponibles para el uso del usuario en la vista.
        /// </summary>
        /// <param name="tipo">Tipo de recurso</param>
        /// <param name="filtro">Opcional - Parámetro usado para filtrar los resultodos por su nombre.</param>
        /// <param name="resCargados">Opcional - Listado de recursos que deben omitirse</param>
        /// <returns>Deveuelve una PartialView segun el tipo de recurso.</returns>
        public ActionResult SeleccionarRecurso(int tipo, string filtro = "", int[] resCargados = null)
        {
            int total;
            var recursos = GetRecursos(tipo, filtro, resCargados, 1, 12, out total);

            ViewBag.TipoRecurso = tipo;
            ViewBag.TotalRecursos = total;

            switch (tipo)
            {
                case (int)TipoDeRecurso.Imagen: return PartialView("SeleccionarImagen", recursos);
                case (int)TipoDeRecurso.Audio: return PartialView("SeleccionarAudio", recursos);
                case (int)TipoDeRecurso.Video: return PartialView("SeleccionarVideo", recursos);
            }

            return null;
        }

        /// <summary>
        /// Devuelve los recursos disponibles para un usuario en un JsonResult.
        /// </summary>
        /// <param name="tipo">Tipo de recurso</param>
        /// <param name="filtro">Parámetro usado para filtrar los recursos.</param>
        /// <param name="pagina">Número de pagina, usado en la paginación.</param>
        /// <param name="limite">Cantidad de elementos a mostrar.</param>
        /// <param name="resCargados">Listado de recursos a omitir.</param>
        /// <returns>Devuelve un JsonResul con el siguiente formato:
        ///     recursos - listado de recursos.
        ///     total    - total de los recursos disponibles.
        /// </returns>
        [HttpPost]
        public JsonResult GetRecursosAsJson(int tipo, string filtro, int pagina = 1, int limite = 12, int[] resCargados = null)
        {
            int total;
            var recursos = GetRecursos(tipo, filtro, resCargados, pagina, limite, out total);

            ViewBag.TotalRecursos = total;

            return Json(new { recursos = recursos, total = total }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Recupera todos los recursos que el usuario puede utilizar de la base de datos.
        /// </summary>
        /// <param name="tipoRecurso">Tipo de recursos.</param>
        /// <param name="filtro">Parámetro usado para filtrar los recursos.</param>
        /// <param name="resCargados">Listado de recursos a omitir.</param>
        /// <param name="pagina">Número de página.</param>
        /// <param name="cantidad">Cantidad de elementos a mostrar.</param>
        /// <param name="total">Total de recursos disponibles.</param>
        /// <returns></returns>
        private IEnumerable<Recurso> GetRecursos(int tipoRecurso, string filtro, int[] resCargados, int pagina, int cantidad, out int total)
        {
            // recupero el id del usuario logueado.
            int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var instUsuario = mDb.docente_x_institucion.Where(x => x.docente == idUsuario).Select(x => x.institucion);

            // recupero los recursos cargados por el usuario junto a los que estan compartidos con las instituciones en las que participa.
            var recursos = from res in mDb.recurso
                           join rc in mDb.recurso_compartido on res.id equals rc.recurso into ljoin
                           from lj in ljoin.DefaultIfEmpty()
                           where (!res.subido_por.HasValue || res.subido_por == idUsuario || instUsuario.Contains(lj.institucion.Value)) &&
                                 res.tipo_recurso == tipoRecurso && res.nombre.ToUpper().Contains(filtro.ToUpper())
                           let user = mDb.usuario.FirstOrDefault(x => x.id == res.subido_por)
                           select new Recurso()
                           {
                               id = res.id,
                               nombre = res.nombre,
                               ruta = res.ruta,
                               subido_por = (!res.subido_por.HasValue) ? "PEALS" : (res.subido_por == idUsuario) ? "Mi" : user.apellido + ", " + user.nombre,
                               tipo = res.tipo_recurso.Value
                           };

            if (resCargados != null) recursos = recursos.Where(x => !resCargados.Contains(x.id));

            total = recursos.Count();

            recursos = recursos.OrderBy(x => x.nombre).Skip((pagina - 1) * cantidad).Take(cantidad);

            return recursos;
        }

        /// <summary>
        /// Devuelve los cinco primeros recursos disponibles para el usuario logueado.
        /// </summary>
        /// <param name="parametro">Parametro usado para filtrar los recursos</param>
        /// <param name="idEntidad">Tipo de recurso</param>
        /// <returns>Devuelve un JsonResult con los recursos en su "Data"</returns>
        public JsonResult AutoCompletePorNombre(string parametro, int? idEntidad)
        {
            int total;
            if (idEntidad.HasValue)
            {
                var recursos = GetRecursos(idEntidad.Value, parametro, null, 1, 5, out total);

                return Json(recursos, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                //var recursos = mDb.recurso.Where(x => x.subido_por == idUsuario && x.nombre.Contains(parametro));

                var recursos =
                    from rec in mDb.recurso
                    where rec.subido_por == idUsuario && rec.nombre.Contains(parametro)
                    select new
                    {
                        nombre = rec.nombre,
                        id = rec.id
                    };

                return Json(recursos.Take(5).ToList(), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetInstituciones()
        {
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var instituciones = mDb.docente_x_institucion.Where(x => x.docente == idDocente).Select(x => new { x.institucion1.id, x.institucion1.nombre }).ToList();

            return Json(instituciones, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInstitucionesRecurso(int idRecurso)
        {
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var instituciones =
                from dxi in mDb.docente_x_institucion
                where dxi.docente == idDocente
                select new
                {
                    Id = dxi.institucion,
                    Nombre = dxi.institucion1.nombre,
                    Compartido = (from rc in mDb.recurso_compartido where rc.institucion == dxi.institucion && rc.recurso == idRecurso select rc).Count()
                };

            return Json(instituciones, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInstitucionesCompartidas()
        {
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var instituciones = mDb.recurso_compartido.Where(x => x.recurso1.subido_por == idDocente).Select(x => new { x.institucion1.id, x.institucion1.nombre }).Distinct().ToList();

            return Json(instituciones, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetActividades(int idRecurso)
        {
            var actividades = mDb.ejercicio_x_recurso.Where(x => x.recurso == idRecurso).Select(x => new { id = x.ejercicio1.actividad.Value, nombre = x.ejercicio1.actividad1.nombre, compartido = x.recurso1.recurso_compartido.Count > 0 });

            return Json(actividades, JsonRequestBehavior.AllowGet);
        }

        public void DarDeBajaRecursosDocente(int idUsuario)
        {
            List<recurso> recursos = this.GetRecursosDocente(idUsuario);

            foreach (recurso r in recursos)
            {
                if (r.estado == (int)EstadoRecurso.Alta)
                    r.estado = (int)EstadoRecurso.Baja;
            }
        }

        public List<recurso> GetRecursosDocente(int idUsuario)
        {
            var recursos =
               from r in mDb.recurso
               where r.subido_por == idUsuario
               select r;

            List<recurso> listaRecursos = recursos.ToList();
            return listaRecursos;
        }

        /// <summary>
        /// Prapara la vista para grabar un nuevo video.
        /// </summary>        
        /// <returns>PartialView</returns>
        public ActionResult _GrabarVideo()
        {
            return View();
            // return PartialView();
        }

        public ActionResult _GrabarSonido()
        {
            return View();
            // return PartialView();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            //guardo el archivo en disco
            int idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            string fileName = Request.Headers["X-File-Name"];
            string fileType = Request.Headers["X-File-Type"];
            int fileSize = Convert.ToInt32(Request.Headers["X-File-Size"]);
            //File's content is available in Request.InputStream property
            System.IO.Stream fileContent = Request.InputStream;
            //Creating a FileStream to save file's content
            
            string folder = Server.MapPath("~/Content/Resources/Uploads/Recursos/");
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);

            string ruta = folder + idUsuario + "_" + fileName;
            string path = System.IO.Path.Combine(folder, idUsuario + "_" + fileName);

            System.IO.FileStream fileStream = System.IO.File.Create(ruta);
            fileContent.Seek(0, System.IO.SeekOrigin.Begin);
            //Copying file's content to FileStream
            fileContent.CopyTo(fileStream);
            fileStream.Dispose();

            int? type = 0;
            if (fileType.Contains("image"))
                type = (int)TipoDeRecurso.Imagen;
            else if (fileType.Contains("audio"))
                type = (int)TipoDeRecurso.Audio;
            else if (fileType.Contains("video"))
                type = (int)TipoDeRecurso.Video;

            //verificamos que el recurso no exista en la base
            recurso rec = mDb.recurso.FirstOrDefault(x => x.ruta == ruta);

            if (rec != null)
                return Json("Ya existe un recurso con ese nombre en el sistema.");

            //agrego el recurso a la bd
            recurso recurso = new recurso()
            {
                nombre = fileName,
                ruta = "/Content/Resources/Uploads/Recursos/" + idUsuario + "_" + fileName,
                tipo_recurso = type,
                subido_por = idUsuario,
                estado = 1
            };

            mDb.recurso.AddObject(recurso);

            // aplico los cambios
            if (mDb.SaveChanges() <= 0)
            {
                // si ocurre algun error, elimino el archivo del disco.
                System.IO.File.Delete(ruta);
                return Json("Ocurrió un error.");
            }

            return Json("Recurso creado con éxito.");
        }


    }


    /// <summary>
    /// Clase auxiliar usado para extender el objecto recurso
    /// </summary>
    public class Recurso
    {
        public int id;
        public string nombre;
        public string ruta;
        public string subido_por;
        public bool es_compartido;
        public bool es_usado;
        public int tipo;
    }
}
