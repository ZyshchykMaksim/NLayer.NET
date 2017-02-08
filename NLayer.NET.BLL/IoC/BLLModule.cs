using System;
using System.Data.Entity;
using Autofac;
using NLayer.NET.Core.Intarfeces;
using NLayer.NET.DBL;

namespace NLayer.NET.BLL.IoC
{
    public class BLLModule : Module
    {
        public string NameOrConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //TODO Add conection string db context 
            //builder.RegisterType<AppDbContext>().As<DbContext>().WithParameter(
            //    new ResolvedParameter(
            //        (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "connectionString",
            //        (pi, ctx) => NameOrConnectionString));


            builder.RegisterType<AppDbContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
        }
    }
}
