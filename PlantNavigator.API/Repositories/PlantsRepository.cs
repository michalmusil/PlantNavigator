using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories
{
    public class PlantsRepository : IPlantsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public PlantsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public async Task<IEnumerable<Plant>> GetAll(Expression<Func<Plant, bool>> predicate = null)
        {
            var all = dbContext.Set<Plant>().AsNoTracking();

            if (predicate != null)
            {
                all = all.Where(predicate);
            }

            all = all.Include(p => p.WaterCondition).Include(p => p.LightCondition);

            return await all.ToListAsync();
        }

        public async Task<Plant> GetById(int id)
        {
            return await dbContext.Plants.Where(p => p.Id == id).FirstOrDefaultAsync();
        }




        public async Task<IEnumerable<Plant>> GetPlantsOfSoil(int id)
        {
            var all = dbContext.Set<Plant>().AsNoTracking();
            all = all.Include(p => p.Plant_Soils).Include(p => p.WaterCondition).Include(p => p.LightCondition);
            all = all.Where(p => p.Plant_Soils.Any(s => s.SoilId == id));

            return await all.ToListAsync();
        }

        public async Task<bool> DeletePlant(Plant plant)
        {
            dbContext.Remove(plant);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> SoilExists(int id)
        {
            return await dbContext.Soils.AnyAsync(s => s.Id == id);
        }

    }
}
