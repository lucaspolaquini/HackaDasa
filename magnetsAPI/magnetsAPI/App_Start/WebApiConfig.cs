using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace magnetsAPI
{
    public static class WebApiConfig
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            config.EnableCors();
            // Web API configuration and services

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //SwaggerConfig.Register();
        }
    }
}
