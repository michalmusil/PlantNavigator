using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
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




        public async Task<IEnumerable<Classification>> GetAll(string? name)
        {
            var all = dbContext.Set<Classification>().AsNoTracking();

            if (name != null)
            {
                all = all.Where(c => c.Name.ToLower().Contains(name.ToLower()));
            }

            return await all.ToListAsync();
        }

        public async Task<Classification> GetById(int id)
        {
            return await dbContext.Classifications.Where(c => c.Id == id).FirstOrDefaultAsync();
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

        public async Task<bool> ClassificationExists(int id)
        {
            return await dbContext.Classifications.AnyAsync(c => c.Id == id);
        }


    }
}
