using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.PL.Models;

namespace NLayer.NET.PL
{
    public class MapConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserModel, UserModelView>();
            });
        }
    }
}