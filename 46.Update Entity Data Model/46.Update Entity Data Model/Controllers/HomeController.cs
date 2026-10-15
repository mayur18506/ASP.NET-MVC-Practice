using _46.Update_Entity_Data_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _46.Update_Entity_Data_Model.Controllers
{
    public class HomeController : Controller
    {

        EDMExampleMVCEntities db = new EDMExampleMVCEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult Employee()
        {
            var data = db.Employees.ToList();
            return View(data);
        }
    }
}