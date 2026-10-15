using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace _40.Remember_Me_CheckBox.Controllers
{
    public class LoginController : Controller
    {
        LoginDB2Entities db = new LoginDB2Entities();
        // GET: Login
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                ViewBag.username = cookie["username"].ToString();

                string EncryptPassword = cookie["Password"].ToString();
                byte[] b = Convert.FromBase64String(EncryptPassword);
                string decryptPassword = ASCIIEncoding.ASCII.GetString(b);

                ViewBag.password = decryptPassword.ToString();

            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(User1 u)
        {
            HttpCookie cookie = new HttpCookie("User");

            if (ModelState.IsValid == true)
            {
                if (u.RememberMe == true)
                {
                    cookie["username"] = u.username;

                    byte[] b = ASCIIEncoding.ASCII.GetBytes(u.password);
                    string EncryptedPassword = Convert.ToBase64String(b);

                    cookie["password"] = EncryptedPassword;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }

                var row = db.User1.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
                if (row != null)
                {
                    Session["Username"] = u.username;
                    TempData["Message"] = "<script>alert('Login Successfull !!')</script>";
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["Message"] = "<script>alert('Login Failed !!')</script>";

                }
            }
            return View();
        }
        
    }
}