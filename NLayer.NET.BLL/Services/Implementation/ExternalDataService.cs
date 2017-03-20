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
    public class ExternalDataService : IExternalDataService
    {
        private readonly IRepository<ExternalData> _userRepository;
        private readonly ILog<ExternalDataService> _logger;

        public ExternalDataService(IUnitOfWork<AppDbContext> unitOfWork, ILogFactory logFactory)
        {
            _userRepository = unitOfWork.CreateRepository<ExternalData>();
            _logger = logFactory.CreateLogger<ExternalDataService>();
        }

        IResult<IList<ExternalDataDTO>> IExternalDataService.GetUsers()
        {
            IEnumerable<ExternalData> externalDataList = _userRepository.GetAll();
            _logger.Info("GET UserRepository.GetAll()");

            IList<ExternalDataDTO> usersListDTO = Mapper.Map<IEnumerable<ExternalData>, IList<ExternalDataDTO>>(externalDataList);

            IResult<IList<ExternalDataDTO>> result = new Result<IList<ExternalDataDTO>>() { Value = usersListDTO };

            return result;
        }

        IResult<ExternalDataDTO> IExternalDataService.GetUser(Guid userId)
        {
            var querySearch = new SearchQuery<ExternalData>();
            querySearch.AddFilter(x => x.Id == userId);
            var externalData = _userRepository.Search(querySearch).FirstOrDefault();
            _logger.Info("GET UserRepository.Search(querySearch)", querySearch);

            ExternalDataDTO externalDataDTO = Mapper.Map<ExternalData, ExternalDataDTO>(externalData);

            IResult<ExternalDataDTO> result = new Result<ExternalDataDTO>() { Value = externalDataDTO };
            if (result.Value == null)
                result.Errors.Add(new Error() { ErrorCode = 404, ErrorMessage = "External Data is not found." });

            return result;
        }
    }
}
