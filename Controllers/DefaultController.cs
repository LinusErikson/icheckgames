using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SteamApiTest.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {

            return View();
       
        }

        public ActionResult getPlayerInfo()
        {
            WebRequest request = WebRequest.Create("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=01A694C1280C995EE53475E509B80E79&steamids=76561197985361431");

            Stream dataStream = request.GetResponse().GetResponseStream();
            //// Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            //// Read the content.
            string responseFromServer = reader.ReadToEnd();

            //string replacement = Regex.Replace(responseFromServer, @"\t|\n|\r", "");


            return Json(responseFromServer, JsonRequestBehavior.AllowGet);

        }
        

        public ActionResult getRecentGame()
        {
            WebRequest request = WebRequest.Create("http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=01A694C1280C995EE53475E509B80E79&steamid=76561197985361431&format=json");

            Stream dataStream = request.GetResponse().GetResponseStream();
            //// Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            //// Read the content.
            string responseFromServer = reader.ReadToEnd();

            //string replacement = Regex.Replace(responseFromServer, @"\t|\n|\r", "");


            return Json(responseFromServer, JsonRequestBehavior.AllowGet);

        }

        public ActionResult getGameInfo()   
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.giantbomb.com/api/game/3030-4725/?api_key=d46581bb69a487551688b5e5fdc7a93fa8630096&format=json");
            
            Stream dataStream = request.GetResponse().GetResponseStream();
            //// Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            //// Read the content.
            string responseFromServer = reader.ReadToEnd();

            //string replacement = Regex.Replace(responseFromServer, @"\t|\n|\r", "");


            return Json(responseFromServer, JsonRequestBehavior.AllowGet);

        }

    }
}