using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Peals.Models;
using System.Data;
using System.Net.Mail;
using System.Globalization;

namespace Peals.Controllers
{
    public class MensajeController : Controller
    {
        private pealsEntities mDb = new pealsEntities();
        //
        // GET: /Mensaje/

        #region SET GET

        public void setModelo(pealsEntities modelo)
        {
            mDb = modelo;
        }

        public pealsEntities getModelo()
        {
            return mDb;
        }


        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mensajes()
        {
            return View();
        }

        public ActionResult MensajesConFiltro(String fechaDesde, String fechaHasta)
        {
            ViewBag.fechaDesde = fechaDesde;
            ViewBag.fechaHasta = fechaHasta;
            return View("Mensajes");
        }

        [HttpPost]
        public ActionResult NuevoMensaje(String personas, String cursos, mensaje msj)//, String titulo_mensaje, String mensaje1)
        {
            // Detetecto los saltos de línea para mantener el formato del texto ingresado.
            msj.mensaje1 = (msj.mensaje1 != null) ? msj.mensaje1.Replace("\n", "<br />") : "";

            msj.emisor_mensaje = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            msj.tipo_mensaje = mDb.tipo_mensaje.First(x => x.nombre == "Mensaje").id;
            //msj.titulo_mensaje = titulo_mensaje;
            if (msj.titulo_mensaje.Length > 149)
            {
                msj.titulo_mensaje = msj.titulo_mensaje.Substring(0, 149);
            }

            mDb.mensaje.AddObject(msj);
            msj.fecha_mensaje = DateTime.Now;
            msj.estado_mensaje = mDb.estado_mensaje.First(x => x.nombre == "Pendiente").id;

            //agrego los destinatarios.
            foreach (String persona in personas.Split(','))
            {
                agregarDestinatarioPersona(persona, msj.id);
            }

            foreach (String curso in cursos.Split(','))
            {
                agregarDestinatarioCurso(curso, msj.id);
            }

            if (mDb.SaveChanges() == 0)
            {
                return View("Error");
            }
            else
            {
                mensaje_x_destinatario[] msjDest = mDb.mensaje_x_destinatario.Where(x => x.mensaje == msj.id).ToArray();
                foreach (mensaje_x_destinatario dst in msjDest)
                {
                    enviarEmail((int)msj.emisor_mensaje, dst.usuario.mail, msj.titulo_mensaje, msj.mensaje1);
                }

                return RedirectToAction("informeEnvioMensaje", "Mensaje", new { enviados = ViewBag.usuariosEnviados, noEnviados = ViewBag.usuariosNoEnviados });
            }
        }

        public void agregarDestinatarioPersona(String persona, Int32 idMensaje)
        {
            mensaje_x_destinatario msj_dest = new mensaje_x_destinatario();
            usuario usr = new usuario();
            try
            {
                usr = mDb.usuario.First(x => x.mail == persona.Trim());
                ViewBag.usuariosEnviados += persona + ",";
            }
            catch (System.InvalidOperationException e)
            {
                ViewBag.usuariosNoEnviados += persona + ",";
            }

            msj_dest.usuario = usr;
            msj_dest.mensaje = idMensaje;
            mDb.mensaje_x_destinatario.AddObject(msj_dest);
        }

        public void agregarDestinatarioCurso(String curso, Int32 idMensaje)
        {
            mensaje_x_destinatario msj_dest = new mensaje_x_destinatario();

            var cursos =
                from c in mDb.curso
                join u in mDb.usuario on c.usuario.id equals u.id
                where c.nombre == curso
                select c;

            foreach (curso curs in cursos.ToList())
            {
                agregarDestinatarioPersona(curs.usuario.mail, idMensaje); //mando al docente y  a los alumnos
                var alumnosCurso =
                    from ac in mDb.alumno_x_curso
                    where ac.curso == curs.id
                    select ac;
                foreach (alumno_x_curso usr in alumnosCurso.ToList())
                {
                    usuario al = mDb.usuario.First(x => x.id == usr.alumno);
                    agregarDestinatarioPersona(al.mail, idMensaje);
                }
            }
        }

        public ActionResult informeEnvioMensaje(String enviados, String noEnviados)
        {
            ViewBag.usuariosEnviados = enviados;
            ViewBag.usuariosNoEnviados = noEnviados;
            return View();
        }

