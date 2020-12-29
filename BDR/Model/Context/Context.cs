using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.Model.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Actor> actor { get; set; }
        public DbSet<ActorFilm> actor_film { get; set; }
        public DbSet<Agent> agent { get; set; }
        public DbSet<Director> director { get; set; }
        public DbSet<Film> film { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=p;Database=BDR3");
        }
    }
}
