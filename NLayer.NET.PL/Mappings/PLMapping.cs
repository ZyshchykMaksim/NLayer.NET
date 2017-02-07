using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.PL.Models;

namespace NLayer.NET.PL.Mappings
{
    public class PLMapping : Profile
    {
        public override string ProfileName => "PLMapping";

        public PLMapping()
        {
            CreateMap<UserDTO, UserModelView>();
        }
    }
}