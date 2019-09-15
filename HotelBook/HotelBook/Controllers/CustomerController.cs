using HotelBook.Models;
using RegistrationAndLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelBook.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] Customer user)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {
                var isExist = IsAccountExist(user.Account_id);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                using (HotelDBEntities dc = new HotelDBEntities())
                {
                    dc.Customers.Add(user);
                    dc.SaveChanges();


                    Status = true;
                }
            }
            else
            {
                message = "Invalid Request";
            }

                ViewBag.Message = message;
                ViewBag.Status = Status;
                return View(user);
            }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(login login, string ReturnUrl = "")
        {
            string message = "";
            using (HotelDBEntities dc = new HotelDBEntities())
            {
                var v = dc.Customers.Where(a => a.Account_id == login.Account_id).FirstOrDefault();
                if (v != null)
                {
                    
                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.Remember ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.Account_id, login.Remember, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);


                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Customer");
        }

        [NonAction]
        public bool IsAccountExist(string Account_id)
        {
            using (HotelDBEntities dc = new HotelDBEntities())
            {
                var v = dc.Customers.Where(a => a.Account_id == Account_id).FirstOrDefault();
                return v != null;
            }
        }

    }
}
