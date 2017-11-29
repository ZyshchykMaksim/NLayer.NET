using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.PL.API.Models;

namespace NLayer.NET.PL.API.Mappings
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