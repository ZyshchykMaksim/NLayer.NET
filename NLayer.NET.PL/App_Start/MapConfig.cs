using AutoMapper;
using NLayer.PL.Mappings;

namespace NLayer.PL
{
    public class MapConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BllMapping>();
                cfg.AddProfile<PlMapping>();
            });
        }
    }
}