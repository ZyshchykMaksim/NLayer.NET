using AutoMapper;

using NLayer.NET.PL.API.Mappings;

namespace NLayer.NET.PL.API
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