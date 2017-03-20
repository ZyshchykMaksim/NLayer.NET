using System.Web;
using System.Web.Mvc;
using NLayer.NET.PL.Filters;

namespace NLayer.NET.PL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new InternalErrorFilterAttribute());
        }
    }
}
