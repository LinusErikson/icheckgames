using SteamApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SteamApiTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Default", action = "Index" }
            );

            routes.MapRoute("GamePage", 
                   "GamePage/GameProfile/{id}",
                   new
                   {
                       controller = "GamePage",
                       action = "GameProfile",
                       id = ""
                   }
            );

            routes.MapRoute("Profile",
                "profile/{username}/",
                new { controller = "User", action = "UserProfile" }
                );

            routes.MapRoute("GameSearch",
                 "GameSearch/Game/{id}",
                 new
                 {
                     controller = "GamePage",
                     action = "Game",
                     id = ""
                 }
          );

            routes.MapRoute("Login",
                   "User/Login/",
                   new
                   {
                       controller = "User",
                       action = "Login",
                       
                   }
            );
            routes.MapRoute("Logout",
                  "User/Logout/",
                  new
                  {
                      controller = "User",
                      action = "Logout",
                      
                  }
           );
            routes.MapRoute("Register",
                "User/Register/",
                new
                {
                    controller = "User",
                    action = "Register",
                    
                }
         );

        }
    }
}
