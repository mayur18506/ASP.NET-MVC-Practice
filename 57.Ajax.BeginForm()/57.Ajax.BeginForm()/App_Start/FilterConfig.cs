using System.Web;
using System.Web.Mvc;

namespace _57.Ajax.BeginForm__
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
