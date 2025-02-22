using Microsoft.EntityFrameworkCore;
using Mission7_Redden.Models;

namespace Mission7_Redden.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }  // Add Categories table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Define Foreign Key Relationship
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CategoryId);
        }
    }
}