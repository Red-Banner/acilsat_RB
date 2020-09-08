using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using acilsat_RB.Models;
using System.Data.Entity;
using acilsat_RB.ViewModels;

namespace acilsat_RB.Controllers
{
    public class HomeController : Controller
    {

        acilsatDB db = new acilsatDB();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            if (TempData["registerError"] != null)
            {
                TempData["registerError1"] = "Girdiğiniz Kullanıcı Adı Kullanılmaktadır.";
            }
            ProductCategoryViewModel prodCatViewModel = new ProductCategoryViewModel();
            prodCatViewModel.Categories = db.Categories.ToList();
            prodCatViewModel.Products = db.Products.ToList();
            return View(prodCatViewModel);
        }

        [HttpPost]
        public ActionResult Login(string userName, string userPassword)
        {
            var user = db.Users.Where(x => x.userName == userName && x.userPassword == userPassword).SingleOrDefault();
            //userPasswordu tekrardan sorguya ekledim çünkü yanlış şifre girsek bile userName dogruysa hesaba giriş yapıyordu.
            HttpCookie UserCookie = new HttpCookie("ActiveUser");
            if (user != null)
            {
                UserCookie.Expires.AddHours(1);
                UserCookie["id"] = user.id.ToString();
                UserCookie["userName"] = user.userName;
                UserCookie["nameSurname"] = user.name + "" + user.surName;
                HttpContext.Response.Cookies.Add(UserCookie);
                return Redirect("~/Users/UsersProfile/" + user.id + "");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "userName,userPassword,name,surName,eMail,userPhone,userCity")] Users kullanıcılar)
        {
            var kullanıcı = db.Users.Where(x => x.userName == kullanıcılar.userName).SingleOrDefault();
            if (kullanıcı == null)
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(kullanıcılar);
                    db.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["registerError"] = "Girmiş Olduğunuz Kullanıcı Zaten Kayıtlı";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


    }
}