﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;

namespace Peals
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "MyCustomRoute",
                "{controller}/{action}/{accion}/{controlador}/{label}/{value}/{idList}",
                new { controller = "Home", action = "Index", accion = UrlParameter.Optional, controlador = UrlParameter.Optional, label = UrlParameter.Optional, value = UrlParameter.Optional, idList = UrlParameter.Optional }
            );

            routes.MapRoute(
                "autocompleteConPadre",
                "{controller}/{action}/{accion}/{controlador}/{label}/{value}/{idList}/{idEntidad}",
                new { controller = "Home", action = "Index", accion = UrlParameter.Optional, controlador = UrlParameter.Optional, label = UrlParameter.Optional, value = UrlParameter.Optional, idList = UrlParameter.Optional, idEntidad = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            RouteTable.Routes.MapHubs(); //agregado a mano para dar soporte a signalR

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (Request.IsAuthenticated && Request.Cookies["DatosUsuario"] != null)
            {
                // devuelve los roles
                string[] roles = new string[1];
                roles[0] = Request.Cookies["DatosUsuario"]["tipoUsuario"];

                if (Context.User != null)
                    Context.User = new GenericPrincipal(Context.User.Identity, roles);
            }
        }
    }
}