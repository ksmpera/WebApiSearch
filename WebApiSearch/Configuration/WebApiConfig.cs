using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace WebApiSearch.Configuration
{
    public class WebApiConfig
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebApiConfig));

        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            log.DebugFormat("HttpConfiguration is {0}", config);

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        }
    }
}