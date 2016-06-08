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
            iCheckContext context = new iCheckContext();
            string currUser = Session["UserName"].ToString();
            TempData["CurrentUrl"] = Request.Url.ToString();
            string[] split = Request.Url.ToString().Split('/');
            var gid = split.Last();

            try
            {
                var checks4thisGame = (from x in context.Games
                                       where x.GBID == gid
                                       select x).Single();
                Game g = checks4thisGame;
                ViewBag.gg = g.UserCheck.Count();
            }
            catch (Exception)
            {

                return View();
            }



                return View();
        }
    }
}