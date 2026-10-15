using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8.Temp_Data.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Var1"] = "Messege From View Data";
            ViewBag.Var2 = "Messege From View Bag";
            TempData["Var3"] = "Messege From Temp Data";


            //string[] games = { "Cricket", "Hockey", "Football", "Baseball" };

            //TempData["GamesArray"] = games;

            return RedirectToAction("About");
            //return View();
        }

        public ActionResult About()
        {
            if (TempData["Var3"] != null)
            {
                TempData["Var3"].ToString();
            }

            TempData.Keep();
            return View();
        }

        public ActionResult Contact()
        {
            if (TempData["Var3"] != null)
            {
                TempData["Var3"].ToString();
            }
            TempData.Keep();

            return View();
        }
    }
}