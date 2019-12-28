using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;

namespace Peals.Controllers
{
    public class EjercicioController : Controller
    {
        private pealsEntities mDb = new pealsEntities();
        
        // GET: /Ejercicio/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ResolverEjercicio(int idActividad, int nroEjercicio)
        {
            ejercicio[] ejerciciosActividad = mDb.ejercicio.Where(x => x.actividad == idActividad).ToArray();
            int idEjercicio = ejerciciosActividad[nroEjercicio].id; 
            List<ejercicio_x_recurso> recursos = mDb.ejercicio_x_recurso.Where(x => x.ejercicio1.id == idEjercicio).OrderBy(x => x.id).ToList();

            if (ejerciciosActividad[nroEjercicio].senia1 != null)
                ViewBag.senia = ejerciciosActividad[nroEjercicio].senia1.clase;
            
            ViewBag.textoSolucion = ejerciciosActividad[nroEjercicio].texto_solucion;
            ViewBag.deletreo = ejerciciosActividad[nroEjercicio].deletreo;

            ViewBag.recursoCorrecto = ejerciciosActividad[nroEjercicio].recurso_correcto;

            return PartialView(recursos);
        }

        [HttpPost]
        public ActionResult getCantidadEjercicios(int idActividad)
        {
            ejercicio[] ejerciciosActividad = mDb.ejercicio.Where(x => x.actividad == idActividad).ToArray();

            return Json(new { cantidadEjercicios = ejerciciosActividad.Count() }, JsonRequestBehavior.AllowGet);
        }

        #region ACTIVIDAD SEÑA
        public ActionResult _ResolverEjercicioSenias(String senia)
        {
            senia sen = mDb.senia.FirstOrDefault(x => x.clase.Equals(senia));
            ViewBag.ayuda = sen.ruta;
            ViewBag.senia = senia;
            ViewBag.esCara = sen.esCara == true ? 1 : 0;

            return PartialView();
        }
        #endregion

        #region ACTIVIDAD TEXTO
        public ActionResult _ResolverEjercicioTexto()
        {
            return PartialView();
        }
        #endregion

        #region ACTIVIDAD RECURSO CORRECTO
        public ActionResult _ResolverEjercicioRecursoCorrecto()
        {
            return PartialView();
        }
        #endregion
    }
}
