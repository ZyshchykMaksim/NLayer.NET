using AutoMapper;
using NLayer.BLL.Modals;
using NLayer.DAL.Entities;

namespace NLayer.PL.Mappings
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
