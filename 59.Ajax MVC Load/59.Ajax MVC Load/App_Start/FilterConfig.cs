using System.Web;
using System.Web.Mvc;

namespace _59.Ajax_MVC_Load
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
