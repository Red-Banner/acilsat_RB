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
        public ActionResult UsersProfile()
        {
            return View();
        }
    }
}