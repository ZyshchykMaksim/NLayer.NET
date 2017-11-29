using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.PL.Models;

namespace NLayer.NET.PL.Mappings
{
    public class PlMapping : Profile
    {
        public override string ProfileName => "PLMapping";

        public PlMapping()
        {
            //TODO Add your new mapping
            CreateMap<ExternalDataDTO, ExternalDataViewModel>();
        }
    }
}