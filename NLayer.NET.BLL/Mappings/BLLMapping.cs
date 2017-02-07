using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.NET.BLL.Modals;
using NLayer.NET.DBL.Entities;

namespace NLayer.NET.BLL
{
    public class BLLMapping : Profile
    {
        public override string ProfileName => "BLLMapping";

        public BLLMapping()
        {
            CreateMap<User, UserModel>();
        }
    }
}
