using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace _6._1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;User Id=postgres;Password=pass;Port=5432;Database=postgres;");
        }
    }
}
