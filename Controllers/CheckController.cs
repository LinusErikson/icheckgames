using SteamApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamApiTest.Controllers
{
    public class CheckController : Controller
    {
        // GET: Check
        public ActionResult Index()
        {
            string gamechecked = Request["checkBTN"];

            //iCheckContext context = new iCheckContext();
            //foreach (User u in context.Users)
            //{
            //    ViewBag.asd = u.GamesChecked.CheckedByUser;
            //}

            return Redirect("/");
        }
    }
}