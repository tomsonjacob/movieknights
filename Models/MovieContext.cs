using Microsoft.EntityFrameworkCore;

namespace MovieKnights.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {}

        public DbSet<User> User { get; set; }
        public DbSet<Watch> Watch { get; set; }
    }
}