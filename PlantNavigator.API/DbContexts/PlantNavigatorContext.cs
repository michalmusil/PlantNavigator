using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.DbContexts
{
    public class PlantNavigatorContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<WaterCondition> WaterConditions { get; set; } = null!;
        public DbSet<LightCondition> LightConditions { get; set; } = null!;
        public DbSet<Soil> Soils { get; set; } = null!;
        public DbSet<Plant_Soil> Plants_Soils { get; set; } = null!;

        public PlantNavigatorContext(DbContextOptions<PlantNavigatorContext> options) 
            : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant_Soil>()
                .HasOne(p => p.Plant)
                .WithMany(ps => ps.Plant_Soils)
                .HasForeignKey(pi => pi.PlantId);

            modelBuilder.Entity<Plant_Soil>()
                .HasOne(p => p.Soil)
                .WithMany(ps => ps.Plant_Soils)
                .HasForeignKey(pi => pi.SoilId);
        }
    }
}
