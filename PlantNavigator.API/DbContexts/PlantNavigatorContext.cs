using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.Entities;

namespace PlantNavigator.API.DbContexts
{
    public class PlantNavigatorContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<WaterCondition> WaterConditions { get; set; } = null!;
        public DbSet<LightCondition> LightConditions { get; set; } = null!;

        public PlantNavigatorContext(DbContextOptions<PlantNavigatorContext> options) 
            : base(options) { 
        }
    }
}
