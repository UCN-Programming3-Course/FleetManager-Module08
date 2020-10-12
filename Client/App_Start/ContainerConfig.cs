using Autofac;
using Autofac.Integration.Mvc;
using Data;
using Data.Model;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Client
{
    public class ContainerConfig
    {
        public static void RegisterContainers()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CarRepository>()
                .As<IRepository<Car>>();

            builder.RegisterType<LocationRepository>()
                .As<IRepository<Location>>();

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}