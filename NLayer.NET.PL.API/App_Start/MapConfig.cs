using AutoMapper;
using NLayer.PL.API.Mappings;

namespace NLayer.PL.API
{
    public class MapConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.AddProfile<BLLMapping>();
                cfg.AddProfile<ApiMapping>();
            });
        }
    }
}