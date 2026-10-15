using System.Web;
using System.Web.Mvc;

namespace _58.Ajax_Action_Link
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
