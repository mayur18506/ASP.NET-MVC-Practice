using _5.View_Data_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace _5.View_Data_Demo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Messege"] = "Messege from View Data !!";
            ViewData["CurrentTime"] = DateTime.Now.ToLongTimeString();

            string[] fruits = { "Apple", "Banana", "Grapes", "Orange" };
            ViewData["FruitsArray"] = fruits;

            ViewData["SportsList"] = new List<string>()
            {
                "Cricket",
                "Hockey",
                "Football",
                "Volly Ball"
            };

            Employee mayur = new Employee();
            mayur.EmpID = 20;
            mayur.EmpName = "Mayur Piprewar";
            mayur.EmpDesignation = "Manager";

            ViewData["Employee"] = mayur;

            return View();
        }
    }
}