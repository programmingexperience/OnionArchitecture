using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using OA.Service.Interfaces;
using OA.WebAPI.Resolver;
using OA.Service.Services;
using OA.Repo.UoW;
using OA.WebAPI.Handlers;

namespace OA.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Handler for request and response logging. 
            config.MessageHandlers.Add(new LogRequestAndResponseHandler());

            // Web API configuration and services
            var container = new UnityContainer();
            //container.RegisterType<IGenericRepository, GenericRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGenericUoW, GenericUoW>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserSrvc, UserSrvc>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrderSrvc, OrderSrvc>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
