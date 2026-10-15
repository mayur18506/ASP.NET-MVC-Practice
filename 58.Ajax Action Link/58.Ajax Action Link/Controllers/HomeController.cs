using _58.Ajax_Action_Link.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _58.Ajax_Action_Link.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllEmployees()
        {
            var data = db.employee2.ToList();

            return PartialView("_Employees",data);
        }

        public ActionResult Top3Emp()
        {
            var data = db.employee2.OrderByDescending(model => model.salary).Take(3).ToList();

            return PartialView("_Employees", data);
        }

        public ActionResult Bottom3Emp()
        {
            var data = db.employee2.OrderBy(model => model.salary).Take(3).ToList();

            return PartialView("_Employees", data);
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