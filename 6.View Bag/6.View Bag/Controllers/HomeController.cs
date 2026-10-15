using _6.View_Bag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _6.View_Bag.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Message from View Bag !!";
            ViewBag.CurrentDate = DateTime.Now.ToLongDateString();

            string[] Fruits = { "Apple", "Banana", "Grapes", "Orange" };
            ViewBag.FruitsArray = Fruits;

            ViewBag.sportslist = new List<string>()
            {
                "Cricket",
                "Football",
                "Hockey",
                "Baseball"
            };

            Employee Mayur = new Employee();

            Mayur.EmpId = 11;
            Mayur.EmpName = "Mayur Piprewar";
            Mayur.EmpDesignation = "Manager";

            ViewBag.Employee = Mayur;

            ViewBag.Messege2 = "This messege is accessible by both View Bag and View Data";

            return View();
        }
    }
}