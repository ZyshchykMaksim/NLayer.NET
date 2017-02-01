using NLayer.NET.BLL.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.NET.BLL.Interfaces
{
    public interface IUserService
    {
        IList<UserModel> GetUsers();
        UserModel GetUser(Guid idUser);
        bool Exists(Guid idUser);
    }
}
