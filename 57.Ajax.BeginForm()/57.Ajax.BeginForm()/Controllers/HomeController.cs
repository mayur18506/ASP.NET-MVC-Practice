using _57.Ajax.BeginForm__.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _57.Ajax.BeginForm__.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBEntities db = new EmployeeDBEntities();

        public ActionResult Index()
        {
            return View(db.employee2.ToList());
        }

        [HttpPost]
        public ActionResult Index(string q)
        {
            if (string.IsNullOrEmpty(q) == false)
            {
                List<employee2> emp = db.employee2.Where(model => model.name.StartsWith(q)).ToList();
                return PartialView("_SearchData", emp);
            }
            else
            {
                List<employee2> emp = db.employee2.ToList();
                return PartialView("_SearchData", emp);
            }
            //return PartialView("_SearchData", new List<employee2>());

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
