using PlantNavigator.API.Entities;
using PlantNavigator.API.Models.DTOs.Post;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IClassificationsRepository
    {
        public Task<IEnumerable<Classification>> GetAll(Expression<Func<Classification, bool>> predicate = null);

        public Task<Classification> GetById(int id);

        public Task<bool> AddClassification(Classification classification);
    }
}
