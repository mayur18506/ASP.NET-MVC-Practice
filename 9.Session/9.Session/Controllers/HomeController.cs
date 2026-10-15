using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _9.Session.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Var1"] = "Data comes From ViewData";
            ViewBag.Var2 = "Data comes From ViewBag";
            TempData["Var3"] = "Data comes From TempData";
            Session["Var4"] = "Data comes From Session";

            string[] students = { "Mayur", "Aman", "Kunal", "Lucky" };

            Session["Var5"] = students;
            return View();
        }

        public ActionResult About()
        {
            if (Session["Var4"] != null)
            {
                Session["Var4"].ToString();
            }
            return View();
        }

        public ActionResult Contact()
        {
            if (Session["Var4"] != null)
            {
                Session["Var4"].ToString();
            }
            return View();
        }
    }
}