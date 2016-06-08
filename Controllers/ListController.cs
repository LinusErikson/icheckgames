using SteamApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamApiTest.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            //string currUser = Session["UserName"].ToString();
            //string gamechecked = Request["listBTN"];
            //string[] split = gamechecked.Split('/');
            //var gameID = split.Last();
            //var gameName = split.First();

            //iCheckContext context = new iCheckContext();


            
            return View();
        }
    }
}