using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuftbornTask.Domain.Entities;
using LuftbornTask.Infrastructure.Persistence.EntityConfiguration;

namespace LuftbornTask.Infrastructure.Persistence
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public DbSet<Clinic> Clinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClinicConfiguration());

            // Apply global query filter for all entities inheriting from BaseClass
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseClass).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(AppDbContext)
                        .GetMethod(nameof(SetGlobalQueryFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                        ?.MakeGenericMethod(entityType.ClrType);

                    method?.Invoke(null, new object[] { modelBuilder });
                }
            }
        }
        private static void SetGlobalQueryFilter<TEntity>(ModelBuilder modelBuilder) where TEntity : BaseClass
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
