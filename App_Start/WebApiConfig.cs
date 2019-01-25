using Microsoft.Web.Http;
using Microsoft.Web.Http.Routing;
using Microsoft.Web.Http.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace APIVersioningTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof(ApiVersionRouteConstraint)
                }
            };

            config.AddApiVersioning(o =>
             {
                 o.ReportApiVersions = true;
                 o.AssumeDefaultVersionWhenUnspecified = true;
                 o.DefaultApiVersion = new ApiVersion(1, 0);
                 o.ApiVersionReader = new HeaderApiVersionReader("api-version");
                 //o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
             });

            //config.MapHttpAttributeRoutes();
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
