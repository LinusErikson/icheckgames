using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApiTest.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string GBID { get; set; }
        public string Name { get; set; }
        public virtual IList<User> UserCheck {get;set;}
        public virtual IList<GameList> gameListed {get;set;}

        
    }
}