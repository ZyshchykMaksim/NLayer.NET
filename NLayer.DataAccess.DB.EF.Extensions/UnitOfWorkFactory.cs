using System;
using System.Data.Entity;
using CommonServiceLocator;

namespace NLayer.DataAccess.DB.EF.Extensions
{
    /// <summary>
    /// The UnitOfWork factory.
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates the specified UnitOfWork.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns></returns>
        public ITransactionalUnitOfWork Create(Type contextType)
        {
            return new UnitOfWork(ServiceLocator.Current.GetInstance<DbContext>(contextType.Name));
        }
    }
}
