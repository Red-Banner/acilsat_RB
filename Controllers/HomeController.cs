﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using acilsat_RB.Models;
using System.Data.Entity;
namespace acilsat_RB.Controllers
{
    public class HomeController : Controller
    {
        acilsatDB db = new acilsatDB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName,string userPassword)
        {
            var kullanici = db.Users.Where(x => x.userName == userName).SingleOrDefault();
            HttpCookie UserCookie = new HttpCookie("ActiveUser");
            if (kullanici != null)
            {
                UserCookie.Expires.AddHours(1);
                UserCookie["id"] = kullanici.id.ToString();
                UserCookie["userName"] = kullanici.userName;
                HttpContext.Response.Cookies.Add(UserCookie);



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
                ViewData["registerError"] = "Girdiğiniz Kullanıcı Adı Kullanılmaktadır.";
            }
            return RedirectToAction("Index/#modal1");
        }


    }
}