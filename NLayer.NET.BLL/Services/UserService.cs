using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL.Entities;
using AutoMapper;
using NLayer.NET.Common;
using NLayer.NET.Common.Intarfeces;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Repositories;

namespace NLayer.NET.BLL.Services
{
    public interface IUserService
    {
        IResult<IList<UserDTO>> GetUsers();
        IResult<UserDTO> GetUser(Guid userId);
        IResult<bool> Exists(Guid userId);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWork<AppDbContext> unitOfWork)
        {
            _userRepository = unitOfWork.CreateRepository<User>();
        }

        IResult<IList<UserDTO>> IUserService.GetUsers()
        {
            IEnumerable<User> usersList = _userRepository.GetAll();
            IList<UserDTO> usersListDTO = Mapper.Map<IEnumerable<User>, IList<UserDTO>>(usersList);

            IResult<IList<UserDTO>> result = new Result<IList<UserDTO>>() { Value = usersListDTO };

            return result;
        }

        IResult<UserDTO> IUserService.GetUser(Guid userId)
        {
            var querySearch = new SearchQuery<User>();
            querySearch.AddFilter(x => x.Id == userId);
            var user = _userRepository.Search(querySearch).FirstOrDefault();

            UserDTO userDTO = Mapper.Map<User, UserDTO>(user);

            IResult<UserDTO> result = new Result<UserDTO>() { Value = userDTO };
            if (result.Value == null)
                result.Errors.Add(new Error() { ErrorCode = 404, ErrorMessage = "User is not found." });
            
            return result;
        }

        IResult<bool> IUserService.Exists(Guid userId)
        {
            var querySearch = new SearchQuery<User>();
            querySearch.AddFilter(x => x.Id == userId);

            var user = _userRepository.Search(querySearch).FirstOrDefault();

            IResult<bool> result = new Result<bool>() { Value = user != null };
            return result;
        }
    }
}
