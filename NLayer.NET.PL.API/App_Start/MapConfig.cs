using AutoMapper;
using NLayer.NET.BLL.Mappings;
using NLayer.NET.PL.Mappings;

namespace NLayer.NET.PL.API
{
    public class MapConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BLLMapping>();
                cfg.AddProfile<APIMapping>();
            });
        }
    }
}