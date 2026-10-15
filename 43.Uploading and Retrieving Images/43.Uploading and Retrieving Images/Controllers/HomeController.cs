using _43.Uploading_and_Retrieving_Images.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _43.Uploading_and_Retrieving_Images.Controllers
{
    public class HomeController : Controller
    {
        NewDBEntities1 db = new NewDBEntities1();
        // GET: Home

        public ActionResult Index()
        {
            var data = db.Student2.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student2 s)
        {
            string filename = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
            string extension = Path.GetExtension(s.ImageFile.FileName);
            HttpPostedFileBase postedFile = s.ImageFile;
            int length = postedFile.ContentLength;

            if (extension.ToLower() == ".jpg"|| extension.ToLower() == ".png" || extension.ToLower() == ".jpeg ")
            {
                if (length <= 1000000)
                {
                    filename = filename + extension;
                    s.image_path = "~/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                    s.ImageFile.SaveAs(filename);
                    db.Student2.Add(s);

                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.Messsage = "<script>alert('Record Inserted !!')</script>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Messsage = "<script>alert('Record Not Inserted !!')</script>";

                    }
                }
                else
                {
                        ViewBag.SizeMesssage = "<script>alert('Size Should be of 1 MB !!')</script>";

                }
            }

            else
            {
                        ViewBag.ExtensionMesssage = "<script>alert('Image Not Supported !!')</script>";

            }

            return View();
        }
    }
}