        public ActionResult verMensaje(int idMensaje)
        {

            Int32 id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            mensaje msj = new mensaje();
            msj = mDb.mensaje.First(x => x.id == idMensaje);

            var mensDest =
                from md in mDb.mensaje_x_destinatario
                where md.destinatario == id_usuario_logeado && md.mensaje == idMensaje
                select md;

            if (msj.tipo_mensaje == 2 && msj.tipo_solicitud == 4 && msj.emisor_mensaje == id_usuario_logeado)
                ViewBag.habilitarResponder = false;
            else
                ViewBag.habilitarResponder = true;

            if ((msj.estado_mensaje1.nombre == "Pendiente" || msj.estado_mensaje1.nombre == "Notificado") && mensDest.ToList().Count != 0)
            {
                msj.estado_mensaje = 2; //LEIDO
                mDb.ObjectStateManager.ChangeObjectState(msj, EntityState.Modified);
                if (mDb.SaveChanges() == 0)
                {
                    return View("Error");
                }
            }

            ViewBag.emisor = mDb.usuario.First(x => x.id == msj.emisor_mensaje).mail;

            var destinatarios =
             from dest in mDb.mensaje_x_destinatario
             where dest.mensaje1.id == msj.id
             select dest;

            foreach (mensaje_x_destinatario destinatario in destinatarios.ToList())
            {
                ViewBag.destinatarios += mDb.usuario.First(x => x.id == destinatario.destinatario).mail + ",";
            }

            return View(msj);
        }

        public ActionResult eliminarMensaje(int idMensaje)
        {
            if (System.Web.HttpContext.Current.Request.HttpMethod.ToString() == "GET")
            {
                Int32 id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

                mensaje msj = new mensaje();
                msj = mDb.mensaje.First(x => x.id == idMensaje);

                var mensDest =
                    from md in mDb.mensaje_x_destinatario
                    where md.destinatario == id_usuario_logeado && md.mensaje == idMensaje
                    select md;

                if (msj.estado_mensaje1.nombre == "Pendiente" && mensDest.ToList().Count != 0)
                {
                    msj.estado_mensaje = 2; //LEIDO
                    mDb.ObjectStateManager.ChangeObjectState(msj, EntityState.Modified);
                    if (mDb.SaveChanges() == 0)
                    {
                        return View("Error");
                    }
                }

                ViewBag.emisor = mDb.usuario.First(x => x.id == msj.emisor_mensaje).mail;

                var destinatarios =
                 from dest in mDb.mensaje_x_destinatario
                 where dest.mensaje1.id == msj.id
                 select dest;

                foreach (mensaje_x_destinatario destinatario in destinatarios.ToList())
                {
                    ViewBag.destinatarios += mDb.usuario.First(x => x.id == destinatario.destinatario).mail + ",";
                }

                return View(msj);
            }
            else
            {
                var destinatarios =
                     from md in mDb.mensaje_x_destinatario
                     where md.mensaje1.id == idMensaje
                     select md;

                foreach (mensaje_x_destinatario des in destinatarios.ToList())
                {
                    mDb.DeleteObject(des);
                }

                mensaje m = mDb.mensaje.First(x => x.id == idMensaje);
                mDb.DeleteObject(m);
                if (mDb.SaveChanges() > 0)
                {
                    return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    return View("Error");
                }

            }

        }

