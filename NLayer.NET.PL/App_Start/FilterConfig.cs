﻿using NLayer.NET.PL.Filters;
using System.Web.Mvc;

namespace NLayer.NET.PL.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new InternalErrorFilterAttribute());
        }
    }
}