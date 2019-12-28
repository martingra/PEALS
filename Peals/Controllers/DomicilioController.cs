using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;

namespace Peals.Controllers
{
    public class DomicilioController : Controller
    {
        private pealsEntities db = new pealsEntities();

        [ActionName("Paises")]
        public ActionResult GetPaises(int id)
        {
            //obtengo todos los paises
            var paises =
                db.pais.ToList();

            SelectList Data = new SelectList(paises.ToArray(),
                                "id",
                                "nombre");

            return Json(Data, JsonRequestBehavior.AllowGet);

        }

        [ActionName("ProvinciaPorPais")]
        public ActionResult GetProvinciasPorPais(int id)
        {
            //obtengo las provincias
            var provincias =
                db.provincia.ToList().FindAll(x => x.pais == id).OrderBy(x => x.nombre);

            SelectList Data = new SelectList(provincias.ToArray(),
                                "id",
                                "nombre");

            return Json(Data, JsonRequestBehavior.AllowGet);

        }

        [ActionName("LocalidadPorProvincia")]
        public ActionResult GetLocalidadesPorProvincia(int id)
        {
            //obtengo las localidades
            var localidades =
                db.localidad.ToList().FindAll(x => x.provincia == id).OrderBy(x => x.nombre);

            SelectList Data = new SelectList(localidades.ToArray(),
                                "id",
                                "nombre");

            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        public SelectList GetSelectListProvinciasPorPais(int id, int indiceSeleccionado)
        {
            //obtengo las provincias
            var provincias =
                db.provincia.ToList().FindAll(x => x.pais == id).OrderBy(x => x.nombre);

            SelectList data = new SelectList(provincias.ToArray(),
                                "id",
                                "nombre", indiceSeleccionado);
            return data;
        }

        public SelectList GetSelectListLocalidadesPorProvincia(int id, int indiceSeleccionado)
        {
            //obtengo las localidades
            var localidades =
                db.localidad.ToList().FindAll(x => x.provincia == id).OrderBy(x => x.nombre);

            SelectList data = new SelectList(localidades.ToArray(),
                                "id",
                                "nombre", indiceSeleccionado);
            return data;
        }

    }
}
