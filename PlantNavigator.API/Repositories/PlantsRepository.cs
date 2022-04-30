using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories
{
    public class PlantsRepository : Repository<Plant>
    {
        public PlantsRepository(PlantNavigatorContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IEnumerable<Plant>> GetAll(Expression<Func<Plant, bool>> predicate = null)
        {
            var all = dbContext.Set<Plant>().AsNoTracking();

            if (predicate != null)
            {
                all = all.Where(predicate);
            }

            all = all.Include(p => p.WaterCondition).Include(p => p.LightCondition);

            return await all.ToListAsync();
        }

    }
}
