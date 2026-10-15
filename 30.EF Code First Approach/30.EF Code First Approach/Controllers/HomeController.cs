using _30.EF_Code_First_Approach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _30.EF_Code_First_Approach.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted !!')</script>";

                    //TempData["InsertMessage"] = "<script>alert('Data Inserted !!')</script>";
                    TempData["InsertMessage"] = "Data Inserted !!";

                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted !!')</script>";

                }
            }
           
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Data Updated !!')</script>";
                    //TempData["UpdateMessage"] = "<script>alert('Data Updated !!')</script>";
                    TempData["UpdateMessage"] = "Data Updated !!";

                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Updated !!')</script>";

                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var StudentIdRow = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Data Updated !!')</script>";
                    TempData["UpdateMessage"] = "<script>alert('Data Updated !!')</script>";
                    //TempData["UpdateMessage"] = "Data Deleted !!";

                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Deleted !!')</script>";

                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var DetailsByid = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(DetailsByid);
        }
    }
}