        #region PARTIAL_VIEWS


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoMensaje"></param>
        /// <returns></returns>
        public ActionResult VerSolicitud(int idMensaje)
        {
            String subtitulo = "Estás respondiendo una solicitud";
            ViewBag.idMensaje = idMensaje;
            mensaje msj = mDb.mensaje.First(x => x.id == idMensaje);
            ViewBag.subtitulo = subtitulo;
            return View("_VerSolicitud", msj);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoMensaje"></param>
        /// <returns></returns>
        public ActionResult _VerSolicitud(int idMensaje)
        {
            String subtitulo = "Estás respondiendo una solicitud";
            ViewBag.idMensaje = idMensaje;
            mensaje msj = mDb.mensaje.First(x => x.id == idMensaje);
            //marcamos el mensaje como leido
            if (msj.estado_mensaje == 1 || msj.estado_mensaje == 6)
            {
                msj.estado_mensaje = 2;
            }

            mDb.SaveChanges();
            ViewBag.subtitulo = subtitulo;
            return PartialView("_VerSolicitud", msj);
        }

        [HttpPost]
        public ActionResult _VerSolicitud(String decision, String mensajeRespuesta, Int32 idMensaje)
        {
            try
            {

                mensaje msj = mDb.mensaje.First(x => x.id == idMensaje);
                usuario usuario = mDb.usuario.First(x => x.id == msj.emisor_mensaje);
                mensaje mensaje = new mensaje();
                Int32 estadoMensaje;
                String titMensaje;
                String prefijo;

                if (decision == "aceptar")
                {
                    estadoMensaje = mDb.estado_mensaje.First(x => x.nombre == "Aceptado").id;
                    //ESTO ES LO QUE HAY QUE MODIFICAR DE ACUERDO AL TIPO DE SOLICITUD
                    if (msj.tipo_solicitud == (int)TipoSolicitud.inscripcionCurso)
                    {
                        asignarAlumnoACurso(usuario, msj.referencia);
                    }
                    else if (msj.tipo_solicitud == (int)TipoSolicitud.inscripcionInstitucion)
                    {
                        asignarDocenteAInstitucion(usuario, msj.referencia);
                    }
                    else if (msj.tipo_solicitud == (int)TipoSolicitud.inscripcionDocente)
                    {
                        Int32 idUsuarioAAsignar = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                        usuario usuarioAAsignar = mDb.usuario.First(x => x.id == idUsuarioAAsignar);
                        asignarDocenteAInstitucion(usuarioAAsignar, msj.referencia);
                    }
                    else if (msj.tipo_solicitud == (int)TipoSolicitud.asignarDocenteACurso)
                    {
                        Int32 idUsuarioAAsignar = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                        usuario usuarioAAsignar = mDb.usuario.First(x => x.id == idUsuarioAAsignar);
                        asignarDocenteACurso(usuarioAAsignar, msj.referencia); //referencia seria el curso al que vamos a asignar a ese docente.
                    }
                    else if (msj.tipo_solicitud == (int)TipoSolicitud.asignarAlumnoACurso)
                    {
                        Int32 idUsuarioAAsignar = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
                        usuario usuarioAAsignar = mDb.usuario.First(x => x.id == idUsuarioAAsignar);
                        asignarAlumnoACurso(usuarioAAsignar, msj.referencia); //referencia seria el curso al que vamos a asignar a ese alumno.
                    }

                    prefijo = "[ACEPTADO]";
                    titMensaje = "Respuesta a " + msj.titulo_mensaje;
                }
                else
                {
                    estadoMensaje = mDb.estado_mensaje.First(x => x.nombre == "Rechazado").id;
                    prefijo = "[RECHAZADO]";
                    titMensaje = "Respuesta a " + msj.titulo_mensaje;
                }

                msj.estado_mensaje = estadoMensaje;

                Int32 emisorMensaje = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

                enviarNotificacion(emisorMensaje, usuario.id, prefijo, (int)msj.referencia, mensajeRespuesta, titMensaje);

                if (mDb.SaveChanges() > 0)
                {
                    return RedirectToAction("informeEnvioMensaje", new { enviados = usuario.mail, noEnviados = "" });

                }

                else
                {
                    return View("Error");
                }
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public void enviarNotificacion(Int32 idEmisor, Int32 idDestinatario, String prefijo, Int32 idReferencia, String mensajeTexto, String tituloMensaje)
        {
            mensaje mensaje = new mensaje();
            usuario usuario = mDb.usuario.First(x => x.id == idEmisor);

            mensaje.referencia = idReferencia;
            mensaje.emisor_mensaje = usuario.id;
            mensaje.tipo_mensaje = mDb.tipo_mensaje.First(x => x.nombre == "Notificacion").id;
            mensaje.mensaje1 = mensajeTexto;

            mensaje.titulo_mensaje = prefijo + " " + tituloMensaje;

            if (mensaje.titulo_mensaje.Length > 149)
            {
                mensaje.titulo_mensaje = mensaje.titulo_mensaje.Substring(0, 149);
            }

            mDb.mensaje.AddObject(mensaje);
            mensaje.fecha_mensaje = DateTime.Now;
            mensaje.estado_mensaje = mDb.estado_mensaje.First(x => x.nombre == "Pendiente").id;

            usuario = mDb.usuario.First(x => x.id == idDestinatario);

            mensaje_x_destinatario msj_dest = new mensaje_x_destinatario();
            msj_dest.usuario = usuario;
            msj_dest.mensaje = mensaje.id;
            mDb.mensaje_x_destinatario.AddObject(msj_dest);

            enviarEmail(idEmisor, usuario.mail, mensaje.titulo_mensaje, mensaje.mensaje1);
        }

        public void asignarAlumnoACurso(usuario alumno, Int32? curso)
        {
            curso c = mDb.curso.First(x => x.id == curso);

            alumno_x_curso alXCurso = new alumno_x_curso();
            alXCurso.alumno = alumno.id;
            alXCurso.curso = curso;
            alXCurso.fecha_asignacion = DateTime.Now;

            alumno_x_institucion alXInst = new alumno_x_institucion();

            try
            {
                alXInst = mDb.alumno_x_institucion.First(x => x.alumno == alumno.id && x.institucion == c.institucion1.id);
            }
            catch (InvalidOperationException e)
            {
                alXInst.institucion = c.institucion1.id;
                alXInst.alumno = alumno.id;
                alXInst.fecha_alta = DateTime.Now;

                mDb.alumno_x_institucion.AddObject(alXInst);
            }

            mDb.alumno_x_curso.AddObject(alXCurso);
        }

        public void asignarDocenteAInstitucion(usuario docente, Int32? institucion)
        {
            docente_x_institucion doXInstitucion = new docente_x_institucion();
            doXInstitucion.docente = docente.id;
            doXInstitucion.institucion = institucion;
            doXInstitucion.fecha_alta = DateTime.Now;
            mDb.docente_x_institucion.AddObject(doXInstitucion);
        }

        public void asignarDocenteACurso(usuario docente, Int32? curso)
        {
            curso oCurso = mDb.curso.First(x => x.id == curso);
            oCurso.docente = docente.id;
        }

        public ActionResult _MostrarTodos(String tipo, String fechaDesde = null, String fechaHasta = null)
        {
            int id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            DateTime fechaDesdeConsulta;
            DateTime fechaHastaConsulta;

            if (fechaDesde == "" || fechaDesde == null)
                fechaDesdeConsulta = DateTime.ParseExact("01/01/1950", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaDesdeConsulta = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (fechaHasta == "" || fechaHasta == null)
                fechaHastaConsulta = DateTime.ParseExact("01/01/2200", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaHastaConsulta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            fechaHastaConsulta = fechaHastaConsulta.AddHours(23);
            fechaHastaConsulta = fechaHastaConsulta.AddMinutes(59);
            
            var mensajes =
                from mens in mDb.mensaje
                join t_mens in mDb.tipo_mensaje on mens.tipo_mensaje equals t_mens.id
                join e_mens in mDb.estado_mensaje on mens.estado_mensaje equals e_mens.id
                join destinatarios in mDb.mensaje_x_destinatario on mens.id equals destinatarios.mensaje
                let emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.nombre + " " + usu.apellido)
                let id_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select (int?)usu.id)
                let tipo_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.tipo_usuario1.nombre)
                let emisor_mail = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.mail)
                let destinatario = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.nombre + " " + usu.apellido)
                let destinatario_mail = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.mail)
                where mens.fecha_mensaje >= fechaDesdeConsulta.Date && mens.fecha_mensaje <= fechaHastaConsulta && t_mens.nombre.Contains(tipo) &&
                      (
                        destinatarios.destinatario == id_usuario_logeado || //recibido
                        mens.emisor_mensaje == id_usuario_logeado //enviado
                      )
                orderby mens.id descending
                select new
                {
                    Titulo = mens.titulo_mensaje,
                    Fecha = mens.fecha_mensaje,
                    Mensaje = mens.mensaje1,
                    Emisor = emisor.FirstOrDefault(),
                    Emisor_Mail = emisor_mail.FirstOrDefault(),
                    Destinatario = destinatario.FirstOrDefault(),
                    Destinatario_Mail = destinatario_mail.FirstOrDefault(),
                    Referencia = mens.referencia,
                    Estado = e_mens.nombre,
                    Tipo = t_mens.nombre,
                    TipoEmisor = tipo_emisor.FirstOrDefault(),
                    Id = mens.id,
                    Direccion = (int?)id_emisor.FirstOrDefault() == id_usuario_logeado ? "Enviado" : "Recibido"
                };
            ViewBag.tipo = tipo;
            return PartialView(mensajes.ToList());
        }

