using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL.Entities;

namespace NLayer.NET.PL.Mappings
{
    public class BllMapping : Profile
    {
        public override string ProfileName => "BLLMapping";

        public BllMapping()
        {
            //TODO Add your new mapping
            CreateMap<ExternalData, ExternalDataDTO>();
        }
    }
}
