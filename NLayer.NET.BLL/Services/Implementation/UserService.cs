using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NLayer.NET.BLL.Logger;
using NLayer.NET.BLL.Modals;
using NLayer.NET.Common;
using NLayer.NET.Common.Intarfeces;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Entities;
using NLayer.NET.DBL.Repositories;

namespace NLayer.NET.BLL.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ILog<UserService> _logger;

        public UserService(IUnitOfWork<AppDbContext> unitOfWork, ILogFactory logFactory)
        {
            _userRepository = unitOfWork.CreateRepository<User>();
            _logger = logFactory.CreateLogger<UserService>();
        }

        IResult<IList<UserDTO>> IUserService.GetUsers()
        {
            IEnumerable<User> usersList = _userRepository.GetAll();
            _logger.Info("GET UserRepository.GetAll()");

            IList<UserDTO> usersListDTO = Mapper.Map<IEnumerable<User>, IList<UserDTO>>(usersList);

            IResult<IList<UserDTO>> result = new Result<IList<UserDTO>>() { Value = usersListDTO };

            return result;
        }

        IResult<UserDTO> IUserService.GetUser(Guid userId)
        {
            var querySearch = new SearchQuery<User>();
            querySearch.AddFilter(x => x.Id == userId);
            var user = _userRepository.Search(querySearch).FirstOrDefault();
            _logger.Info("GET UserRepository.Search(querySearch)", querySearch);

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
            _logger.Info("GET UserRepository.Exists(querySearch)", querySearch);

            IResult<bool> result = new Result<bool>() { Value = user != null };
            return result;
        }
    }
}
