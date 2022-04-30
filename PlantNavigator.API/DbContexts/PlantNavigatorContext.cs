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
            // M:N Plants and Soils
            modelBuilder.Entity<Plant_Soil>()
                .HasOne(p => p.Plant)
                .WithMany(ps => ps.Plant_Soils)
                .HasForeignKey(pi => pi.PlantId);

            modelBuilder.Entity<Plant_Soil>()
                .HasOne(p => p.Soil)
                .WithMany(ps => ps.Plant_Soils)
                .HasForeignKey(pi => pi.SoilId);


            // M:N Plants and Pests
            modelBuilder.Entity<Plant_Pest>()
                .HasOne(p => p.Plant)
                .WithMany(ps => ps.Plant_Pests)
                .HasForeignKey(pi => pi.PlantId);

            modelBuilder.Entity<Plant_Pest>()
                .HasOne(p => p.Pest)
                .WithMany(ps => ps.Plant_Pests)
                .HasForeignKey(pi => pi.PestId);


            // M:N Plants and Diseases
            modelBuilder.Entity<Plant_Disease>()
                .HasOne(p => p.Plant)
                .WithMany(ps => ps.Plant_Diseases)
                .HasForeignKey(pi => pi.PlantId);

            modelBuilder.Entity<Plant_Disease>()
                .HasOne(p => p.Disease)
                .WithMany(ps => ps.Plant_Diseases)
                .HasForeignKey(pi => pi.DiseaseId);


            // M:N Plants and Watering Habits
            modelBuilder.Entity<Plant_WateringHabit>()
                .HasOne(p => p.Plant)
                .WithMany(ps => ps.Plant_WateringHabits)
                .HasForeignKey(pi => pi.PlantId);

            modelBuilder.Entity<Plant_WateringHabit>()
                .HasOne(p => p.WateringHabit)
                .WithMany(ps => ps.Plant_WateringHabits)
                .HasForeignKey(pi => pi.WateringHabitId);


            // M:N Plants and Fertilizing Habits
            modelBuilder.Entity<Plant_FertilizingHabit>()
                .HasOne(p => p.Plant)
                .WithMany(ps => ps.Plant_FertilizingHabits)
                .HasForeignKey(pi => pi.PlantId);

            modelBuilder.Entity<Plant_FertilizingHabit>()
                .HasOne(p => p.FertilizingHabit)
                .WithMany(ps => ps.Plant_FertilizingHabits)
                .HasForeignKey(pi => pi.FertilizingHabitId);


            // M:N Plants and Classifications
            modelBuilder.Entity<Plant_Classification>()
                .HasOne(p => p.Plant)
                .WithMany(ps => ps.Plant_Classifications)
                .HasForeignKey(pi => pi.PlantId);

            modelBuilder.Entity<Plant_Classification>()
                .HasOne(p => p.Classification)
                .WithMany(ps => ps.Plant_Classifications)
                .HasForeignKey(pi => pi.ClassificationId);


            // M:N Fertilizing Habits and Fertilizer Types
            modelBuilder.Entity<FertilizingHabit_FertilizerType>()
                .HasOne(p => p.FertilizingHabit)
                .WithMany(ps => ps.FertilizingHabit_FertilizerTypes)
                .HasForeignKey(pi => pi.FertilizingHabitId);

            modelBuilder.Entity<FertilizingHabit_FertilizerType>()
                .HasOne(p => p.FertilizerType)
                .WithMany(ps => ps.FertilizingHabit_FertilizerTypes)
                .HasForeignKey(pi => pi.FertilizerTypeId);
        }
    }
}
