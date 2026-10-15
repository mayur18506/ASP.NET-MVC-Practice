using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _38.Login_Form_Using_Session_and_EF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction(" index", "Login");
            }
            return View();
        }
    }
}