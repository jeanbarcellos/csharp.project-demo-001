using Demo.Core.Data;
using Demo.Domain.Entities;
using Demo.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Infra.Data
{
    public class DemoContext : DbContext, IUnitOfWork
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMapping).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    var dateNow = DateTime.Now;
                    entry.Property("CreatedAt").CurrentValue = dateNow;
                    entry.Property("UpdatedAt").CurrentValue = dateNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("UpdatedAt") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}