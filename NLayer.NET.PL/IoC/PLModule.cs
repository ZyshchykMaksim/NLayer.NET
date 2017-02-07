using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using NLayer.NET.BLL.Services;

namespace NLayer.NET.PL.IoC
{
    public class PLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterAssemblyTypes(typeof(UserService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
        }
    }
}