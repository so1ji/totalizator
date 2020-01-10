using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Totalizator
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Register",
                routeTemplate: "api/{controller}/{action}");

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{name}",
            defaults: new { name = RouteParameter.Optional }
        );
        }
    }
}
