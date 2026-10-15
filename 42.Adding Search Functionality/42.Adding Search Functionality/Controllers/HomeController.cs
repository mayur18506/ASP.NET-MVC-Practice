using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _42.Adding_Search_Functionality.Models;

namespace _42.Adding_Search_Functionality.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: Home
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Name")
            {
                var data = db.emp1.Where(model => model.name.StartsWith(search)).ToList();
                return View(data);
            }
            else if (searchBy == "Gender")
            {
                var data = db.emp1.Where(model => model.gender == search).ToList();
                return View(data);
            }
            else
            {
                var data = db.emp1.ToList();
                return View(data);
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp1 emp1 = db.emp1.Find(id);
            if (emp1 == null)
            {
                return HttpNotFound();
            }
            return View(emp1);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,gender,age,designation")] emp1 emp1)
        {
            if (ModelState.IsValid)
            {
                db.emp1.Add(emp1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp1);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp1 emp1 = db.emp1.Find(id);
            if (emp1 == null)
            {
                return HttpNotFound();
            }
            return View(emp1);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,gender,age,designation")] emp1 emp1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp1);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emp1 emp1 = db.emp1.Find(id);
            if (emp1 == null)
            {
                return HttpNotFound();
            }
            return View(emp1);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emp1 emp1 = db.emp1.Find(id);
            db.emp1.Remove(emp1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
