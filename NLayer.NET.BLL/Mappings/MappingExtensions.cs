using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLayer.NET.Common;
using NLayer.NET.Common.Intarfeces;

namespace NLayer.NET.BLL.Mappings
{
    public static class MappingExtensions
    {
        public static IMappingExpression<TSrc, TDest> IncludePagedResultMapping<TSrc, TDest>(
            this IMappingExpression<TSrc, TDest> expression)
        {
            //expression.CreateMap<Result<TSrc>, IResult<TDest>>()
            //    .ForMember(dest => dest.HasMoreResults, opt => opt.MapFrom(src => src.HasMoreResults))
            //    .ForMember(dest => dest.NextPage, opt => opt.MapFrom(src => src.NextPage));

            return expression;
        }
    }
}
