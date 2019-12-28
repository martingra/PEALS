using System;
using System.Web.Mvc;

namespace Peals.Utiles
{
    public class Sesion
    {
        public static int GetIdUsuarioLogeado(ControllerContext cc) {
            return Convert.ToInt32(cc.HttpContext.Request.Cookies["idUsuario"].Value);
        }
    }
}