using System.Web;
using System.Web.Mvc;

namespace _55.Ajax_Begin_Form_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
