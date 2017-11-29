using System;
using System.Collections.Generic;
using NLayer.BLL.Modals;
using NLayer.Common;

namespace NLayer.BLL.Services
{
    public interface IExternalDataService
    {
        ResultModel<IList<ExternalDataDTO>> GetUsers();
        ResultModel<ExternalDataDTO> GetUser(Guid userId);
    }
}
