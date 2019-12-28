using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;
using System.Data;

namespace Peals.Controllers
{
    public class InformacionController : Controller
    {
        private pealsEntities mDb = new pealsEntities();

        /// <summary>
        /// Crea una vista parcial para agregar la información correspondiente a la institución.
        /// </summary>
        /// <returns>GET: /Informacion/AgregarInformacion</returns>
        public ActionResult AgregarInformacion()
        {
            return PartialView();
        }

        /// <summary>
        /// Guarda en la base de datos la información correspondiente a una institución.
        /// </summary>
        /// <param name="info">Es la información que se va a guardar.</param>
        /// <param name="imagen">Imagen de la institución.</param>
        /// <param name="video">video de la institución.</param>
        /// <returns>Devuelve el ID con que fue guardada la institucion o -1 en caso de error.</returns>
        public int GuardarInformacion(informacion info, HttpPostedFileBase imagen, HttpPostedFileBase video, ControllerContext cc)
        {

                // Guardo los archvos en el servidor
                if (imagen != null) info.imagen = GuardarArchivoEnDisco(imagen, cc);
                if (video != null) info.video = GuardarArchivoEnDisco(video, cc);

                // Detetecto los saltos de línea para mantener el formato del texto ingresado.
                info.introduccion = (info.introduccion != null)? info.introduccion.Replace("\n", "<br />") : "";
                info.contenido = (info.contenido != null) ? info.contenido.Replace("\n", "<br />") : "";

                //Guardo el objecto en la base de datos y devuelvo su id
                mDb.informacion.AddObject(info);
                if (mDb.SaveChanges() > 0)
                    return info.id;

           
            // En caso de error, devuelvo -1.
            return -1;
        }

        public int ModificarInformacion(int? idInformacion, informacion info, HttpPostedFileBase imagen, HttpPostedFileBase video, ControllerContext cc)
        {
            if (idInformacion.HasValue)
            {
                // Si ya existe información previa, la modifico.
                try
                {
                    informacion infoOriginal = mDb.informacion.Single(x => x.id == idInformacion);

                    infoOriginal.encabezado = info.encabezado;
                    infoOriginal.introduccion = (info.introduccion != null) ? info.introduccion.Replace("\n", "<br />") : "";
                    infoOriginal.contenido = info.contenido = (info.contenido != null) ? info.contenido.Replace("\n", "<br />") : "";

                    if (imagen != null)
                    {
                        infoOriginal.imagen = ModificarArchivosEnDisco(info.imagen, imagen, cc);
                    }

                    if (video != null)
                    {
                        infoOriginal.video = ModificarArchivosEnDisco(info.video, video, cc);
                    }

                    mDb.ObjectStateManager.ChangeObjectState(infoOriginal, EntityState.Modified);
                    if (mDb.SaveChanges() > 0)
                        return infoOriginal.id;
                } 
                catch { }
            }
            else
            {
                // Si la institución no tenía información previa, la guardo.
                return GuardarInformacion(info, imagen, video, cc);
            }

            return -1;
        }

        private string GuardarArchivoEnDisco(HttpPostedFileBase archivo, ControllerContext cc)
        {
            string path = "~/Content/Resources/Uploads/";
            string fileName = System.DateTime.Now.ToString("ddMMYYYYHHmmss") + archivo.FileName;
            string filePath = System.IO.Path.Combine(path, fileName);
            archivo.SaveAs(cc.HttpContext.Request.MapPath(filePath));

            return filePath;
        }

        private string ModificarArchivosEnDisco(string pathArchivoOriginal, HttpPostedFileBase nuevoArchivo, ControllerContext cc)
        {
            EliminarArchivo(pathArchivoOriginal);
            return (nuevoArchivo == null)? "" : GuardarArchivoEnDisco(nuevoArchivo, cc);
        }

        private void EliminarArchivo(string path)
        {
            try{ System.IO.File.Delete(path); }
            catch { }
        }

