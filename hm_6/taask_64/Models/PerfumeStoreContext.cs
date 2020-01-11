using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taask_64
{
    public class PerfumeStoreContext : DbContext
    {
        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public PerfumeStoreContext(DbContextOptions<PerfumeStoreContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Port=5432;Database=PerfumeStoreNew63;Username=postgres;Password=Aa3sdf&;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
