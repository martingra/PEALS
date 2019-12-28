using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace Peals.Controllers
{
    public class ContactoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Contacto/
        [HttpPost]
        public ActionResult Index(string txtNombre, string txtTelefono, string txtMail, string txtComentario)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = true;

                smtpServer.Credentials = new System.Net.NetworkCredential("plataforma.peals@gmail.com", "sorditos1");
                smtpServer.Port = 587; // Gmail works on this port

                mail.From = new MailAddress(txtMail);
                mail.To.Add("plataforma.peals@gmail.com");
                mail.Subject = "Nuevo comentario desde la página PEALS";

                string mensaje = "Nombre: " + txtNombre + " \n Telefono: " + txtTelefono + " \n E-Mail: " + txtMail + "\n Comentario: " + txtComentario;
                mail.Body = mensaje;

                smtpServer.Send(mail);
                return View("Exito");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        public ActionResult Exito()
        {
            return View();
        }

    }
}