        public ActionResult EditarInformacion(int idInstitucion)
        {
            institucion institucion = mDb.institucion.Single(i => i.id == idInstitucion);
            informacion info = (institucion.informacion.HasValue) ?
                mDb.informacion.Single(inf => inf.id == institucion.informacion) :
                new informacion()
                {
                    id = -1,
                    encabezado = "",
                    introduccion = "",
                    contenido = "",
                };

            info.introduccion = info.introduccion.Replace("<br />", "\n");
            info.contenido = info.contenido.Replace("<br />", "\n");

            ViewBag.UrlImagen = info.imagen;
            ViewBag.UrlVideo = info.video;

            return PartialView(info);
        }


        private bool perteneceDocenteAInstitucion(int idInsitucion)
        {
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            try
            {
                docente_x_institucion di = mDb.docente_x_institucion.Single(d => d.institucion == idInsitucion && d.docente == idDocente);
                return true;
            }

            catch (System.InvalidOperationException e)
            {
                return false;
            }
        }

        private bool perteneceAlumnoAInstitucion(int idInsitucion)
        {
            int idAlumno = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            try
            {
                alumno_x_institucion ai = mDb.alumno_x_institucion.Single(d => d.institucion == idInsitucion && d.alumno == idAlumno);
                return true;
            }

            catch (System.InvalidOperationException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Muestra la informacion cargada de una institución específica.
        /// </summary>
        /// <param name="idInstitucion">ID de la institución de la cual se desea mostrar la información.</param>
        /// <returns>GET: /Informacion/VerInformacion</returns>
        public ActionResult VerInformacion(int idInstitucion)
        {
            institucion info = mDb.institucion.Single(inf => inf.id == idInstitucion);

            ViewBag.idInstitucion = idInstitucion;
            ViewBag.Institucion = info.nombre;
            ViewBag.Telefono = info.telefono;

            ViewBag.tipoUsuario = ControllerContext.HttpContext.Request.Cookies["datosUsuario"]["tipoUsuario"];

            if (ControllerContext.HttpContext.Request.Cookies["datosUsuario"]["tipoUsuario"] == "Docente")
            {
                ViewBag.perteneceAInstitucion = perteneceDocenteAInstitucion(idInstitucion);
            }
            else if (ControllerContext.HttpContext.Request.Cookies["datosUsuario"]["tipoUsuario"] == "Alumno")
            {
                ViewBag.perteneceAInstitucion = perteneceAlumnoAInstitucion(idInstitucion);
            }
            else
            {
                ViewBag.perteneceAInstitucion = false; //cualquier cosa, lo seteo para q no de error en la vista
            }

            ViewBag.Domicilio = info.calle + " " + info.altura_calle;
            if (info.piso.HasValue || info.departamento != null)
                ViewBag.Domicilio += " (" + info.piso + info.departamento + ")";

            ViewBag.Localidad = info.localidad1.nombre + ", " + info.localidad1.provincia1.nombre + ", " + info.localidad1.provincia1.pais1.nombre;

            if (info.informacion1 != null) 
            {
                ViewBag.Encabezado = info.informacion1.encabezado;
                ViewBag.Introduccion = info.informacion1.introduccion;
                ViewBag.Contenido = info.informacion1.contenido;
                ViewBag.UrlFoto = info.informacion1.imagen;
                ViewBag.UrlVideo = info.informacion1.video;
            }

            return View();
        }

        /// <summary>
        /// Solo para testing. No usar.
        /// </summary>
        public ActionResult GenerarVistaPrevia(string encabezado, string introduccion, string contenido, string urlFoto, string urlVideo)
        {
            ViewBag.Encabezado   = encabezado;
            ViewBag.Introduccion = introduccion;
            ViewBag.Contenido    = contenido;
            ViewBag.UrlFoto      = urlFoto;
            ViewBag.UrlVideo     = urlVideo;

            return PartialView("VerInformacion");
        }
    }
}
