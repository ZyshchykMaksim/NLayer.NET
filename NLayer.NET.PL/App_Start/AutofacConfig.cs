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
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AppDbContext>().As<DbContext>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}