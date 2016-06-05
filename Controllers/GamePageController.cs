using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SteamApiTest.Models;

namespace SteamApiTest.Controllers
{
    public class GamePageController : Controller
    {
        // GET: GamePage
        public ActionResult Game()
        {
            var searchValue = Request.QueryString["search"];
            ViewBag.sq = searchValue;

            using (iCheckContext context = new iCheckContext())
            {
                int count = context.Users.Count();
                ViewBag.numUsers = count;
            }


            return View();
        }


        public ActionResult GameProfile(string gameID)
        {

            TempData["CurrentUrl"] = Request.Url.ToString();

            return View();
        }
    }
}