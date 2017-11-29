using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.DB.EF.Extensions
{
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates the specified UnitOfWork.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns></returns>
        ITransactionalUnitOfWork Create(Type contextType);
    }
}
