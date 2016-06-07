using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApiTest.Models
{
    public class GameList
    {
        public int Id { get; set; }
        public int NumOfStars { get; set; }
        public virtual User ListOwner { get; set; }
        public virtual IList<Game> GamesInList { get; set; }
    }
}