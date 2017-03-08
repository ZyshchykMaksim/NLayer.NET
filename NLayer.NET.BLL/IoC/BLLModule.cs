using System.Data.Entity;
using Autofac;
using NLayer.NET.BLL.Logger;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Repositories.Implementation;
using NLayer.NET.DBL.Repositories;

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


            builder.RegisterType<AppDbContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<LogFactory>().As<ILogFactory>();
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        }
    }
}
