using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NLayer.NET.BLL.Services;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Infrastructure;

namespace NLayer.NET.PL
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            //TODO Close exception
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterGeneric(typeof(IUnitOfWork<>)).As(typeof(UnitOfWork<>));
            builder.RegisterGeneric(typeof(IRepository<object>)).As(typeof(Repository<object>));

            builder.RegisterType<IUserService>().As<UserService>();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}