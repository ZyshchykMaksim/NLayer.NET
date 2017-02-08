using System;
using System.Collections.Generic;
using System.Linq;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL.Entities;
using AutoMapper;
using NLayer.NET.Core.Intarfeces;
using NLayer.NET.DBL;

namespace NLayer.NET.BLL.Services
{
    public interface IUserService
    {
        IList<UserDTO> GetUsers();
        UserDTO GetUser(Guid userId);
        bool Exists(Guid userId);
    }

    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IUnitOfWork<AppDbContext> unitOfWork)
        {
            _userRepository = unitOfWork.CreateGenericRepository<User>();
        }

        public IList<UserDTO> GetUsers()
        {
            var users = _userRepository.GetAll();
            return Mapper.Map<IEnumerable<User>, IList<UserDTO>>(users);
        }

        public bool Exists(Guid userId)
        {
            var user = _userRepository.Find(x => x.Id == userId).FirstOrDefault();
            return user != null;
        }

        public UserDTO GetUser(Guid userId)
        {
            var user = _userRepository.Find(x => x.Id == userId).FirstOrDefault();
            return Mapper.Map<User, UserDTO>(user);
        }
    }
}
