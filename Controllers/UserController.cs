using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SteamApiTest.Models;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.IO;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace SteamApiTest.Controllers
{
    public class UserController : Controller
    {
        // GET: User


       

        
        public ActionResult UserInfo()
        {
            
           return Json( JsonRequestBehavior.AllowGet);
        }

  

        public ActionResult UserProfile(string username)
        {
            iCheckContext context = new iCheckContext();
            var uInfo = from x in context.Users
                        where x.Username == username
                        select x;

            ViewBag.user = uInfo;
            
            return View();
        }

        public ActionResult Register()
        {
        
            string iuName = Request["UserName"];
            string iEmail = Request["Email"];
            string iFName = Request["FName"];
            string iLname = Request["LName"];
            string iDoB = Request["DoB"];
            string iCountry = Request["Country"];
            string iSteamID = Request["Steam64"];
            string password1 = Request["Password"];
            string password2 = Request["PasswordCheck"];

            iCheckContext context = new iCheckContext();
            ViewBag.userTaken = null;
            ViewBag.MissPaswword = null;
            foreach (User u in context.Users)
            {
                if (iuName == u.Username || iuName == "")
                {
                    ViewBag.userTaken = "Username taken";
                }
                if (password1 != password2)
                {
                    ViewBag.MissPassword = "Wrong password";
                }
               
            }
            DateTime convertDoB = Convert.ToDateTime(iDoB);
            if (ViewBag.userTaken == null && ViewBag.MissPassword == null)
            {
                context.Users.Add(new User {
                    Username = iuName,
                    Email = iEmail,
                    FirstName = iFName,
                    LastName = iLname,
                    DoB = convertDoB,
                    Country = iCountry,
                    Steam64 = iSteamID
                });
                
                context.SaveChanges();
                Session["IsLoggedIn"] = true;
                Session["UserName"] = iuName;
            }


            return Redirect("/");
        }
        public ActionResult Login()
        {
            string uName = Request["LoginUserName"];
            string password = Request["LoginPassword"];

            iCheckContext context = new iCheckContext();

            foreach (User u in context.Users)
            {
                if (uName == u.Username)
                {
                    if (password == u.Password)
                    {
                        Session["IsLoggedIn"] = true;
                        Session["UserName"] = uName;
                     
                    }
                }
            }

            return Redirect("/");
        }
        public ActionResult Logout()
        {
            string logout = Request["logoutButton"];
            if (logout != null)
            {
                Session["IsLoggedIn"] = false;
                Session["UserName"] = "";
            }
            return Redirect("/");
        }
    }

}