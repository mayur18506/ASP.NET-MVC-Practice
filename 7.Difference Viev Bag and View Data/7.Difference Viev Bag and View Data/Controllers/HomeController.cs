using _7.Difference_Viev_Bag_and_View_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _7.Difference_Viev_Bag_and_View_Data.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Message1"] = "Data Comes from ViewData";
            ViewBag.Message2 = "Data Comes from ViewBag";

            ViewData["CurrentDate1"]=DateTime.Now.ToString();
            ViewBag.CurrentDate2 = DateTime.Now.ToString();

            string[] games = { "Hockey", "Football", "Cricket", "Baseball" };

            ViewData["GameArray1"] = games;
            ViewBag.GamesArray2 = games;

            Employee employee = new Employee();

            employee.EmpId = 11;
            employee.EmpName = "Mayur Piprewar";
            employee.EmpAge = 21;

            ViewData["Employee1"] = employee;
            ViewBag.Employee2 = employee;


            return View();
        }
    }
}