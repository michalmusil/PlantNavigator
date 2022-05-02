using PlantNavigator.API.Entities;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IPlantsRepository
    {
        public Task<IEnumerable<Plant>> GetAll(Expression<Func<Plant, bool>> predicate = null);
    }
}
