using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SteamApiTest.Models
{
    public class iCheckContext : DbContext
    {
        public iCheckContext(): base("ICheckDB")
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GameList> GameLists { get; set; }
        //MultipleActiveResultSets=true;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Game>()
                .HasMany(u => u.UserCheck)
                .WithMany(g => g.GamesChecked);

            modelBuilder.Entity<Game>()
                .HasMany(g => g.gameListed)
                .WithMany(g => g.GamesInList);

            modelBuilder.Entity<User>()
                .HasMany(g => g.GameList)
                .WithRequired(u => u.ListOwner);



        }

    }
}