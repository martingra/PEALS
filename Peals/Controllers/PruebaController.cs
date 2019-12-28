using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;

namespace Peals.Controllers
{ 
    public class PruebaController : Controller
    {
        private pealsEntities db = new pealsEntities();

        //
        // GET: /Prueba/

        public ViewResult Index()
        {
            var institucion = db.institucion.Include("informacion1").Include("usuario").Include("localidad1");
            return View(institucion.ToList());
        }

        //
        // GET: /Prueba/Details/5

        public ViewResult Details(int id)
        {
            institucion institucion = db.institucion.Single(i => i.id == id);
            return View(institucion);
        }

        //
        // GET: /Prueba/Create

        public ActionResult Create()
        {
            ViewBag.informacion = new SelectList(db.informacion, "id", "contenido");
            ViewBag.administrador = new SelectList(db.usuario, "id", "mail");
            ViewBag.localidad = new SelectList(db.localidad, "id", "nombre");
            return View();
        } 

        //
        // POST: /Prueba/Create

        [HttpPost]
        public ActionResult Create(institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.institucion.AddObject(institucion);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.informacion = new SelectList(db.informacion, "id", "contenido", institucion.informacion);
            ViewBag.administrador = new SelectList(db.usuario, "id", "mail", institucion.administrador);
            ViewBag.localidad = new SelectList(db.localidad, "id", "nombre", institucion.localidad);
            return View(institucion);
        }
        
        //
        // GET: /Prueba/Edit/5
 
        public ActionResult Edit(int id)
        {
            institucion institucion = db.institucion.Single(i => i.id == id);
            ViewBag.informacion = new SelectList(db.informacion, "id", "contenido", institucion.informacion);
            ViewBag.administrador = new SelectList(db.usuario, "id", "mail", institucion.administrador);
            ViewBag.localidad = new SelectList(db.localidad, "id", "nombre", institucion.localidad);
            return View(institucion);
        }

        //
        // POST: /Prueba/Edit/5

        [HttpPost]
        public ActionResult Edit(institucion institucion)
        {
            if (ModelState.IsValid)
            {
                db.institucion.Attach(institucion);
                db.ObjectStateManager.ChangeObjectState(institucion, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.informacion = new SelectList(db.informacion, "id", "contenido", institucion.informacion);
            ViewBag.administrador = new SelectList(db.usuario, "id", "mail", institucion.administrador);
            ViewBag.localidad = new SelectList(db.localidad, "id", "nombre", institucion.localidad);
            return View(institucion);
        }

        //
        // GET: /Prueba/Delete/5
 
        public ActionResult Delete(int id)
        {
            institucion institucion = db.institucion.Single(i => i.id == id);
            return View(institucion);
        }

        //
        // POST: /Prueba/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            institucion institucion = db.institucion.Single(i => i.id == id);
            db.institucion.DeleteObject(institucion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ProbandoAutocompletar()
        {
            return View();
        }



        public ActionResult Autocomplete(string term)
        {
            //var items = new[] { "Apple", "Pear", "Banana", "Pineapple", "Peach" };

            //var filteredItems = items.Where(
            //    item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
            //    );
            //return Json(filteredItems, JsonRequestBehavior.AllowGet);
            return View();
        }

        public JsonResult Autocomplete2(string parametro)
        {
            var instituciones =
                from i in db.institucion
                where i.nombre.Contains(parametro)
                select new
                {
                    i.nombre,
                    i.id
                };
            return Json(instituciones.Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProbandoAutocompletarAjax()
        {
            return View();
        }

        #region Test Drag-And-Drop

        public ActionResult ProbandoDragAndDrop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProbandoDragAndDrop(HttpPostedFileBase imagen)
        {
            HttpPostedFileBase url = Request.Files["imagen"];
            string text = System.IO.Path.GetFileName(Request.Files[0].FileName);

            var stream = Request.InputStream;
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);

            return View();
        }


        public ActionResult ProbandoGaleria()
        {
            ViewBag.imagenes = db.recurso.Where(x => x.tipo_recurso == 1).ToList();
            ViewBag.audios = db.recurso.Where(x => x.tipo_recurso == 2).ToList();
            ViewBag.videos = db.recurso.Where(x => x.tipo_recurso == 3).ToList();

            return View(db.recurso.ToList());
        }

        public ActionResult ProbandoGrabadores()
        {
            return View();
        }

        #endregion
    }
}