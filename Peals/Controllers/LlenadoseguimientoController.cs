using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;
using System.Globalization;
using System.Web.Script.Serialization;

namespace Peals.Controllers
{
    public class LlenadoseguimientoController : Controller
    {
        //
        // GET: /Llenadoseguimiento/
        private pealsEntities mDb = new pealsEntities();


        #region VISTAS
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ModificarResolucion(int idCurso, int idAlumno, int idLlenadoSeguimiento)
        {
            usuario alumno = mDb.usuario.Single(x => x.id == idAlumno);
            curso curso = mDb.curso.Single(x => x.id == idCurso);

            ViewBag.nombreCurso = curso.nombre;
            ViewBag.idCurso = curso.id;
            ViewBag.nombreAlumno = alumno.nombre + " " + alumno.apellido;
            ViewBag.idAlumno = alumno.id;
            ViewBag.idInstitucion = curso.institucion1.id;
            ViewBag.nombreInstitucion = curso.institucion1.nombre;
            ViewBag.llenadoSeguimiento = idLlenadoSeguimiento;

            var llenadoSeguimiento =
                from lls in mDb.llenadoseguimiento
                where lls.id == idLlenadoSeguimiento
                select lls;

            var llenSegDet =
                 from llsd in mDb.llenadoseguimientodetalle
                 where llsd.llenadoseguimiento1.id == idLlenadoSeguimiento
                 select llsd;

            llenadoseguimientodetalle[] lsd = llenSegDet.ToArray();

            for (int i = 0; i < lsd.Length - 1; i++)
            {
                if (lsd[i].respuesta != null && lsd[i].respuesta.Contains("\r\n"))
                {
                    lsd[i].respuesta = lsd[i].respuesta.Replace("\r\n", "\\n");
                }
            }

            return View(lsd.ToList());
            
        }

