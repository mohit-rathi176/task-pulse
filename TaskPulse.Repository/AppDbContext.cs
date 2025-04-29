using Microsoft.EntityFrameworkCore;

namespace TaskPulse.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Entities.Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Task>()
                .Property(t => t.Title)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Entities.Task>()
                .Property(t => t.CreatedDate)
                .HasColumnType("datetime");

            modelBuilder.Entity<Entities.Task>()
                .Property(t => t.ModifiedDate)
                .HasColumnType("datetime");
        }
    }
}
