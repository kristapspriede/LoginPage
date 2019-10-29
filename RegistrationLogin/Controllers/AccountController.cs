using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RegistrationLogin.Models;

namespace RegistrationLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        

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
                Session["UserID"] = account.UserID.ToString();
                Session["UserName"] = account.UserName;
                return RedirectToAction("CompletedRegistration");
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

        

        public ActionResult CompletedRegistration()
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
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}