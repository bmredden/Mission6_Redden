using Microsoft.EntityFrameworkCore;
using Mission6_Redden.Models;

namespace Mission6_Redden.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; } // Movies table
    }
}