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
                TempData["userId"] = user.id;
                TempData["name"] = user.name;
                TempData["surname"] = user.surName;
                    


                return View(user);
            }
         
        }

        public ActionResult Logout()
        {
            HttpContext.Response.Cookies["ActiveUser"].Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Index", "Home");
        }
    }
}