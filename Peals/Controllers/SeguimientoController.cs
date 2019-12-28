using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;
using System.Web.Script.Serialization;

namespace Peals.Controllers
{
    public class SeguimientoController : Controller
    {
        private pealsEntities db = new pealsEntities();

        #region VIEWS

        public ActionResult Index()
        {
            Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var cursos =
                from c in db.curso
                where c.docente == idUsuario
                select c;
            ViewData["cursos"] = new SelectList(cursos.ToList(), "id", "nombre");

            return View();
        }


        [HttpGet]
        public ActionResult NuevoSeguimiento(Int32 idCurso)
        {
            ViewBag.idCurso = idCurso;
            return View();
        }

        [HttpPost]
        public ActionResult NuevoSeguimiento(string inputJson, string inputCurso)
        {
            var serializer = new JavaScriptSerializer(); // asp.net mvc (de)serializer
            var doe = serializer.Deserialize<dynamic>(inputJson);
            seguimiento d = crearSeguimiento(inputCurso);

            foreach (var itemJson in doe)
            {
                item item = new item();
                item.descripcion = itemJson["tituloItem"];
                item.grupo = itemJson["grupo"];
                item.ordenGrupo = itemJson["nroOrdenGrupo"];
                item.seguimiento1 = d;

                switch ((String)itemJson["tipoItem"])
                {
                    case "Una línea":
                        item.tipoItem = (int)TipoDiac.unaLinea;
                        break;
                    case "Multiples líneas":
                        item.tipoItem = (int)TipoDiac.multiplesLineas;
                        break;
                    case "Con opciones":
                        item.tipoItem = (int)TipoDiac.conOpciones;
                        break;
                    case "Con Adjunto":
                        item.tipoItem = (int)TipoDiac.conAdjunto;
                        break;
                }

                item.ayuda = itemJson["ayudaItem"];
                item.ordenItem = itemJson["nroOrdenItem"];

                db.item.AddObject(item);

                //agrego items
                String opts = itemJson["opcionesItem"];

                if (opts == "" || opts == null)
                {
                    //sin opciones
                }
                else
                {
                    foreach (var itemOpcionStr in opts.Split('|'))
                    {
                        opcion opcionItem = new opcion();
                        opcionItem.item1 = item;
                        opcionItem.descripcion = itemOpcionStr;
                        db.opcion.AddObject(opcionItem);
                    }
                }
            }

            if (db.SaveChanges() > 0)
            {
                Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                var cursos =
                    from c in db.curso
                    where c.docente == idUsuario
                    select c;
                ViewData["cursos"] = new SelectList(cursos.ToList(), "id", "nombre");
                return View("Index");
            }
            else
            {
                return View("Error");
            }
        }

        #endregion


        #region
        [HttpPost]
        public ActionResult TieneSeguimiento(String idCurso)
        {
            Int32 id_curso = Int32.Parse(idCurso);
            var seguimiento =
                from se in db.seguimiento
                where se.curso == id_curso
                select se;

            if (seguimiento.ToList().Count == 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public seguimiento crearSeguimiento(string inputCurso)
        {
            seguimiento seguimiento = new seguimiento();
            seguimiento.curso = Int32.Parse(inputCurso);
            seguimiento.activo = 1;
            db.seguimiento.AddObject(seguimiento);
            return seguimiento;
        }

        public ActionResult verSeguimientoCreado(Int32 idCurso)
        {
            var seguimiento =
                from d in db.seguimiento
                where d.curso == idCurso && d.activo == 1
                select d;
            seguimiento oSeguimiento = seguimiento.ToList().First();

            ViewBag.curso = oSeguimiento.curso1.nombre;

            var items =
                from it in db.item
                where it.seguimiento1.id == oSeguimiento.id
                orderby it.ordenGrupo, it.ordenItem
                select it;

            return View(items.ToList());
        }



        public ActionResult modificarSeguimiento(Int32 idCurso)
        {
            var seguimiento =
                from d in db.seguimiento
                where d.curso == idCurso && d.activo == 1
                select d;
            seguimiento oSeguimiento = seguimiento.ToList().First();

            ViewBag.idCurso = idCurso;

            var items =
                from it in db.item
                where it.seguimiento1.id == oSeguimiento.id
                orderby it.ordenGrupo, it.ordenItem
                select it;

            return View(items.ToList());
        }


        [HttpPost]
        public ActionResult modificarSeguimiento(string inputJson, string inputCurso)
        {
            var serializer = new JavaScriptSerializer(); // asp.net mvc (de)serializer
            var doe = serializer.Deserialize<dynamic>(inputJson);
            Int32 idCurs = Int32.Parse(inputCurso);
            seguimiento seguimientoAntiguo = db.seguimiento.First(x => (x.curso1.id == idCurs && x.activo == 1));

            seguimientoAntiguo.activo = 0;
            //db.diac.AddObject(diacAntigua);

            seguimiento d = crearSeguimiento(inputCurso);

            foreach (var itemJson in doe)
            {
                item item = new item();
                item.descripcion = itemJson["tituloItem"];
                item.grupo = itemJson["grupo"];
                item.ordenGrupo = itemJson["nroOrdenGrupo"];
                item.seguimiento1 = d;

                switch ((String)itemJson["tipoItem"])
                {
                    case "Una línea":
                        item.tipoItem = (int)TipoDiac.unaLinea;
                        break;
                    case "Multiples líneas":
                        item.tipoItem = (int)TipoDiac.multiplesLineas;
                        break;
                    case "Con opciones":
                        item.tipoItem = (int)TipoDiac.conOpciones;
                        break;
                    case "Con Adjunto":
                        item.tipoItem = (int)TipoDiac.conAdjunto;
                        break;
                }

                item.ayuda = itemJson["ayudaItem"];
                item.ordenItem = itemJson["nroOrdenItem"];

                db.item.AddObject(item);

                //agrego items
                String opts = itemJson["opcionesItem"];

                if (opts == "" || opts == null)
                {
                    //sin opciones
                }
                else
                {
                    foreach (var itemOpcionStr in opts.Split('|'))
                    {
                        opcion opcionItem = new opcion();
                        opcionItem.item1 = item;
                        opcionItem.descripcion = itemOpcionStr;
                        db.opcion.AddObject(opcionItem);
                    }
                }
            }

            if (db.SaveChanges() > 0)
            {
                Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                var cursos =
                    from c in db.curso
                    where c.docente == idUsuario
                    select c;
                ViewData["cursos"] = new SelectList(cursos.ToList(), "id", "nombre");
                return View("Index");
            }
            else
            {
                return View("Error");
            }
        }


        public ActionResult MenuSeguimientoCurso(String idCurso)
        {
            ViewBag.idCurso = idCurso;
            Int32 idCursoInt = Int32.Parse(idCurso);
            ViewBag.nombreCurso = db.curso.First(x => x.id == idCursoInt).nombre;
            return View();
        }



        #endregion
    }
}
