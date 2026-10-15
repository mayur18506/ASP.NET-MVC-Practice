using _55.Ajax_Begin_Form_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _55.Ajax_Begin_Form_MVC.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.employees.Add(e);
                int a = db.SaveChanges();
                if (a>0)
                {
                    return JavaScript("alert('Data Inserted !!')"); //Javascript Object Notation
                }
                else
                {

                    return Json("Data Not Inserted !!");
                }
            }
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