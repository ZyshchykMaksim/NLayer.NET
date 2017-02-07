using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

using NLayer.NET.BLL.IoC;
using NLayer.NET.PL.IoC;

namespace NLayer.NET.PL
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new BLLModule());
            builder.RegisterModule(new PLModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}