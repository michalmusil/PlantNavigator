using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class DiseasesRepository : IDiseasesRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public DiseasesRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Disease>> GetAll(string? name = null, int? plantId = null, bool? includeAsociatedPlants = null)
        {
            var all = dbContext.Set<Disease>().AsNoTracking();

            if (includeAsociatedPlants == true)
            {
                all = all.Include(s => s.Plant_Diseases);
            }

            if (name != null)
            {
                all = all.Where(s => s.Name.ToLower().Contains(name.ToLower()));
            }

            if (plantId != null)
            {
                all = all.Where(s => s.Plant_Diseases.Any(x => x.PlantId == plantId));
            }

            return await all.ToListAsync();
        }

        public async Task<Disease> GetById(int id)
        {
            return await dbContext.Diseases.Include(s => s.Plant_Diseases).Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddDisease(Disease disease)
        {
            dbContext.Diseases.Add(disease);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDisease(Disease disease)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDisease(Disease disease)
        {
            dbContext.Remove(disease);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> DiseaseExists(int id)
        {
            return await dbContext.Diseases.AnyAsync(c => c.Id == id);
        }




        public async Task<Plant_Disease> GetPlantDiseaseById(int plantId, int diseaseId)
        {
            return await dbContext.Plants_Diseases.Where(c => c.PlantId == plantId && c.DiseaseId == diseaseId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlantDiseaseJoin(Plant_Disease join)
        {
            dbContext.Plants_Diseases.Add(join);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlantDisease(Plant_Disease plantDisease)
        {
            dbContext.Remove(plantDisease);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
