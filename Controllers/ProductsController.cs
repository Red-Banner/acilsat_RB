using acilsat_RB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acilsat_RB.Controllers
{
    public class ProductsController : Controller
    {
        acilsatDB db = new acilsatDB();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetail(int id)
        {
            Products product = db.Products.Find(id);
            return View(product);
        }
    }
}