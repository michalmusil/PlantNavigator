using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class SoilsRepository : ISoilsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public SoilsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Soil>> GetAll(string? name = null, int? plantId = null, bool? includeAsociatedPlants = null)
        {
            var all = dbContext.Set<Soil>().AsNoTracking();

            if (includeAsociatedPlants == true)
            {
                all = all.Include(s => s.Plant_Soils);
            }

            if (name != null)
            {
                all = all.Where(s => s.Name.ToLower().Contains(name.ToLower()));
            }

            if (plantId != null)
            {
                all = all.Where(s => s.Plant_Soils.Any(x => x.PlantId == plantId));
            }            

            return await all.ToListAsync();
        }

        public async Task<Soil> GetById(int id)
        {
            return await dbContext.Soils.Include(s => s.Plant_Soils).Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddSoil(Soil soil)
        {
            dbContext.Soils.Add(soil);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSoil(Soil soil)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSoil(Soil soil)
        {
            dbContext.Remove(soil);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> SoilExists(int id)
        {
            return await dbContext.Soils.AnyAsync(c => c.Id == id);
        }




        public async Task<Plant_Soil> GetPlantSoilById(int plantId, int soilId)
        {
            return await dbContext.Plants_Soils.Where(c => c.PlantId == plantId && c.SoilId == soilId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlantSoilJoin(Plant_Soil join)
        {
            dbContext.Plants_Soils.Add(join);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlantSoil(Plant_Soil plantSoil)
        {
            dbContext.Remove(plantSoil);
            return await dbContext.SaveChangesAsync() > 0;
        }


    }
}
