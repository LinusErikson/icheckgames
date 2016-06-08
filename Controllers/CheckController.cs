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
            string currUser = Session["UserName"].ToString();
            string gamechecked = Request["checkBTN"];
            string[] split = gamechecked.Split('/');
            var gameID = split.Last();
            var gameName = split.First();

            iCheckContext context = new iCheckContext();

            var gameInDB = from x in context.Games
                           where x.GBID == gameID
                           select x;

             
            if (gameInDB.Count() < 1)
            {
                context.Games.Add(new Game
                {
                    GBID = gameID,
                    Name = gameName
                });

            }
            context.SaveChanges();

            var addThisGame = (from x in context.Games
                               where x.Name == gameName
                               select x).Single();


            var toThisUser = (from x in context.Users
                              where x.Username == currUser
                              select x).Single();


            User u = toThisUser;


            if (!u.GamesChecked.Contains(addThisGame))
            {
                u.GamesChecked.Add(addThisGame);
            }




            context.SaveChanges();
           
            //string[] spliter = Request.Url.ToString().Split('/');
            //string idid = spliter.Last();
            return Redirect("/");
        }
    }
}