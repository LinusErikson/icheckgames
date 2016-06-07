using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SteamApiTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public DateTime DoB { get; set; }
        public string Steam64 { get; set; }
        public virtual IList<Game> GamesChecked { get; set; }
        public virtual IList<GameList> GameList { get; set; }
    }
}