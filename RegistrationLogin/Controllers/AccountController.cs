using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationLogin.Models;

namespace RegistrationLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (UserDBContext db = new UserDBContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account) 
        {
            if (ModelState.IsValid)
            {
                using (UserDBContext db = new UserDBContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Registration successful! Please Login!";
                return RedirectToAction("LoggedIn");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (UserDBContext db = new UserDBContext())
            {
                var usr = db.userAccount
                    .FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                if (usr == null)
                {
                    
                    ModelState.AddModelError("", "Username or Password is wrong");
                }
                else
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["UserName"] = usr.UserName;
                    return RedirectToAction("LoggedIn");
                }
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}