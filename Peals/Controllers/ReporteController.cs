using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;
using Peals.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data;
using System.Globalization;

namespace Peals.Controllers
{
    public class ReporteController : Controller//PdfViewController
    {
        //
        // GET: /Reporte/
        private pealsEntities mDb = new pealsEntities();


        #region ADMINISTRADOR
        public ActionResult InstitucionCursos(Int32 idInstitucion)
        {
            var mostrar =
                from c in mDb.curso
                where c.institucion == idInstitucion && c.estado == 1
                select c;

            InstitucionCursos ds = new Peals.Reportes.InstitucionCursos();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (curso curso in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = curso.id;
                row["nombre"] = curso.nombre;
                row["ano"] = curso.ano;
                row["division"] = curso.division;
                row["nivel"] = curso.nivel1.nombre;
                row["turno"] = curso.turno1.nombre;

                if (curso.es_publico == true)
                {
                    row["es_publico"] = "Si";
                }
                else 
                {
                    row["es_publico"] = "No";
                }
                

                if (curso.docente != null)
                {
                    usuario docente = mDb.usuario.Single(usr => usr.id == curso.docente);
                    row["docente"] = docente.nombre + " " + docente.apellido;
                }
                else
                {
                    row["docente"] = "Sin asignar";
                }

                row["institucion"] = curso.institucion1.nombre;
                row["impresoPor"] = impresoPor.mail;
                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "InstitucionCursosRpt.rpt");
        }

        public ActionResult InstitucionDocentes(Int32 idInstitucion)
        {
            var mostrar =
                from u in mDb.usuario
                from ui in mDb.docente_x_institucion
                where u.estado_usuario1.nombre == "De Alta" && u.tipo_usuario1.nombre == "Docente" && ui.docente == u.id && ui.institucion == idInstitucion
                select u;

            InstitucionDocentesDs ds = new Peals.Reportes.InstitucionDocentesDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (usuario usuario in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = usuario.id;
                row["nombre"] = usuario.nombre;
                row["apellido"] = usuario.apellido;
                row["mail"] = usuario.mail;
                row["especialidad"] = usuario.especialidad1.nombre;
                row["fecha_nacimiento"] = usuario.fecha_nacimiento.ToString().Substring(0, 10);
                row["fecha_alta"] = usuario.fecha_alta.ToString().Substring(0, 10);


                row["institucion"] = mDb.institucion.Single(usr => usr.id == idInstitucion).nombre;
                row["impresoPor"] = impresoPor.mail;
                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "InstitucionDocentesRpt.rpt");
        }

        public ActionResult InstitucionAlumnos(Int32 idInstitucion, Int32 idCurso)
        {
            var mostrar =
                from u in mDb.usuario
                from uc in mDb.alumno_x_curso
                where u.estado_usuario1.nombre == "De Alta" 
                    && u.tipo_usuario1.nombre == "Alumno" 
                    && uc.alumno == u.id 
                    && uc.curso == idCurso
                select u;
            
            if (idCurso == 0)
            {
                mostrar =
                    from u in mDb.usuario
                    from ui in mDb.alumno_x_institucion
                    where u.estado_usuario1.nombre == "De Alta" && u.tipo_usuario1.nombre == "Alumno" && ui.alumno == u.id && ui.institucion == idInstitucion
                    select u;
            }

            InstitucionAlumnosDs ds = new Peals.Reportes.InstitucionAlumnosDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (usuario usuario in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = usuario.id;
                row["nombre"] = usuario.nombre;
                row["apellido"] = usuario.apellido;
                row["mail"] = usuario.mail;
                row["localidad"] = usuario.localidad1.nombre;
                row["fecha_nacimiento"] = usuario.fecha_nacimiento.ToString().Substring(0, 10);
                row["fecha_alta"] = usuario.fecha_alta.ToString().Substring(0, 10);




                //row["cursoFiltro"] = "";
                //row["curso"] = "";
                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["cursoFiltro"] = mDb.curso.Single(crs => crs.id == idCurso).nombre;
                    row["curso"] = mDb.curso.Single(crs => crs.id == idCurso).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["cursoFiltro"] = "Todos";
 
                    var cursos =
                        from c in mDb.curso
                        from u in mDb.usuario
                        from ui in mDb.alumno_x_institucion
                        from uc in mDb.alumno_x_curso
                        where u.estado_usuario1.nombre == "De Alta" 
                            && u.tipo_usuario1.nombre == "Alumno" 
                            && ui.alumno == u.id 
                            && ui.institucion == idInstitucion 
                            && uc.alumno == u.id
                            && uc.curso == c.id
                            && c.institucion == idInstitucion
                            && u.id == usuario.id
                            && ui.alumno == usuario.id
                            && uc.alumno == usuario.id
                            
                        select c;

                    String separador = "";
                    String vCursos = "";
                    foreach (curso cur in cursos.ToList())
                    {
                        vCursos = vCursos + separador + cur.nombre;
                        separador = ", ";
                    }
                    row["curso"] = vCursos;
                }
                

                row["institucion"] = mDb.institucion.Single(usr => usr.id == idInstitucion).nombre;
                row["impresoPor"] = impresoPor.mail;
                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "InstitucionAlumnosRpt.rpt");
        }

