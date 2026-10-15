using _63.Binding_DropdownList_With_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _63.Binding_DropdownList_With_Database.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();
        public ActionResult Index()
        {
            List<employee2> empList = db.employee2.ToList();
            ViewBag.EmployeeTbl = new SelectList(empList, "Id", "name");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}