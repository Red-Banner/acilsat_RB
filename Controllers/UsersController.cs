using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using acilsat_RB.Models;

namespace acilsat_RB.Controllers
{
    public class UsersController : Controller
    {
        acilsatDB db = new acilsatDB();
        // GET: Users
        [HttpGet]
        
        public ActionResult UsersProfile(int? id)
        {
            if (HttpContext.Request.Cookies["ActiveUser"] == null)
            {
                return RedirectToAction("Index", "Home");


            }
            else
            {
                Users user = db.Users.Find(id);
               
                return View(user);
            }
         
        }

        public ActionResult Logout()
        {
            HttpContext.Response.Cookies["ActiveUser"].Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Update(int id ,Users info)
        {
            var user = db.Users.Find(id);
            user.eMail = info.eMail;
            user.userPhone = info.userPhone;
            user.userCity = info.userCity;
           
            db.SaveChanges();
            return Redirect("~/Users/UsersProfile/" + user.id + "");
        }

        public ActionResult UserSellList(int id)
        {
            var user = db.Users.Find(id);
            List<Products> sellitems  = db.Products.Where(x => x.userId == user.id).ToList();

            return PartialView("UserSellList",sellitems);
        }
    }
}