        public ActionResult _Recibidos(String tipo, String fechaDesde = null, String fechaHasta = null)
        {
            int id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            DateTime fechaDesdeConsulta;
            DateTime fechaHastaConsulta;

            if (fechaDesde == "" || fechaDesde == null)
                fechaDesdeConsulta = DateTime.ParseExact("01/01/1950", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaDesdeConsulta = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (fechaHasta == "" || fechaHasta == null)
                fechaHastaConsulta = DateTime.ParseExact("01/01/2200", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaHastaConsulta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            fechaHastaConsulta = fechaHastaConsulta.AddHours(23);
            fechaHastaConsulta = fechaHastaConsulta.AddMinutes(59);

            var mensajes =
                from mens in mDb.mensaje
                join t_mens in mDb.tipo_mensaje on mens.tipo_mensaje equals t_mens.id
                join e_mens in mDb.estado_mensaje on mens.estado_mensaje equals e_mens.id
                join destinatarios in mDb.mensaje_x_destinatario on mens.id equals destinatarios.mensaje
                let emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.nombre + " " + usu.apellido)
                let id_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select (int?)usu.id)
                let tipo_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.tipo_usuario1.nombre)
                let emisor_mail = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.mail)
                let destinatario = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.nombre + " " + usu.apellido)
                let destinatario_mail = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.mail)
                where mens.fecha_mensaje >= fechaDesdeConsulta.Date && mens.fecha_mensaje <= fechaHastaConsulta && t_mens.nombre.Contains(tipo) &&
                      (
                        destinatarios.destinatario == id_usuario_logeado//recibido
                      )
                orderby mens.id descending
                select new
                {
                    Titulo = mens.titulo_mensaje,
                    Fecha = mens.fecha_mensaje,
                    Mensaje = mens.mensaje1,
                    Emisor = emisor.FirstOrDefault(),
                    Emisor_Mail = emisor_mail.FirstOrDefault(),
                    Destinatario = destinatario.FirstOrDefault(),
                    Destinatario_Mail = destinatario_mail.FirstOrDefault(),
                    Referencia = mens.referencia,
                    Estado = e_mens.nombre,
                    Tipo = t_mens.nombre,
                    TipoEmisor = tipo_emisor.FirstOrDefault(),
                    Id = mens.id,
                    Direccion = (int?)id_emisor.FirstOrDefault() == id_usuario_logeado ? "Enviado" : "Recibido"
                };
            ViewBag.tipo = tipo;
            return PartialView(mensajes.ToList());
        }

        public ActionResult _Enviados(String tipo, String fechaDesde = null, String fechaHasta = null)
        {
            int id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            DateTime fechaDesdeConsulta;
            DateTime fechaHastaConsulta;

            if (fechaDesde == "" || fechaDesde == null)
                fechaDesdeConsulta = DateTime.ParseExact("01/01/1950", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaDesdeConsulta = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (fechaHasta == "" || fechaHasta == null)
                fechaHastaConsulta = DateTime.ParseExact("01/01/2200", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaHastaConsulta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            fechaHastaConsulta = fechaHastaConsulta.AddHours(23);
            fechaHastaConsulta = fechaHastaConsulta.AddMinutes(59);

            var mensajes =
                from mens in mDb.mensaje
                join t_mens in mDb.tipo_mensaje on mens.tipo_mensaje equals t_mens.id
                join e_mens in mDb.estado_mensaje on mens.estado_mensaje equals e_mens.id
                join destinatarios in mDb.mensaje_x_destinatario on mens.id equals destinatarios.mensaje
                let emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.nombre + " " + usu.apellido)
                let id_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select (int?)usu.id)
                let tipo_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.tipo_usuario1.nombre)
                let emisor_mail = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.mail)
                let destinatario = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.nombre + " " + usu.apellido)
                let destinatario_mail = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.mail)
                where mens.fecha_mensaje >= fechaDesdeConsulta.Date && mens.fecha_mensaje <= fechaHastaConsulta && t_mens.nombre.Contains(tipo) &&
                      (
                        mens.emisor_mensaje == id_usuario_logeado //enviado
                      )
                orderby mens.id descending
                select new
                {
                    Titulo = mens.titulo_mensaje,
                    Fecha = mens.fecha_mensaje,
                    Mensaje = mens.mensaje1,
                    Emisor = emisor.FirstOrDefault(),
                    Emisor_Mail = emisor_mail.FirstOrDefault(),
                    Destinatario = destinatario.FirstOrDefault(),
                    Destinatario_Mail = destinatario_mail.FirstOrDefault(),
                    Referencia = mens.referencia,
                    Estado = e_mens.nombre,
                    Tipo = t_mens.nombre,
                    TipoEmisor = tipo_emisor.FirstOrDefault(),
                    Id = mens.id,
                    Direccion = (int?)id_emisor.FirstOrDefault() == id_usuario_logeado ? "Enviado" : "Recibido"
                };
            ViewBag.tipo = tipo;
            return PartialView(mensajes.ToList());
        }

        public ActionResult _NoLeidos(String tipo, String fechaDesde = null, String fechaHasta = null)
        {
            int id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);

            DateTime fechaDesdeConsulta;
            DateTime fechaHastaConsulta;

            if (fechaDesde == "" || fechaDesde == null)
                fechaDesdeConsulta = DateTime.ParseExact("01/01/1950", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaDesdeConsulta = DateTime.ParseExact(fechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            if (fechaHasta == "" || fechaHasta == null)
                fechaHastaConsulta = DateTime.ParseExact("01/01/2200", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            else
                fechaHastaConsulta = DateTime.ParseExact(fechaHasta, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            fechaHastaConsulta = fechaHastaConsulta.AddHours(23);
            fechaHastaConsulta = fechaHastaConsulta.AddMinutes(59);

            var mensajes =
                from mens in mDb.mensaje
                join t_mens in mDb.tipo_mensaje on mens.tipo_mensaje equals t_mens.id
                join e_mens in mDb.estado_mensaje on mens.estado_mensaje equals e_mens.id
                join destinatarios in mDb.mensaje_x_destinatario on mens.id equals destinatarios.mensaje
                let emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.nombre + " " + usu.apellido)
                let id_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select (int?)usu.id)
                let tipo_emisor = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.tipo_usuario1.nombre)
                let emisor_mail = (from usu in mDb.usuario where usu.id == mens.emisor_mensaje select usu.mail)
                let destinatario = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.nombre + " " + usu.apellido)
                let destinatario_mail = (from usu in mDb.usuario where usu.id == destinatarios.destinatario select usu.mail)
                where mens.fecha_mensaje >= fechaDesdeConsulta.Date && mens.fecha_mensaje <= fechaHastaConsulta && t_mens.nombre.Contains(tipo) &&
                      (
                        destinatarios.destinatario == id_usuario_logeado//recibido
                      ) && (mens.estado_mensaje == 1 || mens.estado_mensaje == 6) //pendiente o notificado 
                orderby mens.id descending
                select new
                {
                    Titulo = mens.titulo_mensaje,
                    Fecha = mens.fecha_mensaje,
                    Mensaje = mens.mensaje1,
                    Emisor = emisor.FirstOrDefault(),
                    Emisor_Mail = emisor_mail.FirstOrDefault(),
                    Destinatario = destinatario.FirstOrDefault(),
                    Destinatario_Mail = destinatario_mail.FirstOrDefault(),
                    Referencia = mens.referencia,
                    Estado = e_mens.nombre,
                    Tipo = t_mens.nombre,
                    TipoEmisor = tipo_emisor.FirstOrDefault(),
                    Id = mens.id,
                    Direccion = (int?)id_emisor.FirstOrDefault() == id_usuario_logeado ? "Enviado" : "Recibido"
                };
            ViewBag.tipo = tipo;
            return PartialView(mensajes.ToList());
        }

        /// <summary>
        /// Crea una nueva solicitud. NO HACE EL mdB.Sabe!!! Hay que hacerlo desde el action que llame a este metodo.
        /// </summary>
        /// <param name="emisor">Emisor del mensaje</param>
        /// <param name="mensaje">Contenido del mensaje. Ej: "Hola, envio esta solicitud porque quiero formar parte de este curso"</param>
        /// <param name="referencia">Entidad a la que hacemos referencia. Ej: Curso</param>
        /// <param name="titulo">titulo del mensaje, incluyendo un prefijo si se desea</param>
        /// <param name="destinatario">A quien se le envia la solicitud (una solicitud se envia a una sola persona)</param>
        /// <returns></returns>
        public Boolean NuevaSolicitud(Int32 emisor, String mensaje, Int32 referencia, String titulo, Int32 destinatario, Int32 tipoSolicitud)
        {
            try
            {
                mensaje msj = new mensaje();
                msj.mensaje1 = mensaje;
                msj.emisor_mensaje = emisor;
                msj.referencia = referencia;
                msj.tipo_mensaje = mDb.tipo_mensaje.First(x => x.nombre == "Solicitud").id;
                msj.titulo_mensaje = titulo;
                if (msj.titulo_mensaje.Length > 149)
                {
                    msj.titulo_mensaje = msj.titulo_mensaje.Substring(0, 149);
                }
                mDb.mensaje.AddObject(msj);
                msj.fecha_mensaje = DateTime.Now;
                msj.estado_mensaje = mDb.estado_mensaje.First(x => x.nombre == "Pendiente").id;
                msj.tipo_solicitud = tipoSolicitud;

                mensaje_x_destinatario msj_dest = new mensaje_x_destinatario();
                msj_dest.usuario = mDb.usuario.First(x => x.id == destinatario);
                msj_dest.mensaje = msj.id;
                mDb.mensaje_x_destinatario.AddObject(msj_dest);

                enviarEmail(emisor, msj_dest.usuario.mail, msj.titulo_mensaje, mensaje);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ActionResult _NuevaSolicitud(int referencia, String subtitulo = "Estas enviando una nueva solicitud", int? referencia2 = 0)
        {
            ViewBag.referencia2 = referencia2;
            ViewBag.subtitulo = subtitulo;
            ViewBag.referencia = referencia;
            return PartialView("_NuevaSolicitud");
        }

        public ActionResult _NuevaSolicitudACurso(int idCurso)
        {
            curso curso = mDb.curso.First(x => x.id == idCurso);
            String subtitulo = "Estás enviando una solicitud de inscripción al curso " + curso.nombre + " de la institucion " + curso.institucion1.nombre;
            return _NuevaSolicitud(idCurso, subtitulo);
        }

        public ActionResult _NuevaSolicitudAInstitucion(int idInstitucion)
        {
            institucion institucion = mDb.institucion.First(x => x.id == idInstitucion);
            String subtitulo = "Estás enviando una solicitud de inscripción a la institucion " + institucion.nombre;
            return _NuevaSolicitud(idInstitucion, subtitulo);
        }

        public ActionResult _NuevaSolicitudADocente(String mail, int idInstitucion)
        {
            try
            {
                institucion institucion = mDb.institucion.First(x => x.id == idInstitucion);
                usuario docente = mDb.usuario.First(x => x.mail == mail);
                String subtitulo = "Estás enviando una solicitud al docente " + docente.mail + " para la institución " + institucion.nombre;
                return _NuevaSolicitud(idInstitucion, subtitulo, docente.id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ActionResult _NuevaSolicitudAAlumno(String mail, int idCurso)
        {
            curso curso = mDb.curso.First(x => x.id == idCurso);
            usuario alumno = mDb.usuario.First(x => x.mail == mail);
            String subtitulo = "Estás enviando una solicitud al alumno " + alumno.mail + " para que se una al curso " + curso.nombre;
            return _NuevaSolicitud(idCurso, subtitulo, alumno.id);
        }


        [HttpPost]
        public ActionResult _NuevaSolicitudACurso(mensaje msj, int referencia)
        {
            curso curso = mDb.curso.First(x => x.id == referencia);
            Int32 emisor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            String tituloMensaje = "Solicitud de inscripción al curso " + curso.nombre;
            Int32 destinatario;
            if (curso.usuario != null)
            {
                destinatario = curso.usuario.id;
            }
            else
            {
                return RedirectToAction("informeEnvioMensaje", new { enviados = "", noEnviados = "El curso no tiene docente asignado" });
            }
            NuevaSolicitud(emisor, msj.mensaje1, referencia, tituloMensaje, destinatario, (Int32)TipoSolicitud.inscripcionCurso);
            if (mDb.SaveChanges() > 0)
            {
                return RedirectToAction("informeEnvioMensaje", new { enviados = curso.usuario.mail, noEnviados = "" });
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult _NuevaSolicitudAInstitucion(mensaje msj, int referencia)
        {
            institucion institucion = mDb.institucion.First(x => x.id == referencia);
            Int32 emisor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            String tituloMensaje = "Solicitud de inscripción a la institución " + institucion.nombre;
            Int32 destinatario = institucion.usuario.id;
            NuevaSolicitud(emisor, msj.mensaje1, referencia, tituloMensaje, destinatario, (Int32)TipoSolicitud.inscripcionInstitucion);
            if (mDb.SaveChanges() > 0)
            {
                return RedirectToAction("informeEnvioMensaje", new { enviados = institucion.usuario.mail, noEnviados = "" });
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult _NuevaSolicitudADocente(mensaje msj, int referencia, int referencia2)
        {
            institucion institucion = mDb.institucion.First(x => x.id == referencia);
            Int32 emisor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            String tituloMensaje = "Solicitud a docente para formar parte de la institución " + institucion.nombre;
            usuario destinatario = mDb.usuario.First(x => x.id == referencia2);
            NuevaSolicitud(emisor, msj.mensaje1, referencia, tituloMensaje, destinatario.id, (Int32)TipoSolicitud.inscripcionDocente);
            if (mDb.SaveChanges() > 0)
            {
                return RedirectToAction("informeEnvioMensaje", new { enviados = destinatario.mail, noEnviados = "" });
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult _NuevaSolicitudAAlumno(mensaje msj, int referencia, int referencia2)
        {
            curso curso = mDb.curso.First(x => x.id == referencia);
            Int32 emisor = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            String tituloMensaje = "Solicitud a alumno para formar parte del curso " + curso.nombre;
            usuario destinatario = mDb.usuario.First(x => x.id == referencia2);
            NuevaSolicitud(emisor, msj.mensaje1, referencia, tituloMensaje, destinatario.id, (Int32)TipoSolicitud.asignarAlumnoACurso);
            if (mDb.SaveChanges() > 0)
            {
                return RedirectToAction("informeEnvioMensaje", new { enviados = destinatario.mail, noEnviados = "" });
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult NuevoMensaje(Int32 idDestinatario = 0, Boolean destinatarioAdmin = false)
        {
            if (destinatarioAdmin)
            {
                ViewBag.destinatario = "soporte@peals.com.ar";
            }
            else if (idDestinatario != 0)
            {
                ViewBag.destinatario = mDb.usuario.First(x => x.id == idDestinatario).mail;
            }
            else
            {
                ViewBag.destinatario = "0";
            }

            return View();
        }


        [HttpPost]
        public ActionResult cantidadMensajesSinLeer()
        {
            int id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var mensajes =
                from mens in mDb.mensaje
                join destinatarios in mDb.mensaje_x_destinatario on mens.id equals destinatarios.mensaje
                join emisor in mDb.usuario on mens.emisor_mensaje equals emisor.id
                where (mens.estado_mensaje == 1 || mens.estado_mensaje == 6) && destinatarios.destinatario == id_usuario_logeado
                orderby mens.fecha_mensaje descending
                select new
                {
                    ID = mens.id,
                    Estado = mens.estado_mensaje,
                    Tipo = mens.tipo_mensaje,
                    Mensaje = (mens.mensaje1.Length > 20) ? mens.mensaje1.Substring(0, 7) + "..." : mens.mensaje1,
                    Remitente = emisor.apellido + ", " + emisor.nombre
                };

            int total = mensajes.Count();

            List<object> mensajesANotificar = new List<object>();
            foreach (var msj_tmp in mensajes)
            {
                if (msj_tmp.Estado == 6)
                    continue;

                mensajesANotificar.Add(msj_tmp);
            }

            return Json(new { Total = total, Mensajes = mensajesANotificar }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void UpdateEstadoMensajes()
        {
            int id_usuario_logeado = Utiles.Sesion.GetIdUsuarioLogeado(ControllerContext);
            var mensajes =
                from mens in mDb.mensaje
                join destinatarios in mDb.mensaje_x_destinatario on mens.id equals destinatarios.mensaje
                where mens.estado_mensaje == 1 && destinatarios.destinatario == id_usuario_logeado
                select mens;

            foreach (var msj in mensajes)
            {
                msj.estado_mensaje = 6;
                mDb.ObjectStateManager.ChangeObjectState(msj, EntityState.Modified);
            }

            mDb.SaveChanges();
        }

        #endregion

        #region AUTOCOMPLETE
        public JsonResult AutocompleteDestinatarioPersona(string parametro)
        {
            var usuarios =
                from u in mDb.usuario
                where u.mail.Contains(parametro)
                select new { Value = u.mail, Label = u.mail, Id = u.id };
            return Json(usuarios.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteDestinatarioCurso(string parametro)
        {
            var cursos =
                from c in mDb.curso
                where c.nombre.Contains(parametro)
                select new { Value = c.nombre, Label = c.nombre, Id = c.nombre };
            return Json(cursos.Distinct().Take(5).ToList(), JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region ENVIAR MAIL
        public void enviarEmail(int usuarioDesde, string mailDestinatario, string asunto, string contenido)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = true;

                smtpServer.Credentials = new System.Net.NetworkCredential("plataforma.peals@gmail.com", "sorditos1");
                smtpServer.Port = 587;

                mail.From = new MailAddress("plataforma.peals@gmail.com");
                mail.To.Add(mailDestinatario);
                mail.Subject = "Tienes un nuevo mensaje en la plataforma PEALS";

                usuario usr = mDb.usuario.First(x => x.id == usuarioDesde);

                string mensaje = "Nombre usuario desde: " + usr.nombre + " " + usr.apellido + " \nE-Mail usuario desde: " + usr.mail + " \nAsunto: " + asunto + "\nMensaje: " + contenido;
                mail.Body = mensaje;

                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
            }
        }

        public void enviarEmail( string mailDestinatario, string asunto, string contenido)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = true;

                smtpServer.Credentials = new System.Net.NetworkCredential("plataforma.peals@gmail.com", "sorditos1");
                smtpServer.Port = 587;

                mail.From = new MailAddress("plataforma.peals@gmail.com");
                mail.To.Add(mailDestinatario);
                mail.Subject = "Tienes un nuevo mensaje en la plataforma PEALS";

                string mensaje = "Notificación de PEALS. \nAsunto: " + asunto + "\nMensaje: " + contenido;
                mail.Body = mensaje;

                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
            }
        }
        #endregion

    }
}
