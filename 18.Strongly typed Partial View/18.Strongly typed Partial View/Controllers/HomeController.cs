using _18.Strongly_typed_Partial_View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _18.Strongly_typed_Partial_View.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        List<Product> ProductsList = new List<Product>()
        {
            new Product {id=1,name="Reebok shoes" ,price=10000.00,picture="~/Images/images (2).jpg"},
            new Product {id=2,name="Reyben Sunglasses" ,price=1000.00,picture="~/Images/images (1).jpg"},
            new Product {id=3,name="Rolex Watch" ,price=50000.00,picture="~/Images/images.jpg"},

        };
        public ActionResult Index()
        {
            return View(ProductsList);
        }
    }
}