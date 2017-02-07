using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL.Entities;

namespace NLayer.NET.BLL.Mappings
{
    public class BLLMapping : Profile
    {
        public override string ProfileName => "BLLMapping";

        public BLLMapping()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
