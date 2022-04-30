using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Entities;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly PlantNavigatorContext dbContext;

        public Repository(PlantNavigatorContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<int> Add(T entity)
        {
            await dbContext.AddAsync<T>(entity);
            await dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbContext.FindAsync<T>(id);
        }


        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {

            var all = dbContext.Set<T>().AsNoTracking();

            if (predicate != null)
            {
                all = all.Where(predicate);
            }

            return await all.ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var a = e;
                return null;
            }
            return entity;
        }

        public virtual async Task Delete(T entity)
        {
            try
            {
                CheckEntityNotNull(entity);
                dbContext.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }


        private void CheckEntityNotNull(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }
        }
    }
}