        [HttpPost]
        public ActionResult ModificarResolucion(int idLlenadoSeguimiento, String inputJson, params HttpPostedFileBase[] adjunto)
        {
            //levantamos el llenadoSeguimiento
            llenadoseguimiento llenadoSeguimiento = mDb.llenadoseguimiento.Single(x => x.id == idLlenadoSeguimiento);

            var serializer = new JavaScriptSerializer();
            var doe = serializer.Deserialize<dynamic>(inputJson);

            var listaLlenSegDet =
                from llssdd in mDb.llenadoseguimientodetalle
                where llssdd.llenadoseguimiento1.id == idLlenadoSeguimiento
                select llssdd;

            foreach (llenadoseguimientodetalle llenSegDet in listaLlenSegDet.ToList())
            {
                foreach (var itemJson in doe)
                {
                    if (System.Int32.Parse(itemJson["id"]) == llenSegDet.item)
                    {
                        String resolucion = "";

                        if (itemJson["tipoItem"] == "unaLinea" || itemJson["tipoItem"] == "multilinea")
                        {
                            llenSegDet.respuesta = itemJson["resolucion"];
                        }
                        else if (itemJson["tipoItem"] == "opciones")
                        {
                            resolucion = itemJson["resolucion"];
                            var opcion =
                                from op in mDb.opcion
                                where op.item1.id == llenSegDet.item && op.descripcion == resolucion
                                select op;
                            llenSegDet.opcion = opcion.First().id;
                        }
                        else //con adjunto
                        {
                            resolucion = itemJson["resolucion"];
                            if (!resolucion.Contains("No borrar id llenadoSeguimientoDetalle:"))
                            {
                                foreach (var adj in adjunto.ToArray())
                                {
                                    if (adj.FileName == resolucion)
                                    {
                                        //guardamos el archivo en disco.
                                        GuardarArchivoEnDisco(adj, ControllerContext);
                                        llenSegDet.adjunto = resolucion;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (mDb.SaveChanges() > 0)
            {
                return RedirectToAction("DiacOSeguimiento", "Docente", new { idCurso = llenadoSeguimiento.curso });
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Resolucion(int idCurso, int idAlumno, string identificador)
        {
            usuario alumno = mDb.usuario.Single(x => x.id == idAlumno);
            curso curso = mDb.curso.Single(x => x.id == idCurso);

            ViewBag.nombreCurso = curso.nombre;
            ViewBag.idCurso = curso.id;
            ViewBag.nombreAlumno = alumno.nombre + " " + alumno.apellido;
            ViewBag.idAlumno = alumno.id;
            ViewBag.idInstitucion = curso.institucion1.id;
            ViewBag.nombreInstitucion = curso.institucion1.nombre;
            ViewBag.identificador = identificador;

            if (identificador == "DIAC")
            {
                var diac =
                from d in mDb.diac
                where d.institucion == curso.institucion1.id && d.activo == 1
                select d;
                if (diac.ToList().Count > 0)
                {
                    diac oDiac = diac.ToList().First();

                    var items =
                        from it in mDb.item
                        where it.diac1.id == oDiac.id
                        orderby it.ordenGrupo, it.ordenItem
                        select it;

                    ViewBag.idDiac = diac.First().id;
                    return View(items.ToList());
                }
                else
                {
                    ViewBag.error = "No hay DIAC creada por el administrador";
                    return View("ErrorConMensaje");
                }
            }
            else //seguimiento
            {
                var seguimiento =
                from d in mDb.seguimiento
                where d.curso == curso.id && d.activo == 1
                select d;
                if (seguimiento.ToList().Count > 0)
                {
                    seguimiento oSeguimiento = seguimiento.ToList().First();

                    var items =
                        from it in mDb.item
                        where it.seguimiento1.id == oSeguimiento.id
                        orderby it.ordenGrupo, it.ordenItem
                        select it;

                    ViewBag.idDiac = seguimiento.First().id;
                    return View(items.ToList());
                }
                else
                {
                    ViewBag.error = "No hay Seguimiento creado";
                    return View("ErrorConMensaje");
                }
            }
            
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Resolucion(String inputJson, String inputIdentificador, Int32 idDiac, Int32 idAlumno, Int32 idCurso, params HttpPostedFileBase[] adjunto)
        {
            var serializer = new JavaScriptSerializer();
            var doe = serializer.Deserialize<dynamic>(inputJson);

            llenadoseguimiento llenadoSeguimiento = new llenadoseguimiento();

            if (inputIdentificador == "DIAC")
            {
                llenadoSeguimiento.diac = idDiac;
            }
            else //seguimiento
            {
                llenadoSeguimiento.seguimiento = idDiac;
            }

            
            
            llenadoSeguimiento.fecha = DateTime.Today;
            llenadoSeguimiento.alumno = idAlumno;
            llenadoSeguimiento.curso = idCurso;
            llenadoSeguimiento.docente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            mDb.llenadoseguimiento.AddObject(llenadoSeguimiento);

            foreach (var itemJson in doe)
            {
                llenadoseguimientodetalle llenadoSeguimientoDetalle = new llenadoseguimientodetalle();
                llenadoSeguimientoDetalle.llenadoseguimiento = llenadoSeguimiento.id;
                llenadoSeguimientoDetalle.item = System.Int32.Parse(itemJson["id"]);

                if (itemJson["tipoItem"] == "unaLinea" || itemJson["tipoItem"] == "multilinea")
                {
                    llenadoSeguimientoDetalle.respuesta = itemJson["resolucion"];
                }
                else if (itemJson["tipoItem"] == "opciones")
                {
                    String resolucion = itemJson["resolucion"];
                    var opcion =
                        from op in mDb.opcion
                        where op.item1.id == llenadoSeguimientoDetalle.item && op.descripcion == resolucion
                        select op;
                    llenadoSeguimientoDetalle.opcion = opcion.First().id;
                }
                else //con adjunto
                {
                    String resolucion = itemJson["resolucion"];
                    foreach (var adj in adjunto.ToArray())
                    {
                        if (adj != null && adj.FileName == resolucion)
                        {
                            //guardamos el archivo en disco.
                            GuardarArchivoEnDisco(adj, ControllerContext);
                            llenadoSeguimientoDetalle.adjunto = resolucion;
                        }
                    }
                }

                mDb.llenadoseguimientodetalle.AddObject(llenadoSeguimientoDetalle);
            }

            if (mDb.SaveChanges() > 0)
            {
                if (inputIdentificador == "DIAC")
                {
                    return RedirectToAction("MenuDiacCurso", "Diac", new { idCurso = idCurso });
                }
                else
                {
                    return RedirectToAction("MenuSeguimientoCurso", "Seguimiento", new { idCurso = idCurso });
                }
                
            }
            else
            {
                return View("Error");
            }
        }

        #endregion

        private string GuardarArchivoEnDisco(HttpPostedFileBase archivo, ControllerContext cc)
        {
            string path = "~/Content/Resources/Uploads/";

            string filePath = System.IO.Path.Combine(path, archivo.FileName);
            archivo.SaveAs(cc.HttpContext.Request.MapPath(filePath));

            return filePath;
        }




        #region PARTIAL_VIEWS

        /// <summary>
        /// Devuelve un listado con TODOS los alumnos y los datos de si se ha resuelto la diac para un
        /// lapso determinado de tiempo.
        /// </summary>
        /// <returns></returns>
        public ActionResult _DiacResueltas(String fechaDesde, String fechaHasta, Int32 idCurso, string identificador, string alumno)
        {
            DateTime dFechaDesde;
            DateTime dFechaHasta;

            try
            {
                dFechaDesde = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                dFechaDesde = DateTime.ParseExact("01/01/1950", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            try
            {
                dFechaHasta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            catch (Exception e)
            {
                dFechaHasta = DateTime.ParseExact("01/01/2200", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            //recupero el ID del usuario de la sesión
            int idDocente = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            ViewBag.identificador = identificador;
            ViewBag.curso = idCurso;

            var llenadoSeguimiento =
                from ls in mDb.llenadoseguimiento
                from al in mDb.usuario
                where ls.docente == idDocente && ls.curso == idCurso && ls.fecha >= dFechaDesde.Date && ls.fecha <= dFechaHasta.Date && ls.diac != null && al.id == ls.alumno && al.mail.Contains(alumno)
                select ls;

            if (identificador == "SEGUIMIENTO")
            {
                llenadoSeguimiento =
                from ls in mDb.llenadoseguimiento
                from al in mDb.usuario
                where ls.docente == idDocente && ls.curso == idCurso && ls.fecha >= dFechaDesde.Date && ls.fecha <= dFechaHasta.Date && ls.seguimiento != null && al.id == ls.alumno && al.mail.Contains(alumno)
                select ls;
            }

            ViewBag.Cursos_DefaultMessage = "No hay ninguna resolución en este intervalo de tiempo.";

            return PartialView(llenadoSeguimiento.ToList());

        }


        public ActionResult _AlumnosResolucionCurso(String fechaDesde, String fechaHasta, Int32 idCurso, string identificador, string alumno)
        {

            DateTime dFechaDesde;
            DateTime dFechaHasta;

            try
            {
                dFechaDesde = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                dFechaDesde = DateTime.ParseExact("01/01/1950", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            try
            {
                dFechaHasta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            catch (Exception e)
            {
                dFechaHasta = DateTime.ParseExact("01/01/2200", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            ViewBag.curso = idCurso;
            ViewBag.identificador = identificador;

            //var alumnos =
            //        from al in mDb.usuario
            //        join al_cu in mDb.alumno_x_curso on al.id equals al_cu.alumno
            //        join cu in mDb.curso on al_cu.curso equals cu.id into cur
            //        join llss in mDb.llenadoseguimiento on new { al_cu.alumno, al_cu.curso } equals new { llss.alumno, llss.curso } into pete
            //        from petee in pete.DefaultIfEmpty()
            //        where al_cu.curso == idCurso
            //        select new
            //        {
            //            al.id,
            //            al.nombre,
            //            al.apellido,
            //            al.mail,
            //            resuelto = (petee.fecha >= dFechaDesde && petee.fecha <= dFechaHasta && petee.diac != null) ? "Si" : "No",
            //            diac = (petee.diac1.id == null) ? 0 : petee.diac1.id,
            //            llenadoSeguimientoId = (petee.id == null) ? 0 : petee.id
            //        };

            var alumnos =
                from al in mDb.usuario
                join al_cu in mDb.alumno_x_curso on al.id equals al_cu.alumno
                join cu in mDb.curso on al_cu.curso equals cu.id into cur
                where al_cu.curso == idCurso && al.mail.Contains(alumno)
                select new
                {
                    al.id,
                    al.nombre,
                    al.apellido,
                    al.mail
                };


            if (identificador == "SEGUIMIENTO")
            {
                //alumnos =
                //    from al in mDb.usuario
                //    join al_cu in mDb.alumno_x_curso on al.id equals al_cu.alumno
                //    join cu in mDb.curso on al_cu.curso equals cu.id into cur
                //    join llss in mDb.llenadoseguimiento on new { al_cu.alumno, al_cu.curso } equals new { llss.alumno, llss.curso } into pete
                //    from petee in pete.DefaultIfEmpty()
                //    where al_cu.curso == idCurso
                //    select new
                //    {
                //        al.id,
                //        al.nombre,
                //        al.apellido,
                //        al.mail,
                //        resuelto = (petee.fecha >= dFechaDesde && petee.fecha <= dFechaHasta && petee.seguimiento != null) ? "Si" : "No",
                //        diac = (petee.seguimiento1.id == null) ? 0 : petee.seguimiento1.id,
                //        llenadoSeguimientoId = (petee.id == null) ? 0 : petee.id
                //    };
            }
            ViewBag.Alumnos_DefaultMessage = "No hay ningún alumno inscripto en esta institución.";
            return PartialView(alumnos);
        }

        public ActionResult _SeleccionarVersion(Int32 idCurso, Int32 idAlumno, String identificador)
        {
            ViewBag.idCurso = idCurso;
            ViewBag.idAlumno = idAlumno;
            ViewBag.identificador = identificador;


            var resoluciones =
                from llsd in mDb.llenadoseguimiento
                where llsd.alumno == idAlumno && llsd.curso == idCurso && llsd.diac != null
                orderby llsd.id descending
                select llsd;

            if (identificador == "SEGUIMIENTO")
            {
                resoluciones =
                from llsd in mDb.llenadoseguimiento
                where llsd.alumno == idAlumno && llsd.curso == idCurso && llsd.seguimiento != null
                orderby llsd.id ascending
                select llsd;
            }
            
            
            
            

           
            return PartialView(resoluciones);
        }

        #endregion

    }
}
