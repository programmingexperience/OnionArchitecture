using OA.WebAPI.ActionFilters;
using OA.WebAPI.Handlers;
using System.Web;
using System.Web.Mvc;

namespace OA.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Custom action filter
            //filters.Add(new ModelStateFilter());
            //filters.Add(new UnhandledExceptionFilter());
        }
    }
}
