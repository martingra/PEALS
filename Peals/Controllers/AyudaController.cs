using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peals.Controllers
{
    public class AyudaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPartialView(string nombre)
        {
            return PartialView(nombre);
        }

        protected void ExportarAWord()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformatsofficedocument.wordprocessingml.documet";
            Response.AddHeader("Content-Disposition", "attachment; filename=WORK_ORDER.doc");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Charset = "";
            System.IO.StringWriter writer = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter html = new System.Web.UI.HtmlTextWriter(writer);
            Response.Write(writer);
            Response.End();
        } 
    }
}
