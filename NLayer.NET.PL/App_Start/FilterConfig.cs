using System.Web.Mvc;
using NLayer.PL.Filters;

namespace NLayer.PL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new InternalErrorFilterAttribute());
        }
    }
}
