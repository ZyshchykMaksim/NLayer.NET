using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NLayer.NET.BLL;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL.Entities;
using NLayer.NET.PL.Mappings;
using NLayer.NET.PL.Models;

namespace NLayer.NET.PL
{
    public class MapConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BLLMapping>();
                cfg.AddProfile<PLMapping>();
            });
        }
    }
}