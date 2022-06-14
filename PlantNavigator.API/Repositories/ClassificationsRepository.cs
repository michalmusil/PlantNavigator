using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class ClassificationsRepository : IClassificationsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public ClassificationsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public async Task<IEnumerable<Classification>> GetAll(string? name, int? plantId = null, bool? includeAsociatedPlants = null)
        {
            var all = dbContext.Set<Classification>().AsNoTracking();

            if (includeAsociatedPlants == true)
            {
                all = all.Include(c => c.Plant_Classifications);
            }

            if (name != null)
            {
                all = all.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            if (plantId != null)
            {
                all = all.Where(c => c.Plant_Classifications.Any(x => x.PlantId == plantId));
            }

            return await all.ToListAsync();
        }

        public async Task<Classification> GetById(int id)
        {
            return await dbContext.Classifications.Include(c => c.Plant_Classifications).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddClassification(Classification classification)
        {
            dbContext.Classifications.Add(classification);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateClassification(Classification classification)
        {
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteClassification(Classification classification)
        {
            dbContext.Remove(classification);
            return await dbContext.SaveChangesAsync() > 0;
        }





        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> ClassificationExists(int id)
        {
            return await dbContext.Classifications.AnyAsync(c => c.Id == id);
        }

        public async Task<Plant_Classification> GetPlantClassificationById(int plantId, int classificationId)
        {
            return await dbContext.Plants_Classifications.Where(c => c.PlantId == plantId && c.ClassificationId == classificationId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlantClassificationJoin(Plant_Classification join)
        {
            dbContext.Plants_Classifications.Add(join);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlantClassification(Plant_Classification plantClassification)
        {
            dbContext.Remove(plantClassification);
            return await dbContext.SaveChangesAsync() > 0;
        }


    }
}
