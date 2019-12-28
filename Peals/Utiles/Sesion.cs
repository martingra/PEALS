using System;
using System.Web.Mvc;
using System.Web;

namespace Peals.Utiles
{
    public class Sesion
    {
        public static int GetIdUsuarioLogeado(ControllerContext cc) {


            if (cc.HttpContext.Request.Cookies["DatosUsuario"] != null)
            {
                return Convert.ToInt32(cc.HttpContext.Request.Cookies["DatosUsuario"]["idUsuario"]);
            }
            else
                return 0;

        }
    }
}