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

            var gc = (from x in context.Users
                        where x.Username == username
                        select x).Single();

            var steam64 = from x in context.Users
                          where x.Username == username
                          select x.Steam64;
            foreach (var s64 in steam64)
            {
                TempData["Steam64"] = s64;
            }
           
            ViewBag.user = uInfo;
            ViewBag.whoami = username;
            User u = gc;
            ViewBag.gc = u.GamesChecked.Count();

            //var list = from x in context.GameLists
            //           where x.ListOwner.Id == gc.Id
            //           select x;
            //ViewBag.list = list;

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
                Session["CurrentUser"] = Session["UserName"];
            }


            return Redirect("/");
        }
        public ActionResult Login()
        {
            string currUser = Session["UserName"].ToString();

            string updsteam = Request["updSteam"];
            if (updsteam != null)
            {
                string newSteam = Request["steam64uid"];
                iCheckContext context1 = new iCheckContext();

                var thisUser = (from x in context1.Users
                                where x.Username == currUser
                                select x).Single();
                User u = thisUser;
                u.Steam64 = newSteam;
                context1.SaveChanges();
                return Redirect("/");

            }
            



            string updpwbutton = Request["updPWbtn"];
           
            if (updpwbutton != null)
            {
                string pw2 = Request["newPassRow1"];
                string pw1 = Request["newPassRow2"];
                
                iCheckContext context2 = new iCheckContext();
                if (pw1 == pw2)
                {
                    var thisUser = (from x in context2.Users
                                    where x.Username == currUser
                                    select x).Single();
                    User u = thisUser;
                    u.Password = pw1;
                    context2.SaveChanges();
                    return Redirect("/");
                }
            }



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
                        Session["CurrentUser"] = Session["UserName"];
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
                Session["CurrentUser"] = "";
            }
            return Redirect("/");
        }

        public ActionResult UsersDB()
        {
            iCheckContext context = new iCheckContext();

            var allUsers = from x in context.Users
                           select x;

            ViewBag.AllUsers = allUsers;

            return View();
        }

       
    }

}