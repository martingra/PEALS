using System.Web;
using System.Web.Mvc;

namespace Peals.Utiles
{
    public static class Utils 
    {
        public static string GuardarArchivoEnDisco(HttpPostedFileBase archivo, ControllerContext cc)
        {
            string path = "~/Content/Resources/Uploads/";
            string fileName = System.DateTime.Now.ToString("ddMMyyyyHHmmss") + archivo.FileName;
            string filePath = System.IO.Path.Combine(path, fileName);
            archivo.SaveAs(cc.HttpContext.Request.MapPath(filePath));

            return filePath;
        }

        public static int? GetTipoDeRecurso(HttpPostedFileBase archivo)
        {
            if (archivo.ContentType.Contains("image")) 
                return (int)TipoDeRecurso.Imagen;
            else if (archivo.ContentType.Contains("audio")) 
                return (int)TipoDeRecurso.Audio;
            else if (archivo.ContentType.Contains("video")) 
                return (int)TipoDeRecurso.Video;
            else 
                return null;
        }
    }
}
