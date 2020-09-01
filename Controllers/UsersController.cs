using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acilsat_RB.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult UsersProfile()
        {
            if (HttpContext.Request.Cookies["ActiveUser"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
         
        }

        public ActionResult Logout()
        {
            HttpContext.Response.Cookies["ActiveUser"].Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Index", "Home");
        }
    }
}