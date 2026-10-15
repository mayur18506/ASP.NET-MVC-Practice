using System.Web;
using System.Web.Mvc;

namespace _63.Binding_DropdownList_With_Database
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
