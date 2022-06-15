using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class WaterConditionsRepository : IWaterConditionsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public WaterConditionsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WaterCondition>> GetAll(string? name = null, WateringIntensity? wateringIntensity = null)
        {
            var all = dbContext.Set<WaterCondition>().AsNoTracking();

            if (name != null)
            {
                all = all.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            if (wateringIntensity != null)
            {
                all = all.Where(p => p.Intensity == wateringIntensity);
            }

            return await all.ToListAsync();
        }

        public async Task<WaterCondition> GetById(int id)
        {
            return await dbContext.WaterConditions.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddWaterCondition(WaterCondition waterCondition)
        {
            dbContext.WaterConditions.Add(waterCondition);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateWaterCondition(WaterCondition waterCondition)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteWaterCondition(WaterCondition waterCondition)
        {
            var plants = await dbContext.Plants.Where(p => p.WaterConditionId == waterCondition.Id).ToListAsync();
            foreach (var plant in plants)
            {
                plant.WaterCondition = null;
            }
            await dbContext.SaveChangesAsync();
            dbContext.Remove(waterCondition);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
