using System;
using System.Collections.Generic;
using System.Linq;
using NLayer.Common;
using NLayer.DataAccess.DB;
using NLayer.DataAccess.DB.EF;
using NLayer.DataAccess.DB.EF.Extensions;
using NLayer.Logging;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Entities;


namespace NLayer.NET.BLL.Services.Implementation
{
    public class ExternalDataService : IExternalDataService
    {
        private readonly IRepository<ExternalData> userRepository;
        private readonly ILog<ExternalDataService> logger;
        private readonly ITransactionalUnitOfWork uow;

        public ExternalDataService(IUnitOfWorkFactory unitOfWorkFactory, ILogFactory logFactory)
        {
            this.uow = unitOfWorkFactory.Create(typeof(AppDbContext));
            userRepository = uow.CreateRepository<ExternalData>();

            logger = logFactory.CreateLogger<ExternalDataService>();
        }

        ResultModel<IList<ExternalDataDTO>> IExternalDataService.GetUsers()
        {
            //IEnumerable<ExternalData> externalDataList = userRepository.Query().AsEnumerable();

            //logger.Info("GET UserRepository.GetAll()");

            //IList<ExternalDataDTO> usersListDto = Mapper.Map<IEnumerable<ExternalData>, IList<ExternalDataDTO>>(externalDataList);

            return ResultModel<IList<ExternalDataDTO>>.Successful(null);
        }

        ResultModel<ExternalDataDTO> IExternalDataService.GetUser(Guid userId)
        {
            //var querySearch = new SearchQuery<ExternalData>();
            //querySearch.AddFilter(x => x.Id == userId);
            //var externalData = userRepository.Search(querySearch).FirstOrDefault();
            //logger.Info("GET UserRepository.Search(querySearch)", querySearch);

            //ExternalDataDTO externalDataDto = Mapper.Map<ExternalData, ExternalDataDTO>(externalData);

            //IResult<ExternalDataDTO> result = new Result<ExternalDataDTO>() { Value = externalDataDto };
            //if (result.Value == null)
            //    result.Errors.Add(new Error() { ErrorCode = 404, ErrorMessage = "External Data is not found." });

            return ResultModel<ExternalDataDTO>.Failed();
        }
    }
}
