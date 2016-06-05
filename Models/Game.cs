using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApiTest.Models
{
    public class Game
    {
        public int Id { get; set; }

        public int GBEyeD { get; set; }
        public int NumOfChecks { get; set; }
        public string Name { get; set; }
        public virtual IList<User> CheckedByUser {get;set;}

        
    }
}