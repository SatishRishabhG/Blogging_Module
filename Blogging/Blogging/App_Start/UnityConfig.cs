using Blogging.Controllers;
using Blogging.Repo.Interfaces;
using Blogging.Repo.Repositories;
using Blogging.Service.Interfaces;
using Blogging.Service.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Unity;
using Unity.Injection;

namespace Blogging.App_Start
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IBloggingRepository, BloggingRepository>();
            container.RegisterType<IBloggingService, BloggingService>();

            container.RegisterInstance("GrapeCityBloggingEntities", new SqlConnection(ConfigurationManager.ConnectionStrings["GrapeCityBloggingEntities"].ConnectionString));

            container.RegisterType<IUserRepository, UserRepository>(
                "UserRepository",
                new InjectionConstructor(new ResolvedParameter<SqlConnection>("GrapeCityBloggingEntities")));

            container.RegisterType<IBloggingRepository, BloggingRepository>(
                "BloggingRepository",
                new InjectionConstructor(new ResolvedParameter<SqlConnection>("GrapeCityBloggingEntities")));

            container.RegisterType<IBloggingService, BloggingService>(
                "BloggingService",
                new InjectionConstructor(new ResolvedParameter("BloggingRepository")));


            //container.RegisterType<BloggingController>("BloggingController", new InjectionConstructor(new ResolvedParameter("BloggingService")));



        }

        /// <summary>
        /// Gets the configured Unity container
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }


    }
}