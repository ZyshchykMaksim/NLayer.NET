using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.NET.BLL.Modals;
using NLayer.NET.Common.Intarfeces;

namespace NLayer.NET.BLL.Services
{
    public interface IExternalDataService
    {
        IResult<IList<ExternalDataDTO>> GetUsers();
        IResult<ExternalDataDTO> GetUser(Guid userId);
    }
}
