using PlantNavigator.API.Entities;
using PlantNavigator.API.Entities.JoinEntities;

namespace PlantNavigator.API.Repositories.Interfaces
{
    public interface IClassificationsRepository
    {
        public Task<IEnumerable<Classification>> GetAll(string? name = null, int? plantId = null, bool? includeAsociatedPlants = null);

        public Task<Classification> GetById(int id);

        public Task<bool> AddClassification(Classification classification);

        public Task<bool> UpdateClassification(Classification classification);

        public Task<bool> DeleteClassification(Classification classification);




        public Task<bool> PlantExists(int id);

        public Task<bool> ClassificationExists(int id);
      
        public Task<Plant_Classification> GetPlantClassificationById(int plantId, int classificationId);

        public Task<bool> AddPlantClassificationJoin(Plant_Classification join);

        public Task<bool> DeletePlantClassification(Plant_Classification plantClassification);
    }
}
