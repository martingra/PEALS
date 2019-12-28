using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;

namespace Peals.Controllers
{
    public class HistorialActividadController : Controller
    {
        //
        // GET: /HistorialActividad/
        private pealsEntities mDb = new pealsEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult historialAlumnoActividad(int idAlumno, int idActividad, int idCurso)
        {
            //List<historial_actividad> has = mDb.historial_actividad.Where(x=> x.alumno == idAlumno && x.actividad1.id == idActividad).ToList();
            var hist =
                from has in mDb.historial_actividad
                join c in mDb.curso on has.curso equals c.id
                where has.actividad1.id == idActividad && has.alumno == idAlumno && has.curso == idCurso
                select new
                {
                    id = has.id,
                    cursoAno = c.ano,
                    cursoDivision = c.division,
                    cursoNombre = c.nombre,
                    idCurso = c.id,
                    institucion = c.institucion1.nombre,
                    calificacion_docente = has.calificacion_docente,
                    calificacion_sistema = has.calificacion_sistema,
                    fecha_realizacion = has.fecha_realizacion,
                    actividad = has.actividad1.nombre,
                    tiempo = has.tiempo
                };


            curso oCurso = mDb.curso.First(x=>x.id == idCurso);
            actividad oActividad = mDb.actividad.First(x => x.id == idActividad);

            ViewBag.Actividad = oActividad.nombre;
            ViewBag.Curso = oCurso.ano + oCurso.division + "-" + oCurso.nombre;
            ViewBag.Institucion = oCurso.institucion1.nombre;

            ViewBag.IdActividad = idActividad;
            ViewBag.IdCurso = idCurso;

            return View(hist);
        }

    }
}
