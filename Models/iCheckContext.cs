using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SteamApiTest.Models
{
    public class iCheckContext : DbContext
    {
        public iCheckContext(): base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ICheckGames;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GameList> GameLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameList>()
                 .HasRequired(u => u.ListOwner)
                 .WithMany(u => u.GameList);

            modelBuilder.Entity<Game>()
                .HasOptional(g => g.CheckedByUser);
                

                
        }

    }
}