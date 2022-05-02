using PlantNavigator.API.Entities;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IClassificationsRepository
    {
        public Task<IEnumerable<Classification>> GetAll(Expression<Func<Classification, bool>> predicate = null);
    }
}
