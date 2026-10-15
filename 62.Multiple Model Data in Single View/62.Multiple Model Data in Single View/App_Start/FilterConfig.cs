using System.Web;
using System.Web.Mvc;

namespace _62.Multiple_Model_Data_in_Single_View
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
