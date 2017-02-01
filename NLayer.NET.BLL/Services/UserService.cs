using NLayer.NET.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DAL.Core;
using NLayer.NET.DBL.EF;
using NLayer.NET.DBL.Entities;
using AutoMapper;

namespace NLayer.NET.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork<AppDbContext> _db;
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork<AppDbContext> unitOfWork)
        {
            _db = unitOfWork;
            _userRepository = _db.CreateGenericRepository<User>();
        }

        public IList<UserModel> GetUsers()
        {
            var users = _userRepository.Find();
            return Mapper.Map<IList<User>, IList<UserModel>>(users);
        }

        public bool Exists(Guid idUser)
        {
            var user = _userRepository.Find(x => x.Id == idUser).FirstOrDefault();
            return user != null;
        }

        public UserModel GetUser(Guid idUser)
        {
            var user = _userRepository.Find(x => x.Id == idUser).FirstOrDefault();
            return Mapper.Map<User, UserModel>(user);
        }
    }
}
