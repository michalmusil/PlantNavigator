using PlantNavigator.API.Entities;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<int> Add(T entity);
        public Task<T> GetById(int id);
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        public Task<T> Update(T entity);
        public Task Delete(T entity);
    }
}
