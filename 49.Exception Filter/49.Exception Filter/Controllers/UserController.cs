using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _49.Exception_Filter.Controllers
{
    [HandleError(View = "Error2")]

    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            throw new Exception();

            return View();
        }
    }
}