using _62.Multiple_Model_Data_in_Single_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _62.Multiple_Model_Data_in_Single_View.Controllers
{
    public class HomeController : Controller
    {
        SchoolDBEntities db = new SchoolDBEntities();
        public ActionResult Index()
        {
            var std = getStudents();
            var tchr = getteacher();

            //MultiModelData data = new MultiModelData();
            //data.my_students = std;
            //data.my_teachers = tchr;

            ViewBag.student = std;
            ViewBag.teacher = tchr;

            //ViewData["student"]  = std;
            //ViewData["Teacher"] = tchr;

            return View();
        }

        public List<student> getStudents()
        {
            return db.students.ToList();
        }
        public List<teacher> getteacher()
        {
            return db.teachers.ToList();
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