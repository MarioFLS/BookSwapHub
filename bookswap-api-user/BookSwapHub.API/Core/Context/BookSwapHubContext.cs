
using BookSwapHub.API.Core.Models;
using BookSwapHub.API.Core.Models.BaseDate;
using Microsoft.EntityFrameworkCore;

namespace BookSwapHub.API.Core.Context
{
    public class BookSwapHubContext : DbContext
    {
        public BookSwapHubContext() { }
        public BookSwapHubContext(DbContextOptions<BookSwapHubContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=BookSwapContext;User=SA;Password=Password12!;Encrypt=False");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseEntity>()
        .Property(e => e.CreatedAt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<BaseEntity>()
                .Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
            base.OnModelCreating(modelBuilder);
        }

        /* public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        } */
    }
}