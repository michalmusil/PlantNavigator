using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.Enums;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class LightConditionsRepository : ILightConditionsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public LightConditionsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<LightCondition>> GetAll(string? name = null, SunlightIntensity? lightIntensity = null)
        {
            var all = dbContext.Set<LightCondition>().AsNoTracking();

            if (name != null)
            {
                all = all.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            if (lightIntensity != null)
            {
                all = all.Where(p => p.Intensity == lightIntensity);
            }

            return await all.ToListAsync();
        }

        public async Task<LightCondition> GetById(int id)
        {
            return await dbContext.LightConditions.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddLightCondition(LightCondition lightCondition)
        {
            dbContext.LightConditions.Add(lightCondition);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLightCondition(LightCondition lightCondition)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLightCondition(LightCondition lightCondition)
        {
            var plants = await dbContext.Plants.Where(p => p.LightConditionId == lightCondition.Id).ToListAsync();
            foreach (var plant in plants)
            {
                plant.LightCondition = null;
            }
            await dbContext.SaveChangesAsync();
            dbContext.Remove(lightCondition);
            return await dbContext.SaveChangesAsync() > 0;
        }

    }
}
