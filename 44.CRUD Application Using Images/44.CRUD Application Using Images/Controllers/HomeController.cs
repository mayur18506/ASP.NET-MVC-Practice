using _44.CRUD_Application_Using_Images.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _44.CRUD_Application_Using_Images.Controllers
{
    public class HomeController : Controller
    {
        ExampleDBEntities db = new ExampleDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data=db.Employees.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                string filename = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                string extension = Path.GetExtension(e.ImageFile.FileName);
                HttpPostedFileBase postedfile = e.ImageFile;
                int lenght = postedfile.ContentLength;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".jng" )
                {
                    if (lenght <= 1000000)
                    {
                        filename = filename + extension;
                        e.image_path = "~/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        e.ImageFile.SaveAs(filename);
                        db.Employees.Add(e);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Inserted Successfully')</script>";
                            ModelState.Clear();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Not Inserted ')</script>";

                        }
                    }
                    else
                    {
                    TempData["SizeMessage"] = "<script>alert('Image Size should be 1 MB')</script>";

                    }
                }
                else
                {
                    TempData["ExtensionMessage"] = "<script>alert('Format Not Supported')</script>";
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var EmployeeRow = db.Employees.Where(model => model.id == id).FirstOrDefault();
            Session["Image"] = EmployeeRow.image_path;

            return View(EmployeeRow);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                if (e.ImageFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                    string extension = Path.GetExtension(e.ImageFile.FileName);
                    HttpPostedFileBase postedfile = e.ImageFile;
                    int lenght = postedfile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".jng")
                    {
                        if (lenght <= 1000000)
                        {
                            filename = filename + extension;
                            e.image_path = "~/Images/" + filename;
                            filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                            e.ImageFile.SaveAs(filename);
                            db.Entry(e).State=EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                string ImagePath = Request.MapPath(Session["Image"].ToString());
                                if (System.IO.File.Exists(ImagePath))
                                {
                                    System.IO.File.Delete(ImagePath);
                                }
                                TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                                ModelState.Clear();
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data Not Updatedted ')</script>";

                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size should be 1 MB')</script>";

                        }
                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported')</script>";
                    }
                }
                else
                {
                    e.image_path = Session["Image"].ToString();
                    db.Entry(e).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Not Updatedted ')</script>";

                    }
                }
            }
            

            return View();
        }


        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var EmployeeRow = db.Employees.Where(model => model.id == id).FirstOrDefault();
                if (EmployeeRow != null)
                {
                    db.Entry(EmployeeRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted Successfully')</script>";
                        string ImagePath=Request.MapPath(EmployeeRow.image_path.ToString());
                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);
                        }
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted')</script>";

                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Details(int id)
        {
            var employeeRow = db.Employees.Where(model => model.id == id).FirstOrDefault();
            Session["Image2"]=employeeRow.image_path.ToString();
            return View(employeeRow);
        }
    }
}