using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Peals.Models;

namespace Peals.Controllers
{
    public class DiacController : Controller
    {
        private pealsEntities db = new pealsEntities();

        public ActionResult Index()
        {
            Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var institucion =
                from i in db.institucion
                where i.administrador == idUsuario
                select i;
            ViewData["institucion"] = new SelectList(institucion.ToList(), "id", "nombre");

            return View();
        }

        public ActionResult MenuResolucion()
        {
            Int32 idUsuario = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            var institucion =
                from i in db.institucion
                join curs in db.curso on i.id equals curs.institucion
                where curs.docente == idUsuario
                select i;
            ViewData["institucion"] = new SelectList(institucion.Distinct().ToList(), "id", "nombre");
            return View();
        }

        public ActionResult MenuDiacCurso(String idCurso)
        {
            ViewBag.idCurso = idCurso;
            Int32 idCursoInt = Int32.Parse(idCurso);
            ViewBag.nombreCurso = db.curso.First(x => x.id == idCursoInt).nombre;
            return View();
        }

        [HttpGet]
        public ActionResult NuevoDiac(Int32 idInstitucion)
        {
            ViewBag.idInstitucion = idInstitucion;
            return View();
        }

        [HttpPost]
        public ActionResult NuevoDiac(string inputJson, string inputInstitucion)
        {
            var serializer = new JavaScriptSerializer(); // asp.net mvc (de)serializer
            var doe = serializer.Deserialize<dynamic>(inputJson);
            diac d = crearDiac(inputInstitucion);

            foreach (var itemJson in doe)
            {
                item item = new item();
                item.descripcion = itemJson["tituloItem"];
                item.grupo = itemJson["grupo"];
                item.ordenGrupo = itemJson["nroOrdenGrupo"];
                item.diac1 = d;

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
                var institucion =
                    from i in db.institucion
                    where i.administrador == idUsuario
                    select i;
                ViewData["institucion"] = new SelectList(institucion.ToList(), "id", "nombre");
                return View("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult verDiacCreada(Int32 idInstitucion)
        {
            var diac =
                from d in db.diac
                where d.institucion == idInstitucion && d.activo == 1
                select d;
            diac oDiac = diac.ToList().First();

            ViewBag.institucion = oDiac.institucion1.nombre;

            var items =
                from it in db.item
                where it.diac1.id == oDiac.id
                orderby it.ordenGrupo, it.ordenItem
                select it;

            return View(items.ToList());
        }

        public ActionResult modificarDiac(Int32 idInstitucion)
        {
            var diac =
                from d in db.diac
                where d.institucion == idInstitucion && d.activo == 1
                select d;
            diac oDiac = diac.ToList().First();

            ViewBag.idInstitucion = idInstitucion;

            var items =
                from it in db.item
                where it.diac1.id == oDiac.id
                orderby it.ordenGrupo, it.ordenItem
                select it;

            return View(items.ToList());
        }


        [HttpPost]
        public ActionResult ModificarDiac(string inputJson, string inputInstitucion)
        {
            var serializer = new JavaScriptSerializer(); // asp.net mvc (de)serializer
            var doe = serializer.Deserialize<dynamic>(inputJson);
            Int32 idInst = Int32.Parse(inputInstitucion);
            diac diacAntigua = db.diac.First(x => (x.institucion1.id == idInst && x.activo == 1));
            
            diacAntigua.activo = 0;
            //db.diac.AddObject(diacAntigua);

            diac d = crearDiac(inputInstitucion);

            foreach (var itemJson in doe)
            {
                item item = new item();
                item.descripcion = itemJson["tituloItem"];
                item.grupo = itemJson["grupo"];
                item.ordenGrupo = itemJson["nroOrdenGrupo"];
                item.diac1 = d;

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
                var institucion =
                    from i in db.institucion
                    where i.administrador == idUsuario
                    select i;
                ViewData["institucion"] = new SelectList(institucion.ToList(), "id", "nombre");
                return View("Index");
            }
            else
            {
                return View("Error");
            }
        }



        public diac crearDiac(string inputInstitucion)
        {
            diac diac = new diac();
            diac.institucion = Int32.Parse(inputInstitucion);
            diac.activo = 1;
            db.diac.AddObject(diac);
            return diac;
        }


        [HttpPost]
        public ActionResult TieneDiac(String idInstitucion)
        {

            Int32 id_institucion = Int32.Parse(idInstitucion);
            var diac =
                from di in db.diac
                where di.institucion == id_institucion
                select di;

            if (diac.ToList().Count == 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ObtenerOpciones(String idItem)
        {
            String resultado = "";
            String separador = "";
            Int32 id_item = Int32.Parse(idItem);
            var opciones =
                from op in db.opcion
                where op.item1.id == id_item
                select op;

            if (opciones.ToList().Count > 0)
            {
                foreach (opcion oOpcion in opciones.ToList<opcion>())
                {
                    resultado = resultado + separador + oOpcion.descripcion;
                    separador = "|";
                }
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}
