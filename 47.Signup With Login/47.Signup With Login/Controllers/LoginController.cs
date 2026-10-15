using _47.Signup_With_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _47.Signup_With_Login.Controllers
{
    public class LoginController : Controller
    {
        SignupLogin1Entities db = new SignupLogin1Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(mayur u)
        {
            var user = db.mayurs.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
            if (user != null) 
            {
                Session["UserId"] = u.Id.ToString();
                Session["Username"] = u.username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or Password is Incorrect !!')</script>";
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult Signup(mayur u)
        {
            if (ModelState.IsValid == true)
            {
                db.mayurs.Add(u);
               int a = db.SaveChanges();
                if (a>0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully !!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registration Failed !!')</script>";

                }
            }
            return View();
        }
    }
}