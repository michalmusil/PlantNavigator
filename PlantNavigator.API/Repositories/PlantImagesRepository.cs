using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Repositories.Interfaces;

namespace PlantNavigator.API.Repositories
{
    public class PlantImagesRepository : IPlantImagesRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public PlantImagesRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PlantImage>> GetAll(int? plantId = null)
        {
            var all = dbContext.Set<PlantImage>().AsNoTracking();

            if (plantId != null)
            {
                all = all.Where(i => i.PlantId == plantId);
            }

            return await all.ToListAsync();
        }

        public async Task<PlantImage> GetById(int id)
        {
            return await dbContext.PlantImages.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PlantImage> GetByImageName(string imageName)
        {
            return await dbContext.PlantImages.Where(i => i.ImageName == imageName).FirstOrDefaultAsync();
        }

        public async Task<bool> AddPlantImage(PlantImage plantImage)
        {
            dbContext.PlantImages.Add(plantImage);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlantImage(PlantImage plantImage)
        {
            dbContext.Remove(plantImage);
            return await dbContext.SaveChangesAsync() > 0;
        }




        public async Task<bool> PlantExists(int id)
        {
            return await dbContext.Plants.AnyAsync(c => c.Id == id);
        }
    }
}
