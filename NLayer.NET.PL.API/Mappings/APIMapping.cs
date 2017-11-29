using AutoMapper;
using NLayer.BLL.Modals;
using NLayer.PL.API.Models;

namespace NLayer.PL.API.Mappings
{

    public class ApiMapping : Profile
    {
        public override string ProfileName => "APIMapping";

        public ApiMapping()
        {
            //TODO Add your new mapping
            CreateMap<ExternalDataDTO, ExternalDataViewModel>();
        }
    }
}