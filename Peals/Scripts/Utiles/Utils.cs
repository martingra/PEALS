using System.Web;

namespace Peals.Utiles
{
    public static class Utils 
    {
        public static string GuardarArchivoEnDisco(HttpPostedFileBase file)
        {
            // definimos el path donde guardamos las imagenes del usuario
            string filePath = System.IO.Path.Combine("~/Content/Resources/Uploads/", file.FileName);
            file.SaveAs(filePath);

            return filePath;
        }
    }
}
