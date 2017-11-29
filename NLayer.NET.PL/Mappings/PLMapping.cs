using AutoMapper;
using NLayer.BLL.Modals;
using NLayer.PL.Models;

namespace NLayer.PL.Mappings
{
    public class PlMapping : Profile
    {
        public override string ProfileName => "PLMapping";

        public PlMapping()
        {
            //TODO Add your new mapping
            CreateMap<ExternalDataDTO, ExternalDataViewModel>();
        }
    }
}