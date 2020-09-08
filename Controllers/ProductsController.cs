using acilsat_RB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using acilsat_RB.ViewModels;
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
            Users user = db.Users.Find(product.userId);
            string nameSurname = user.name + " " + user.surName;
            TempData["categoryNo"] = product.categoryNo;
            TempData["nameSurname"] = nameSurname;
            TempData["userCity"] = user.userCity;
            TempData["userPhone"] = user.userPhone;
            TempData["productId"] = id;
            return View(db.Products.Where(x => x.categoryNo == product.categoryNo).ToList());
        }
        [HttpPost]
        public ActionResult ProductAdd([Bind(Include = "productName,categoryNo,productPrice,productDescription")] Products product)
        {
            Random rnd = new Random();
            if (ModelState.IsValid)
            {
                int counter = 0;
                product.userId = Convert.ToInt32(HttpContext.Request.Cookies["ActiveUser"]["id"]);
                int rndProductNo = rnd.Next(1000000, 9999999);
                while (counter < 100)
                {
                    var productCheck = db.Products.Where(x => x.productNo == rndProductNo).SingleOrDefault();
                    if (productCheck != null)
                    {
                        rndProductNo = rnd.Next(100000, 999999);
                    }
                    else
                    {
                        product.productNo = rndProductNo;
                        break;
                    }
                    counter++;
                }
                db.Products.Add(product);
                db.SaveChanges();
                ModelState.Clear();
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public ActionResult ProductAdd()
        {
            if (HttpContext.Request.Cookies["ActiveUser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        //Partial View çalışıyor fakat bi sayfaya bağlandığı zaman yine model çakışması yaşanıyor
        public ActionResult ProductSellList()
        {
            int userId = Convert.ToInt32(HttpContext.Request.Cookies["ActiveUser"]["id"]);
            return View(db.Products.Where(x => x.userId == userId).ToList());
        }
        [HttpGet]
        public ActionResult CategoryPage(int? id)
        {
            ProductCategoryViewModel prodCatViewModel = new ProductCategoryViewModel();
                prodCatViewModel.Categories = db.Categories.ToList();
                prodCatViewModel.Products = db.Products.ToList();
            if (id != null)
            {
                prodCatViewModel.Products = prodCatViewModel.Products.Where(x => x.categoryNo == id).ToList();
                prodCatViewModel.Categories = db.Categories.ToList();
                return View(prodCatViewModel);
            }
            return View(prodCatViewModel);
        }
    }
}