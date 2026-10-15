using System.Web;
using System.Web.Mvc;

namespace _61.JQuery_DataTable_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
