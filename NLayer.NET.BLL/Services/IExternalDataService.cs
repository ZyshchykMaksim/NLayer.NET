using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.Common;
using NLayer.NET.BLL.Modals;

namespace NLayer.NET.BLL.Services
{
    public interface IExternalDataService
    {
        ResultModel<IList<ExternalDataDTO>> GetUsers();
        ResultModel<ExternalDataDTO> GetUser(Guid userId);
    }
}
