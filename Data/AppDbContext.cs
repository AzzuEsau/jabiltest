using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Director> Directories { get; set; }
        public DbSet<DirectorsMovie> DirectorsMovies { get; set; }
    }
}