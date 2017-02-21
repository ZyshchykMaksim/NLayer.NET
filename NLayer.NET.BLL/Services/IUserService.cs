using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.NET.BLL.Modals;
using NLayer.NET.Common.Intarfeces;

namespace NLayer.NET.BLL.Services
{
    public interface IUserService
    {
        IResult<IList<UserDTO>> GetUsers();
        IResult<UserDTO> GetUser(Guid userId);
        IResult<bool> Exists(Guid userId);
    }
}
