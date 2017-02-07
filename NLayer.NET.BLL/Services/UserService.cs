using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL.Entities;
using AutoMapper;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Infrastructure;

namespace NLayer.NET.BLL.Services
{
    public interface IUserService
    {
        IList<UserDTO> GetUsers();
        UserDTO GetUser(Guid idUser);
        bool Exists(Guid idUser);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork<AppDbContext> unitOfWork)
        {
            _userRepository = unitOfWork.CreateGenericRepository<User>();
        }

        public IList<UserDTO> GetUsers()
        {
            var users = _userRepository.GetAll();
            return Mapper.Map<IEnumerable<User>, IList<UserDTO>>(users);
        }

        public bool Exists(Guid idUser)
        {
            var user = _userRepository.Find(x => x.Id == idUser).FirstOrDefault();
            return user != null;
        }

        public UserDTO GetUser(Guid idUser)
        {
            var user = _userRepository.Find(x => x.Id == idUser).FirstOrDefault();
            return Mapper.Map<User, UserDTO>(user);
        }
    }
}
