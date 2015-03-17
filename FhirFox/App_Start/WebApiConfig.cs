﻿using FhirFox.Handlers;
using FhirFox.Handlers.Formatters;
using FhirFox.Resolver;
using FhirFox.Services;
using Microsoft.Practices.Unity;
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

            //DEPENDENCY INJECTION
            var container = new UnityContainer();

            container.RegisterType<IFhirService, FhirService>(new HierarchicalLifetimeManager());
            container.RegisterType<IModelConvertor, ModelConvertor>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            //FHIR FORMATTER
            config.Formatters.Add(new FhirJsonFormatter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
