using Microsoft.EntityFrameworkCore;

namespace hm_5.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
