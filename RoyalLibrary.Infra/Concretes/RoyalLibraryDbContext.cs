using Microsoft.EntityFrameworkCore;
using RoyalLibrary.Infra.Abstractions;
using RoyalLibrary.Models.Mapping;
using System.ComponentModel.DataAnnotations;

namespace RoyalLibrary.Infra.Concretes
{
    public class RoyalLibraryDbContext(DbContextOptions<RoyalLibraryDbContext> options) : DbContext(options), IRoyalLibraryDbContext
    {
        private void ValidateEntities()
        {
            var entities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, true);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookMapping());
        }

        public override int SaveChanges()
        {
            ValidateEntities();
            return base.SaveChanges();
        }
    }
}