        public ActionResult InstitucionActividades(Int32 idInstitucion, Int32 idCurso)
        {
            //si me viene un curso
            var mostrar =
                from a in mDb.actividad
                from ac in mDb.actividad_x_curso
                where a.estado != 3
                    && ac.actividad == a.id
                    && ac.curso == idCurso
                    && ( ac.actividad1.estado == (int) EstadoActividad.Alta ||
                            ac.actividad1.estado == (int)EstadoActividad.ConHistorial
                        )
                select a;

            if (idCurso == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from a in mDb.actividad
                    from ac in mDb.actividad_x_curso
                    where a.estado != 3
                        && ac.actividad == a.id
                        && ac.curso1.institucion == idInstitucion
                    select a;
            }

            InstitucionActividadesDs ds = new Peals.Reportes.InstitucionActividadesDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (actividad actividad in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = actividad.id;
                row["nombre"] = actividad.nombre;
                row["fecha_alta"] = actividad.fecha_alta;
                row["descripcion"] = actividad.descripcion;

                if (actividad.es_publica == 1)
                {
                    row["es_publica"] = "Si";
                }
                else
                {
                    row["es_publica"] = "No";
                }
                
                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["curso"] = mDb.curso.Single(crs => crs.id == idCurso).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["curso"] = "Todos";
                }

                row["institucion"] = mDb.institucion.Single(usr => usr.id == idInstitucion).nombre;
                row["impresoPor"] = impresoPor.mail;
                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "InstitucionActividadesRpt.rpt");
        }

        public ActionResult diacAlumnos(Int32 idAlumno, String fechaDesde, String fechaHasta, Int32 idInstitucion)
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

            //si me viene un alumno
            var mostrar =
                from ls in mDb.llenadoseguimiento
                //from lsd in mDb.llenadoseguimientodetalle
                where ls.fecha >= dFechaDesde.Date 
                    && ls.fecha <= dFechaHasta.Date 
                    && ls.diac != null
                    && ls.alumno == idAlumno
                    //&& lsd.llenadoseguimiento == ls.id
                select ls;

            if (idAlumno == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ls in mDb.llenadoseguimiento
                    //from lsd in mDb.llenadoseguimientodetalle
                    where ls.fecha >= dFechaDesde.Date
                        && ls.fecha <= dFechaHasta.Date
                        && ls.diac != null
                        && ls.diac1.institucion1.id == idInstitucion
                        //&& lsd.llenadoseguimiento == ls.id
                    select ls;
            }

            diacAlumnosDs ds = new Peals.Reportes.diacAlumnosDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (llenadoseguimiento llenadoseguimiento in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = llenadoseguimiento.id;
                row["fecha"] = llenadoseguimiento.fecha;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                row["curso"] = llenadoseguimiento.curso1.descripcion;

                if (idAlumno != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["alumnoFiltro"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["alumnoFiltro"] = "Todos";
                }

                row["institucion"] = mDb.institucion.Single(ins => ins.id == idInstitucion).nombre;
                row["fechaDesde"] = fechaDesde;
                row["fechaHasta"] = fechaHasta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);

                foreach(llenadoseguimientodetalle detalle in llenadoseguimiento.llenadoseguimientodetalle.ToList()) 
                {
                    DataTable dataTableDetalle = ds.Tables[1];
                    DataRow rowDetalle = dataTableDetalle.NewRow();
                    rowDetalle["llenadoSeguimiento"] = detalle.llenadoseguimiento1.id;
                    rowDetalle["grupo"] = detalle.item1.grupo;
                    rowDetalle["descripcion"] = detalle.item1.descripcion;


                    if (detalle.item1.tipoItem == (int)TipoDiac.unaLinea)
                    {
                        rowDetalle["tipoItem"] = "Una Línea";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.multiplesLineas)
                    {
                        rowDetalle["tipoItem"] = "Multiples Líneas";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conOpciones)
                    {
                        rowDetalle["tipoItem"] = "Con Opciones";
                        rowDetalle["respuesta"] = detalle.opcion1.descripcion;;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conAdjunto)
                    {
                        rowDetalle["tipoItem"] = "Con Adjunto";
                        rowDetalle["respuesta"] = detalle.adjunto;
                    }


                    if (detalle.opcion1 == null)
                    {
                        rowDetalle["opcion"] = "";
                    }
                    else
                    {
                        rowDetalle["opcion"] = detalle.opcion1.descripcion;
                    }
                    
                    dataTableDetalle.Rows.Add(rowDetalle);
                }
            }

            return armarReporte(ds, "DiacAlumnosRpt.rpt");
        }

        public ActionResult diacCursos(Int32 idCurso, String fechaDesde, String fechaHasta, Int32 idInstitucion)
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

            //si me viene un curso, los de ese curso puntual
            var mostrar =
                from ls in mDb.llenadoseguimiento
                where ls.fecha >= dFechaDesde.Date
                    && ls.fecha <= dFechaHasta.Date
                    && ls.diac != null
                    && ls.curso == idCurso
                select ls;

            if (idCurso == 0)
            {
                //de todos los cursos de la institucion
                mostrar =
                    from ls in mDb.llenadoseguimiento
                    where ls.fecha >= dFechaDesde.Date
                        && ls.fecha <= dFechaHasta.Date
                        && ls.diac != null
                        && ls.curso1.institucion == idInstitucion
                    select ls;
            }

            diacAlumnosDs ds = new Peals.Reportes.diacAlumnosDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (llenadoseguimiento llenadoseguimiento in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = llenadoseguimiento.id;
                row["fecha"] = llenadoseguimiento.fecha;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                row["curso"] = llenadoseguimiento.curso1.descripcion;

                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["alumnoFiltro"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["alumnoFiltro"] = "Todos";
                }

                row["institucion"] = mDb.institucion.Single(ins => ins.id == idInstitucion).nombre;
                row["fechaDesde"] = fechaDesde;
                row["fechaHasta"] = fechaHasta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);

                foreach (llenadoseguimientodetalle detalle in llenadoseguimiento.llenadoseguimientodetalle.ToList())
                {
                    DataTable dataTableDetalle = ds.Tables[1];
                    DataRow rowDetalle = dataTableDetalle.NewRow();
                    rowDetalle["llenadoSeguimiento"] = detalle.llenadoseguimiento1.id;
                    rowDetalle["grupo"] = detalle.item1.grupo;
                    rowDetalle["descripcion"] = detalle.item1.descripcion;


                    if (detalle.item1.tipoItem == (int)TipoDiac.unaLinea)
                    {
                        rowDetalle["tipoItem"] = "Una Línea";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.multiplesLineas)
                    {
                        rowDetalle["tipoItem"] = "Multiples Líneas";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conOpciones)
                    {
                        rowDetalle["tipoItem"] = "Con Opciones";
                        rowDetalle["respuesta"] = detalle.opcion1.descripcion;;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conAdjunto)
                    {
                        rowDetalle["tipoItem"] = "Con Adjunto";
                        rowDetalle["respuesta"] = detalle.adjunto;
                    }


                    if (detalle.opcion1 == null)
                    {
                        rowDetalle["opcion"] = "";
                    }
                    else
                    {
                        rowDetalle["opcion"] = detalle.opcion1.descripcion;
                    }

                    dataTableDetalle.Rows.Add(rowDetalle);
                }
            }

            return armarReporte(ds, "DiacCursosRpt.rpt");
        }

        public ActionResult diacInstitucion(Int32 idInstitucion, String fechaDesde, String fechaHasta)
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

            //si me viene un alumno
            var mostrar =
                from ls in mDb.llenadoseguimiento
                where ls.fecha >= dFechaDesde.Date
                    && ls.fecha <= dFechaHasta.Date
                    && ls.diac != null
                    && ls.curso1.institucion == idInstitucion
                select ls;

            diacAlumnosDs ds = new Peals.Reportes.diacAlumnosDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (llenadoseguimiento llenadoseguimiento in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = llenadoseguimiento.id;
                row["fecha"] = llenadoseguimiento.fecha;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                row["curso"] = llenadoseguimiento.curso1.descripcion;

                row["alumnoFiltro"] = "Todos";

                row["institucion"] = mDb.institucion.Single(ins => ins.id == idInstitucion).nombre;
                row["fechaDesde"] = fechaDesde;
                row["fechaHasta"] = fechaHasta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);

                foreach (llenadoseguimientodetalle detalle in llenadoseguimiento.llenadoseguimientodetalle.ToList())
                {
                    DataTable dataTableDetalle = ds.Tables[1];
                    DataRow rowDetalle = dataTableDetalle.NewRow();
                    rowDetalle["llenadoSeguimiento"] = detalle.llenadoseguimiento1.id;
                    rowDetalle["grupo"] = detalle.item1.grupo;
                    rowDetalle["descripcion"] = detalle.item1.descripcion;


                    if (detalle.item1.tipoItem == (int)TipoDiac.unaLinea)
                    {
                        rowDetalle["tipoItem"] = "Una Línea";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.multiplesLineas)
                    {
                        rowDetalle["tipoItem"] = "Multiples Líneas";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conOpciones)
                    {
                        rowDetalle["tipoItem"] = "Con Opciones";
                        rowDetalle["respuesta"] = detalle.opcion1.descripcion;;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conAdjunto)
                    {
                        rowDetalle["tipoItem"] = "Con Adjunto";
                        rowDetalle["respuesta"] = detalle.adjunto;
                    }

                    if (detalle.opcion1 == null)
                    {
                        rowDetalle["opcion"] = "";
                    }
                    else
                    {
                        rowDetalle["opcion"] = detalle.opcion1.descripcion;
                    }

                    dataTableDetalle.Rows.Add(rowDetalle);
                }
            }

            return armarReporte(ds, "DiacCursosRpt.rpt");
        }

        public ActionResult diacPlantilla(Int32 idInstitucion)
        {
            var mostrar =
                from i in mDb.item
                where i.diac1.activo == 1
                    && i.diac1.institucion == idInstitucion
                orderby i.ordenGrupo
                select i;

            PlantillaDs ds = new Peals.Reportes.PlantillaDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            String grupoAnterior = "";
            foreach (item item in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                
                
                if (grupoAnterior != item.grupo) 
                {
                    grupoAnterior = item.grupo;
                    row["grupo"] = item.grupo;
                    row["impresoPor"] = impresoPor.mail;
                    row["institucion"] = mDb.institucion.Single(ins => ins.id == idInstitucion).nombre;
                    dataTable.Rows.Add(row);
                }

                DataTable dataTableDetalle = ds.Tables[1];
                DataRow rowDetalle = dataTableDetalle.NewRow();
                rowDetalle["grupo"] = item.grupo;
                
                rowDetalle["descripcion"] = item.descripcion;

                if (item.tipoItem == (int)TipoDiac.unaLinea)
                {
                    rowDetalle["tipoItem"] = "Una Línea";
                }
                else if (item.tipoItem == (int)TipoDiac.multiplesLineas)
                {
                    rowDetalle["tipoItem"] = "Multiples Líneas";
                }
                else if (item.tipoItem == (int)TipoDiac.conOpciones)
                {
                    rowDetalle["tipoItem"] = "Con Opciones";
                }
                else if (item.tipoItem  == (int)TipoDiac.conAdjunto)
                {
                    rowDetalle["tipoItem"] = "Con Adjunto";
                }
                dataTableDetalle.Rows.Add(rowDetalle);
            }

            return armarReporte(ds, "plantillaRpt.rpt");
        }

        public ActionResult resolucionActividades(Int32 idInstitucion, Int32 idActividad, String fechaDesde, String fechaHasta)
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);

            //si me viene una actividad
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.actividad == idActividad
                    && ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idActividad == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna == false ? "No" : "Si";
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad == false ? "No" : "Si";
                row["tiempo"] = historial.tiempo;
                
                row["campoFiltro"] = "Actividad: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                if (idActividad != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.actividad.Single(act => act.id == idActividad).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }

        public ActionResult resolucionCursos(Int32 idInstitucion, Int32 idCurso, String fechaDesde, String fechaHasta )
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);

            //si me viene un curso
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.curso == idCurso
                    && ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idCurso == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna == false ? "No" : "Si";
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad == false ? "No" : "Si";
                row["tiempo"] = historial.tiempo;
                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                row["campoFiltro"] = "Curso: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.curso.Single(cur => cur.id == idCurso).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }

        public ActionResult resolucionAlumnos(Int32 idInstitucion, Int32 idAlumno, String fechaDesde, String fechaHasta)
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);


            //si me viene un alumno
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.alumno == idAlumno
                    && ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idAlumno == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna == false ? "No" : "Si";
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad == false ? "No" : "Si";
                row["tiempo"] = historial.tiempo;

                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                row["campoFiltro"] = "Alumno: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                if (idAlumno != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.usuario.Single(alu => alu.id == idAlumno).nombre + " " + mDb.usuario.Single(alu => alu.id == idAlumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }

        public ActionResult resolucionDocentes(Int32 idInstitucion, Int32 idDocente, String fechaDesde, String fechaHasta)
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);

            //si me viene un docente
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.docente == idDocente
                    && ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idDocente == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.institucion == idInstitucion &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna == false ? "No" : "Si";
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad == false ? "No" : "Si";
                row["tiempo"] = historial.tiempo;

                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                row["campoFiltro"] = "Docente: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                if (idDocente != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.usuario.Single(alu => alu.id == idDocente).nombre + " " + mDb.usuario.Single(alu => alu.id == idDocente).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }

        public ActionResult armarReporte(DataSet ds, String nombreReporte)
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes"), nombreReporte));
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            try
            {
                //con este codigo te da para bajarlo
                //Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                //stream.Seek(0, SeekOrigin.Begin);
                //return File(stream, "application/pdf", "Prueba.pdf");

                //con este te lo muestra en el browser
                Stream stream = rd.ExportToStream
                (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return new FileStreamResult(stream, "application/pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    
        #endregion

        #region DOCENTE
        public ActionResult DocenteCursos()
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            var mostrar =
                from c in mDb.curso
                where c.docente == idImpresoPor && c.estado == 1
                select c;

            InstitucionCursos ds = new Peals.Reportes.InstitucionCursos();
            
            foreach (curso curso in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = curso.id;
                row["nombre"] = curso.nombre;
                row["ano"] = curso.ano;
                row["division"] = curso.division;
                row["nivel"] = curso.nivel1.nombre;
                row["turno"] = curso.turno1.nombre;

                if (curso.es_publico == true)
                {
                    row["es_publico"] = "Si";
                }
                else 
                {
                    row["es_publico"] = "No";
                }
                

                if (curso.docente != null)
                {
                    usuario docente = mDb.usuario.Single(usr => usr.id == curso.docente);
                    row["docente"] = docente.nombre + " " + docente.apellido;
                }
                else
                {
                    row["docente"] = "Sin asignar";
                }

                row["institucion"] = curso.institucion1.nombre;
                row["impresoPor"] = impresoPor.mail;
                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "DocenteCursosRpt.rpt");
        }

        public ActionResult DocenteAlumnos(Int32 idCurso)
    {
        Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
        usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

        var mostrar =
            from u in mDb.usuario
            from uc in mDb.alumno_x_curso
            where u.estado_usuario1.nombre == "De Alta"
                && u.tipo_usuario1.nombre == "Alumno"
                && uc.alumno == u.id
                && uc.curso == idCurso
            orderby u.id
            select u;

        if (idCurso == 0)
        {
            mostrar =
                from u in mDb.usuario
                from uc in mDb.alumno_x_curso
                where u.estado_usuario1.nombre == "De Alta" 
                && u.tipo_usuario1.nombre == "Alumno" 
                && uc.alumno == u.id
                && uc.curso1.docente == idImpresoPor
                && uc.curso1.estado == (int) EstadoCurso.Alta
                orderby u.id
                select u;
        }

        InstitucionAlumnosDs ds = new Peals.Reportes.InstitucionAlumnosDs();
        

        foreach (usuario usuario in mostrar.Distinct().ToList())
        {
            DataTable dataTable = ds.Tables[0];
            DataRow row = dataTable.NewRow();
            row["id"] = usuario.id;
            row["nombre"] = usuario.nombre;
            row["apellido"] = usuario.apellido;
            row["mail"] = usuario.mail;
            row["localidad"] = usuario.localidad1.nombre;

            DateTime dt = usuario.fecha_nacimiento ?? DateTime.Now;

            row["fecha_nacimiento"] = dt.ToString("dd/MM/yyyy");
            row["fecha_alta"] = usuario.fecha_alta.ToString().Substring(0, 10);

            if (idCurso != 0)
            {
                //es un curso puntual, asiq lo busco y lo pongo
                row["cursoFiltro"] = mDb.curso.Single(crs => crs.id == idCurso).nombre;
                row["curso"] = mDb.curso.Single(crs => crs.id == idCurso).nombre;
                row["institucion"] = mDb.curso.Single(crs => crs.id == idCurso).institucion1.nombre;
            }
            else
            {
                //tengo q ver todos los cursos que tiene el alumno en esta institucion
                row["cursoFiltro"] = "Todos";

                var cursos =
                    from c in mDb.curso
                    from u in mDb.usuario
                    from uc in mDb.alumno_x_curso
                    where u.estado_usuario1.nombre == "De Alta"
                        && u.tipo_usuario1.nombre == "Alumno"
                        && uc.alumno == u.id
                        && uc.curso == c.id
                        && u.id == usuario.id
                        && uc.alumno == usuario.id
                        && c.estado == (int) EstadoCurso.Alta
                        && c.docente == idImpresoPor
                    select c;

                String separador = "";
                String vCursos = "";
                String vInstituciones = "";
                foreach (curso cur in cursos.ToList())
                {
                    vCursos = vCursos + separador + cur.nombre;
                    vInstituciones = vInstituciones + separador + cur.institucion1.nombre;
                    separador = ", ";
                }
                row["curso"] = vCursos;
                row["institucion"] = vInstituciones;
            }


            //row["institucion"] = mDb.institucion.Single(usr => usr.id == idInstitucion).nombre;
            row["impresoPor"] = impresoPor.mail;
            dataTable.Rows.Add(row);
        }

        return armarReporte(ds, "InstitucionAlumnosRpt.rpt");
    }

        public ActionResult DocenteActividades(Int32 idCurso)
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            //si me viene un curso
            var mostrar =
                from a in mDb.actividad
                from ac in mDb.actividad_x_curso
                where a.estado != 3
                    && ac.actividad == a.id
                    && ac.curso == idCurso
                    && (ac.actividad1.estado == (int)EstadoActividad.Alta ||
                            ac.actividad1.estado == (int)EstadoActividad.ConHistorial
                        )
                select a;

            if (idCurso == 0)
            {
                //todas las actividades del docente
                mostrar =
                    from a in mDb.actividad
                    from ac in mDb.actividad_x_curso
                    where a.estado != 3
                        && ac.actividad == a.id
                        && ac.curso1.docente == idImpresoPor
                        && ac.curso1.estado == (int) EstadoCurso.Alta
                    select a;
            }

            InstitucionActividadesDs ds = new Peals.Reportes.InstitucionActividadesDs();
            

            foreach (actividad actividad in mostrar.Distinct().ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = actividad.id;
                row["nombre"] = actividad.nombre;
                row["fecha_alta"] = actividad.fecha_alta;
                row["descripcion"] = actividad.descripcion;

                if (actividad.es_publica == 1)
                {
                    row["es_publica"] = "Si";
                }
                else
                {
                    row["es_publica"] = "No";
                }

                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["curso"] = mDb.curso.Single(crs => crs.id == idCurso).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["curso"] = "Todos";

                    var cursos =
                        from c in mDb.curso
                        from uc in mDb.actividad_x_curso
                    where uc.curso == c.id
                        && uc.actividad1.docente == idImpresoPor
                        && uc.actividad == actividad.id
                    select c;

                    String separador = "";
                    String vCursos = "";
                    foreach (curso cur in cursos.ToList())
                    {
                        vCursos = vCursos + separador + cur.nombre;
                        separador = ", ";
                    }
                    row["institucion"] = vCursos; //guardamos en institucion los cursos, porq asi tenemos el ds

                }
                row["impresoPor"] = impresoPor.mail;
                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "DocenteActividadesRpt.rpt");
        }

        public ActionResult resolucionCursosDocente(Int32 idCurso, String fechaDesde, String fechaHasta)
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);

            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            //si me viene una actividad
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.curso == idCurso &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idCurso == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.docente == idImpresoPor &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();
            

            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna == true ? "Si" : "No";
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad == true ? "Si" : "No";
                row["tiempo"] = historial.tiempo;

                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                row["campoFiltro"] = "Curso: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.curso.Single(cur => cur.id == idCurso).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }

        public ActionResult resolucionActividadesDocente(Int32 idActividad, String fechaDesde, String fechaHasta)
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);


            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            //si me viene una actividad
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.actividad == idActividad &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idActividad == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.docente == idImpresoPor &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();
            
            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna;
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad;
                row["tiempo"] = historial.tiempo;

                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                row["campoFiltro"] = "Actividad: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                if (idActividad != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.actividad.Single(act => act.id == idActividad).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }

        public ActionResult resolucionAlumnosDocente(Int32 idAlumno, String fechaDesde, String fechaHasta)
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);

            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            //si me viene una actividad
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.alumno == idAlumno &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idAlumno == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.docente == idImpresoPor &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();
            

            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna;
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad;
                row["tiempo"] = historial.tiempo;

                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                row["campoFiltro"] = "Alumno: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                if (idAlumno != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.usuario.Single(alu => alu.id == idAlumno).nombre + " " + mDb.usuario.Single(alu => alu.id == idAlumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }

        public ActionResult diacCursosDocente(Int32 idCurso, String fechaDesde, String fechaHasta)
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

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

            //si me viene un curso, los de ese curso puntual
            var mostrar =
                from ls in mDb.llenadoseguimiento
                where ls.fecha >= dFechaDesde.Date
                    && ls.fecha <= dFechaHasta.Date
                    && ls.diac != null
                    && ls.curso == idCurso
                select ls;

            if (idCurso == 0)
            {
                //de todos los cursos de la institucion
                mostrar =
                    from ls in mDb.llenadoseguimiento
                    where ls.fecha >= dFechaDesde.Date
                        && ls.fecha <= dFechaHasta.Date
                        && ls.diac != null
                        && ls.curso1.docente == idImpresoPor
                    select ls;
            }

            diacAlumnosDs ds = new Peals.Reportes.diacAlumnosDs();
            

            foreach (llenadoseguimiento llenadoseguimiento in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = llenadoseguimiento.id;
                row["fecha"] = llenadoseguimiento.fecha;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                row["curso"] = llenadoseguimiento.curso1.descripcion;

                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["alumnoFiltro"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["alumnoFiltro"] = "Todos";
                }

                row["institucion"] = mDb.institucion.Single(ins => ins.id == llenadoseguimiento.curso1.institucion1.id).nombre;
                row["fechaDesde"] = fechaDesde;
                row["fechaHasta"] = fechaHasta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);

                foreach (llenadoseguimientodetalle detalle in llenadoseguimiento.llenadoseguimientodetalle.ToList())
                {
                    DataTable dataTableDetalle = ds.Tables[1];
                    DataRow rowDetalle = dataTableDetalle.NewRow();
                    rowDetalle["llenadoSeguimiento"] = detalle.llenadoseguimiento1.id;
                    rowDetalle["grupo"] = detalle.item1.grupo;
                    rowDetalle["descripcion"] = detalle.item1.descripcion;


                    if (detalle.item1.tipoItem == (int)TipoDiac.unaLinea)
                    {
                        rowDetalle["tipoItem"] = "Una Línea";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.multiplesLineas)
                    {
                        rowDetalle["tipoItem"] = "Multiples Líneas";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conOpciones)
                    {
                        rowDetalle["tipoItem"] = "Con Opciones";
                        rowDetalle["respuesta"] = detalle.opcion1.descripcion;;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conAdjunto)
                    {
                        rowDetalle["tipoItem"] = "Con Adjunto";
                        rowDetalle["respuesta"] = detalle.adjunto;
                    }

                    if (detalle.opcion1 == null)
                    {
                        rowDetalle["opcion"] = "";
                    }
                    else
                    {
                        rowDetalle["opcion"] = detalle.opcion1.descripcion;
                    }

                    dataTableDetalle.Rows.Add(rowDetalle);
                }
            }

            return armarReporte(ds, "DiacCursosRpt.rpt");
        }

        public ActionResult diacAlumnosDocente(Int32 idAlumno, String fechaDesde, String fechaHasta)
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

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

            //si me viene un alumno
            var mostrar =
                from ls in mDb.llenadoseguimiento
                where ls.fecha >= dFechaDesde.Date
                    && ls.fecha <= dFechaHasta.Date
                    && ls.diac != null
                    && ls.alumno == idAlumno
                select ls;

            if (idAlumno == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ls in mDb.llenadoseguimiento
                    where ls.fecha >= dFechaDesde.Date
                        && ls.fecha <= dFechaHasta.Date
                        && ls.diac != null
                        && ls.docente == idImpresoPor
                    select ls;
            }

            diacAlumnosDs ds = new Peals.Reportes.diacAlumnosDs();
            

            foreach (llenadoseguimiento llenadoseguimiento in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = llenadoseguimiento.id;
                row["fecha"] = llenadoseguimiento.fecha;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                row["curso"] = llenadoseguimiento.curso1.descripcion;

                if (idAlumno != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["alumnoFiltro"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["alumnoFiltro"] = "Todos";
                }

                row["institucion"] = llenadoseguimiento.diac1.institucion1.nombre;
                row["fechaDesde"] = fechaDesde;
                row["fechaHasta"] = fechaHasta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);

                foreach (llenadoseguimientodetalle detalle in llenadoseguimiento.llenadoseguimientodetalle.ToList())
                {
                    DataTable dataTableDetalle = ds.Tables[1];
                    DataRow rowDetalle = dataTableDetalle.NewRow();
                    rowDetalle["llenadoSeguimiento"] = detalle.llenadoseguimiento1.id;
                    rowDetalle["grupo"] = detalle.item1.grupo;
                    rowDetalle["descripcion"] = detalle.item1.descripcion;


                    if (detalle.item1.tipoItem == (int)TipoDiac.unaLinea)
                    {
                        rowDetalle["tipoItem"] = "Una Línea";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.multiplesLineas)
                    {
                        rowDetalle["tipoItem"] = "Multiples Líneas";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conOpciones)
                    {
                        rowDetalle["tipoItem"] = "Con Opciones";
                        rowDetalle["respuesta"] = detalle.opcion1.descripcion;;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conAdjunto)
                    {
                        rowDetalle["tipoItem"] = "Con Adjunto";
                        rowDetalle["respuesta"] = detalle.adjunto;
                    }


                    if (detalle.opcion1 == null)
                    {
                        rowDetalle["opcion"] = "";
                    }
                    else
                    {
                        rowDetalle["opcion"] = detalle.opcion1.descripcion;
                    }

                    dataTableDetalle.Rows.Add(rowDetalle);
                }
            }

            return armarReporte(ds, "DiacAlumnosRpt.rpt");
        }

        public ActionResult diacPlantillaDocente(Int32 idCurso)
        {
            curso crs = mDb.curso.Single(curs => curs.id == idCurso);

            var mostrar =
                from i in mDb.item
                where i.diac1.activo == 1
                    && i.diac1.institucion == crs.institucion
                orderby i.ordenGrupo
                select i;

            PlantillaDs ds = new Peals.Reportes.PlantillaDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            String grupoAnterior = "";
            foreach (item item in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();


                if (grupoAnterior != item.grupo)
                {
                    grupoAnterior = item.grupo;
                    row["grupo"] = item.grupo;
                    row["impresoPor"] = impresoPor.mail;
                    row["institucion"] = crs.institucion1.nombre;
                    dataTable.Rows.Add(row);
                }

                DataTable dataTableDetalle = ds.Tables[1];
                DataRow rowDetalle = dataTableDetalle.NewRow();
                rowDetalle["grupo"] = item.grupo;

                rowDetalle["descripcion"] = item.descripcion;

                if (item.tipoItem == (int)TipoDiac.unaLinea)
                {
                    rowDetalle["tipoItem"] = "Una Línea";
                }
                else if (item.tipoItem == (int)TipoDiac.multiplesLineas)
                {
                    rowDetalle["tipoItem"] = "Multiples Líneas";
                }
                else if (item.tipoItem == (int)TipoDiac.conOpciones)
                {
                    rowDetalle["tipoItem"] = "Con Opciones";
                }
                else if (item.tipoItem == (int)TipoDiac.conAdjunto)
                {
                    rowDetalle["tipoItem"] = "Con Adjunto";
                }
                dataTableDetalle.Rows.Add(rowDetalle);
            }

            return armarReporte(ds, "plantillaRpt.rpt");
        }

        public ActionResult seguimientoCursosDocente(Int32 idCurso, String fechaDesde, String fechaHasta)
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

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

            //si me viene un curso, los de ese curso puntual
            var mostrar =
                from ls in mDb.llenadoseguimiento
                where ls.fecha >= dFechaDesde.Date
                    && ls.fecha <= dFechaHasta.Date
                    && ls.seguimiento != null
                    && ls.curso == idCurso
                select ls;

            if (idCurso == 0)
            {
                //de todos los cursos de la institucion
                mostrar =
                    from ls in mDb.llenadoseguimiento
                    where ls.fecha >= dFechaDesde.Date
                        && ls.fecha <= dFechaHasta.Date
                        && ls.seguimiento != null
                        && ls.curso1.docente == idImpresoPor
                    select ls;
            }

            diacAlumnosDs ds = new Peals.Reportes.diacAlumnosDs();


            foreach (llenadoseguimiento llenadoseguimiento in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = llenadoseguimiento.id;
                row["fecha"] = llenadoseguimiento.fecha;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                row["curso"] = llenadoseguimiento.curso1.descripcion;

                if (idCurso != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["alumnoFiltro"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["alumnoFiltro"] = "Todos";
                }

                row["institucion"] = mDb.institucion.Single(ins => ins.id == llenadoseguimiento.curso1.institucion1.id).nombre;
                row["fechaDesde"] = fechaDesde;
                row["fechaHasta"] = fechaHasta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);

                foreach (llenadoseguimientodetalle detalle in llenadoseguimiento.llenadoseguimientodetalle.ToList())
                {
                    DataTable dataTableDetalle = ds.Tables[1];
                    DataRow rowDetalle = dataTableDetalle.NewRow();
                    rowDetalle["llenadoSeguimiento"] = detalle.llenadoseguimiento1.id;
                    rowDetalle["grupo"] = detalle.item1.grupo;
                    rowDetalle["descripcion"] = detalle.item1.descripcion;


                    if (detalle.item1.tipoItem == (int)TipoDiac.unaLinea)
                    {
                        rowDetalle["tipoItem"] = "Una Línea";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.multiplesLineas)
                    {
                        rowDetalle["tipoItem"] = "Multiples Líneas";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conOpciones)
                    {
                        rowDetalle["tipoItem"] = "Con Opciones";
                        rowDetalle["respuesta"] = detalle.opcion1.descripcion;;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conAdjunto)
                    {
                        rowDetalle["tipoItem"] = "Con Adjunto";
                        rowDetalle["respuesta"] = detalle.adjunto;
                    }


                    if (detalle.opcion1 == null)
                    {
                        rowDetalle["opcion"] = "";
                    }
                    else
                    {
                        rowDetalle["opcion"] = detalle.opcion1.descripcion;
                    }

                    dataTableDetalle.Rows.Add(rowDetalle);
                }
            }

            return armarReporte(ds, "DiacCursosRpt.rpt");
        }

        public ActionResult seguimientoAlumnosDocente(Int32 idAlumno, String fechaDesde, String fechaHasta)
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

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

            //si me viene un alumno
            var mostrar =
                from ls in mDb.llenadoseguimiento
                where ls.fecha >= dFechaDesde.Date
                    && ls.fecha <= dFechaHasta.Date
                    && ls.seguimiento != null
                    && ls.alumno == idAlumno
                select ls;

            if (idAlumno == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ls in mDb.llenadoseguimiento
                    where ls.fecha >= dFechaDesde.Date
                        && ls.fecha <= dFechaHasta.Date
                        && ls.seguimiento != null
                        && ls.docente == idImpresoPor
                    select ls;
            }

            diacAlumnosDs ds = new Peals.Reportes.diacAlumnosDs();


            foreach (llenadoseguimiento llenadoseguimiento in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = llenadoseguimiento.id;
                row["fecha"] = llenadoseguimiento.fecha;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                row["curso"] = llenadoseguimiento.curso1.descripcion;

                if (idAlumno != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["alumnoFiltro"] = mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == llenadoseguimiento.alumno).apellido;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["alumnoFiltro"] = "Todos";
                }

                row["institucion"] = llenadoseguimiento.seguimiento1.curso1.institucion1.nombre;
                row["fechaDesde"] = fechaDesde;
                row["fechaHasta"] = fechaHasta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);

                foreach (llenadoseguimientodetalle detalle in llenadoseguimiento.llenadoseguimientodetalle.ToList())
                {
                    DataTable dataTableDetalle = ds.Tables[1];
                    DataRow rowDetalle = dataTableDetalle.NewRow();
                    rowDetalle["llenadoSeguimiento"] = detalle.llenadoseguimiento1.id;
                    rowDetalle["grupo"] = detalle.item1.grupo;
                    rowDetalle["descripcion"] = detalle.item1.descripcion;


                    if (detalle.item1.tipoItem == (int)TipoDiac.unaLinea)
                    {
                        rowDetalle["tipoItem"] = "Una Línea";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.multiplesLineas)
                    {
                        rowDetalle["tipoItem"] = "Multiples Líneas";
                        rowDetalle["respuesta"] = detalle.respuesta;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conOpciones)
                    {
                        rowDetalle["tipoItem"] = "Con Opciones";
                        rowDetalle["respuesta"] = detalle.opcion1.descripcion;
                    }
                    else if (detalle.item1.tipoItem == (int)TipoDiac.conAdjunto)
                    {
                        rowDetalle["tipoItem"] = "Con Adjunto";
                        rowDetalle["respuesta"] = detalle.adjunto;
                    }


                    
                    if (detalle.opcion1 == null)
                    {
                        rowDetalle["opcion"] = "";
                    }
                    else
                    {
                        rowDetalle["opcion"] = detalle.opcion1.descripcion;
                    }

                    dataTableDetalle.Rows.Add(rowDetalle);
                }
            }

            return armarReporte(ds, "DiacAlumnosRpt.rpt");
        }

        public ActionResult seguimientoPlantillaDocente(Int32 idCurso)
        {
            curso crs = mDb.curso.Single(curs => curs.id == idCurso);

            var mostrar =
                from i in mDb.item
                where i.seguimiento1.activo == 1
                    && i.seguimiento1.curso == idCurso
                orderby i.ordenGrupo
                select i;

            PlantillaDs ds = new Peals.Reportes.PlantillaDs();
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            String grupoAnterior = "";
            foreach (item item in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();


                if (grupoAnterior != item.grupo)
                {
                    grupoAnterior = item.grupo;
                    row["grupo"] = item.grupo;
                    row["impresoPor"] = impresoPor.mail;
                    row["institucion"] = crs.institucion1.nombre;
                    dataTable.Rows.Add(row);
                }

                DataTable dataTableDetalle = ds.Tables[1];
                DataRow rowDetalle = dataTableDetalle.NewRow();
                rowDetalle["grupo"] = item.grupo;

                rowDetalle["descripcion"] = item.descripcion;

                if (item.tipoItem == (int)TipoDiac.unaLinea)
                {
                    rowDetalle["tipoItem"] = "Una Línea";
                }
                else if (item.tipoItem == (int)TipoDiac.multiplesLineas)
                {
                    rowDetalle["tipoItem"] = "Multiples Líneas";
                }
                else if (item.tipoItem == (int)TipoDiac.conOpciones)
                {
                    rowDetalle["tipoItem"] = "Con Opciones";
                }
                else if (item.tipoItem == (int)TipoDiac.conAdjunto)
                {
                    rowDetalle["tipoItem"] = "Con Adjunto";
                }
                dataTableDetalle.Rows.Add(rowDetalle);
            }

            return armarReporte(ds, "plantillaRpt.rpt");
        }

        #endregion

        #region ALUMNO
        public ActionResult AlumnoCursos()
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            var mostrar =
                from c in mDb.curso
                from ac in mDb.alumno_x_curso
                where ac.curso == c.id
                    && ac.alumno == idImpresoPor
                    && ac.curso1.estado == (int) EstadoCurso.Alta
                    orderby c.institucion1.id, c.id
                select c;

            InstitucionCursos ds = new Peals.Reportes.InstitucionCursos();

            foreach (curso curso in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = curso.id;
                row["nombre"] = curso.nombre;
                row["ano"] = curso.ano;
                row["division"] = curso.division;
                row["nivel"] = curso.nivel1.nombre;
                row["turno"] = curso.turno1.nombre;

                if (curso.es_publico == true)
                {
                    row["es_publico"] = "Si";
                }
                else
                {
                    row["es_publico"] = "No";
                }

                row["docente"] = impresoPor.nombre + " " + impresoPor.apellido;
                
                row["institucion"] = curso.institucion1.nombre;
                row["impresoPor"] = impresoPor.mail;
                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "AlumnoCursosRpt.rpt");
        }

        public ActionResult AlumnoInstituciones()
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            var mostrar =
                from i in mDb.institucion
                from ai in mDb.alumno_x_institucion
                where ai.institucion == i.id
                    && ai.alumno == idImpresoPor
                orderby i.id
                select i;

            AlumnoInstitucionDs ds = new Peals.Reportes.AlumnoInstitucionDs();

            foreach (institucion institucion in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = institucion.id;
                row["nombre"] = institucion.nombre;
                row["administrador"] = mDb.usuario.Single(usr => usr.id == institucion.administrador).nombre + " " + mDb.usuario.Single(usr => usr.id == institucion.administrador).apellido;
                row["fecha_alta"] = institucion.fecha_alta;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "AlumnoInstitucionRpt.rpt");
        }

        public ActionResult AlumnoActividades()
        {
            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);

            var mostrar =
                from a in mDb.actividad
                from ac in mDb.alumno_x_curso
                from acc in mDb.actividad_x_curso
                where ac.curso1.estado == (int) EstadoCurso.Alta
                    && acc.actividad == a.id
                    && acc.curso == ac.curso
                    && ac.alumno == idImpresoPor
                    && (acc.actividad1.estado == (int) EstadoActividad.ConHistorial
                    || acc.actividad1.estado == (int) EstadoActividad.Alta)
                orderby a.id
                select a;

            Actividades ds = new Peals.Reportes.Actividades();

            foreach (actividad actividad in mostrar.Distinct().ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = actividad.id;
                row["nombre"] = actividad.nombre;
                usuario docente = mDb.usuario.Single(usr => usr.id == actividad.docente);
                row["docente"] = docente.nombre + " " + docente.apellido;
                row["descripcion"] = actividad.descripcion;
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "ActividadesRpt.rpt");
        }

        public ActionResult resolucionActividadesAlumno(Int32 idActividad, String fechaDesde, String fechaHasta)
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

            dFechaHasta = dFechaHasta.AddHours(23);
            dFechaHasta = dFechaHasta.AddMinutes(59);

            Int32 idImpresoPor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            usuario impresoPor = mDb.usuario.Single(usr => usr.id == idImpresoPor);
            //si me viene una actividad
            var mostrar =
                from ha in mDb.historial_actividad
                where ha.actividad == idActividad
                && ha.alumno == idImpresoPor &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                select ha;

            if (idActividad == 0)
            {
                //todas las actividades de la institucion
                mostrar =
                    from ha in mDb.historial_actividad
                    where ha.alumno == idImpresoPor &&
                    ha.fecha_realizacion >= dFechaDesde.Date
                    && ha.fecha_realizacion <= dFechaHasta
                    select ha;
            }

            historialActividadesDs ds = new Peals.Reportes.historialActividadesDs();

            foreach (historial_actividad historial in mostrar.ToList())
            {
                DataTable dataTable = ds.Tables[0];
                DataRow row = dataTable.NewRow();
                row["id"] = historial.id;
                row["alumno"] = mDb.usuario.Single(alu => alu.id == historial.alumno).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.alumno).apellido;
                row["docente"] = mDb.usuario.Single(alu => alu.id == historial.docente).nombre + " " + mDb.usuario.Single(alu => alu.id == historial.docente).apellido;
                row["curso"] = mDb.curso.Single(cur => cur.id == historial.curso).nombre;
                row["institucion"] = mDb.institucion.Single(ins => ins.id == historial.institucion).nombre;
                row["actividad"] = historial.actividad1.nombre;
                row["calificacion_docente"] = historial.calificacion_docente;
                row["calificacion_sistema"] = historial.calificacion_sistema;
                row["fecha_realizacion"] = historial.fecha_realizacion;
                row["intentos"] = historial.intentos;
                row["uso_ayuda_consigna"] = historial.uso_ayuda_consigna;
                row["uso_ayuda_actividad"] = historial.uso_ayuda_actividad;
                row["tiempo"] = historial.tiempo;

                row["fechaDesde"] = fechaDesde == "" ? "Sin filtro" : fechaDesde;
                row["fechaHasta"] = fechaDesde == "" ? "Sin filtro" : fechaHasta;

                row["campoFiltro"] = "Actividad: ";
                row["impresoPor"] = impresoPor.nombre + " " + impresoPor.apellido;

                if (idActividad != 0)
                {
                    //es un curso puntual, asiq lo busco y lo pongo
                    row["filtro"] = mDb.actividad.Single(act => act.id == idActividad).nombre;
                }
                else
                {
                    //tengo q ver todos los cursos que tiene el alumno en esta institucion
                    row["filtro"] = "Todos";
                }

                dataTable.Rows.Add(row);
            }

            return armarReporte(ds, "historialActividadesRpt.rpt");
        }
        #endregion

    }

}
