using _15.STRONGLY_TYPED_VIEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _15.STRONGLY_TYPED_VIEW.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Employee e1 = new Employee()
            {
                Id = 1,
                Name = "Mayur",
                Age = 21
            };

            Employee e2 = new Employee()
            {
                Id = 2,
                Name = "Rahul",
                Age = 20
            };

            Employee e3 = new Employee()
            {
                Id = 3,
                Name = "Aman",
                Age = 19
            };

            List<Employee> employees = new List<Employee>()
    {
        e1,
        e2,
        e3
    };

            ViewData["var1"] = e1;
            ViewBag.Var2 = e2;

            return View(employees);
        }
       

        
    }
}