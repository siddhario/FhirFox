using FhirFox.Handlers;
using FhirFox.Handlers.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace FhirFox
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
        
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IExceptionHandler), new FhirExceptionHandler());

            config.Formatters.Add(new FhirJsonFormatter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
