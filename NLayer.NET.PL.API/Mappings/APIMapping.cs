using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.PL.API.Models;

namespace NLayer.NET.PL.Mappings
{
    public class APIMapping : Profile
    {
        public override string ProfileName => "APIMapping";

        public APIMapping()
        {
            //TODO Add your new mapping
            CreateMap<ExternalDataDTO, ExternalDataViewModel>();
        }
    }
}