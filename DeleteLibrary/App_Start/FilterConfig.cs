using System.Web;
using System.Web.Mvc;
using DeleteLibrary.Filters;

namespace DeleteLibrary
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
