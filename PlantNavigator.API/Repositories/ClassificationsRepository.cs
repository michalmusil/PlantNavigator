using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using PlantNavigator.API.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories
{
    public class ClassificationsRepository : IClassificationsRepository
    {
        protected readonly PlantNavigatorContext dbContext;

        public ClassificationsRepository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<Classification>> GetAll(Expression<Func<Classification, bool>> predicate = null)
        {
            var all = dbContext.Set<Classification>().AsNoTracking();

            if (predicate != null)
            {
                all = all.Where(predicate);
            }

            return await all.ToListAsync();
        }
    }
}
