using System;
using System.Data.Entity;
using Autofac;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Infrastructure;

namespace NLayer.NET.BLL.IoC
{
    public class BLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        }
    }
}
