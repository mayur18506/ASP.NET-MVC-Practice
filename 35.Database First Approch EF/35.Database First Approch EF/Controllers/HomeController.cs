using _35.Database_First_Approch_EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _35.Database_First_Approch_EF.Controllers
{
    public class HomeController : Controller
    {

        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.student1.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(student1 s)
        {
            if (ModelState.IsValid == true)
            {
                db.student1.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted !!')</script>";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted !!')</script>";

                }
            }
            
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.student1.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(student1 s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated !!')</script>";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Updated !!')</script>";

                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var Deletedrow = db.student1.Where(model => model.id == id).FirstOrDefault();
            return View(Deletedrow);
        }

        [HttpPost]
        public ActionResult Delete(student1 s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Deleted !!')</script>";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Not Deleted !!')</script>";

                }
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            var row = db.student1.Where(model => model.id == id).FirstOrDefault();

            return View(row);
        }
    }
}