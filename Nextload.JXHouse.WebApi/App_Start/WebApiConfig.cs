using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Nextload.JXHouse.WebApi.Unity;

namespace Nextload.JXHouse.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.DependencyResolver = new UnityDependencyResolver(UnityContainerFactory.GetUnityContainer());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "CustomApi",
                routeTemplate: "customapi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
