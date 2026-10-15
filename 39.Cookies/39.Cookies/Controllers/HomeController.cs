using _39.Cookies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _39.Cookies.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            if (ModelState.IsValid == true)
            {
                HttpCookie cookie = new HttpCookie("Username");
                cookie.Value = u.Username;

                HttpContext.Response.Cookies.Add(cookie);
                cookie.Expires = DateTime.Now.AddDays(2);
                return RedirectToAction("index", "Dashboard");
            }
            return View();
        }
    }
}