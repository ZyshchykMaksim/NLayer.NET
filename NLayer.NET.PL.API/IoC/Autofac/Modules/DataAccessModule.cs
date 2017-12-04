using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Autofac;
using NLayer.DataAccess.DB;
using NLayer.DataAccess.DB.EF;
using NLayer.DataAccess.DB.EF.Extensions;
using NLayer.DAL;

namespace NLayer.PL.API.IoC.Autofac.Modules
{
    /// <summary>
    /// Adds components in the container.
    /// </summary>
    public class DataAccessModule : Module
    {
        #region Overrides of Module

        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>()
                .Named<DbContext>("AppDbContext")
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWorkFactory>()
                .As<IUnitOfWorkFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }

        #endregion
    }
}