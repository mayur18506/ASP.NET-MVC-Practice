using _52.Result_output_cache_Filter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _52.Result_output_cache_Filter.Controllers
{
    public class HomeController : Controller
    {
        PersonEntities db = new PersonEntities();

        [OutputCache(Duration = 5 ,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            ViewBag.Time = DateTime.Now.ToLongTimeString();
            return View();
        }

        [OutputCache(Duration = 40 )]
        public ActionResult GetData()
        {
            var data = db.people.ToList();
            return View(data);
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