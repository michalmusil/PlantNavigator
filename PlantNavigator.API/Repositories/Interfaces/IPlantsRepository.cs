using PlantNavigator.API.Entities;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IPlantsRepository
    {
        public Task<IEnumerable<Plant>> GetAll(Expression<Func<Plant, bool>> predicate = null);

        public Task<Plant> GetById(int id);

        public Task<IEnumerable<Plant>> GetPlantsOfSoil(int id);

        public Task<bool> DeletePlant(Plant plant);

        public Task<bool> PlantExists(int id);

        public Task<bool> SoilExists(int id);
    }
}
