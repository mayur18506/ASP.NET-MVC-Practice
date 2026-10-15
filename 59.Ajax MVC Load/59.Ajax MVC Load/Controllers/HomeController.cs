using _59.Ajax_MVC_Load.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _59.Ajax_MVC_Load.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();
        public ActionResult Index()
        {
            int num = 5;
            Session["Data"] = num;
            var data = db.Employee4.ToList().Take(num);
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(Employee4 e)
        {
            int rows = Convert.ToInt32(Session["Data"]) + 5;
            var data = db.Employee4.ToList().Take(rows);
            Session["Data"] = rows;
            return PartialView("_EmpData",data);
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