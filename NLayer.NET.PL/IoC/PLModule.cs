using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using NLayer.NET.BLL.Logger;
using NLayer.NET.BLL.Services;
using NLayer.NET.BLL.Services.Implementation;

namespace NLayer.NET.PL.IoC
{
    public class PLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<LogFactory>().As<ILogFactory>();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
        }
    }
}