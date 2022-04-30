using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;

namespace PlantNavigator.API.Repositories
{
    public class PlantsRepository : Repository<Plant>
    {
        public PlantsRepository(PlantNavigatorContext dbContext) : base(dbContext)
        {
        }


    }
}
