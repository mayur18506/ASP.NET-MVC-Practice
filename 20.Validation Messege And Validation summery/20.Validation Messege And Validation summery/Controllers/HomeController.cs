using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace _20.Validation_Messege_And_Validation_summery.Controllers
{
    public class HomeController : Controller
    {
        string EmailPattern = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string FullName, string Age, string Email)
        {
            if (FullName.Equals("") == true)
            {
                ModelState.AddModelError("Fullname", "Full Name is required !!");
                ViewData["FullNameError"] = "*";
            }

            if (Age.Equals("") == true)
            {
                ModelState.AddModelError("Age", "Age is required !!");
                ViewData["AgeError"] = "*";

            }

            if (Email.Equals("") == true)
            {
                ModelState.AddModelError("Email", "Email is required !!");
                ViewData["EmailError"] = "*";

            }
            else
            {
                if (Regex.IsMatch(Email, EmailPattern) == false)
                {
                    ModelState.AddModelError("Email", "Invalid Email !!");
                    ViewData["EmailError"] = "*";
                }
            }

            if (ModelState.IsValid == true)
            {
                ViewData["SuccessMessege"] = "<script>alert('Data has been Submitted !!')</script>";
                ModelState.Clear();
            }
            return View();
        }
    }
}