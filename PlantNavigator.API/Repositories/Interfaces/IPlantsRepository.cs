using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;
using System.Linq.Expressions;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IPlantsRepository
    {
        public Task<IEnumerable<Plant>> GetAll(Expression<Func<Plant, bool>> predicate = null);

        public Task<IEnumerable<Plant>> GetPlantsOfSoil(int id);

        public Task<bool> AddPlantSoilJoin(Plant_Soil join);

        public Task<bool> PlantExists(int id);

        public Task<bool> SoilExists(int id);
    }
}
