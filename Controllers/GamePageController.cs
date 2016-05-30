using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SteamApiTest.Controllers
{
    public class GamePageController : Controller
    {
        // GET: GamePage
        public ActionResult Game()
        {
            var searchValue = Request.QueryString["search"];
            ViewBag.sq = searchValue;
            return View();
        }
    }
}